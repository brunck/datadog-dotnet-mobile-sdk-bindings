#!/usr/bin/env bash
#

# Define workspace and scheme
WORKSPACE="../../../dd-sdk-ios/Datadog.xcworkspace"
FRAMEWORK_NAMES=("DatadogInternal" "DatadogCore" "DatadogLogs" "DatadogTrace" "DatadogRUM" "DatadogSessionReplay" "DatadogCrashReporting" "DatadogObjc")
CONFIGURATION="Release"
DERIVED_DATA_PATH="./DerivedData"
BUILD_DIR="${DERIVED_DATA_PATH}/Build/Products/${CONFIGURATION}"
CARTFILE_DIRECTORY="../../../dd-sdk-ios"
CARTHAGE_OUTPUT="${CARTFILE_DIRECTORY}/Carthage/Build"

echo
echo "Building XCFrameworks for Datadog SDK."
carthage update --platform iOS --use-xcframeworks --project-directory "${CARTFILE_DIRECTORY}"
if [ $? -ne 0 ]; then
  echo "Carthage update failed. Exiting."
  exit 1
fi

# Define output folder environment variable
OUTPUT_FOLDER="${PWD}/build"

echo
echo "Cleaning up old .xcframework files at ${OUTPUT_FOLDER}."
find "${OUTPUT_FOLDER}" -name "*.xcframework" -type d -exec rm -rf {} \;
if [ $? -ne 0 ]; then
  echo "Failed to clean up old .xcframework files. Exiting."
  exit 1
fi

for FRAMEWORK_NAME in "${FRAMEWORK_NAMES[@]}"; do
  SCHEME="${FRAMEWORK_NAME} iOS"
  SIMULATOR_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphonesimulator.xcarchive"
  DEVICE_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphoneos.xcarchive"

  ### Build archives
  # Simulator
  echo 
  echo "Creating Simulator archive for ${FRAMEWORK_NAME}."
  echo
  if ! xcodebuild -workspace "${WORKSPACE}" archive \
    -scheme "${SCHEME}" \
    -archivePath "${SIMULATOR_ARCHIVE_PATH}" \
    -destination "generic/platform=iOS Simulator" \
    -derivedDataPath "${DERIVED_DATA_PATH}" \
    -IDECustomBuildProductsPath="" -IDECustomBuildIntermediatesPath="" \
    ENABLE_BITCODE=NO \
    SKIP_INSTALL=NO \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES; then
      echo "Simulator build for ${FRAMEWORK_NAME} failed. Exiting."
      echo
      exit 1
  fi

  # Device
  echo "Creating Device archive for ${FRAMEWORK_NAME}."
  echo
  if ! xcodebuild -workspace "${WORKSPACE}" archive \
    -scheme "${SCHEME}" \
    -archivePath "${DEVICE_ARCHIVE_PATH}" \
    -destination "generic/platform=iOS" \
    -derivedDataPath "${DERIVED_DATA_PATH}" \
    -IDECustomBuildProductsPath="" -IDECustomBuildIntermediatesPath="" \
    ENABLE_BITCODE=NO \
    SKIP_INSTALL=NO \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES; then
      echo "Device build for ${FRAMEWORK_NAME} failed. Exiting."
      echo
      exit 1
  fi

  # Create XCFramework by combining all frameworks
  echo "Creating XCFramework for ${FRAMEWORK_NAME}."
  echo
  if ! xcodebuild -create-xcframework \
    -framework "${SIMULATOR_ARCHIVE_PATH}/Products/Library/Frameworks/${FRAMEWORK_NAME}.framework" \
    -framework "${DEVICE_ARCHIVE_PATH}/Products/Library/Frameworks/${FRAMEWORK_NAME}.framework" \
    -output "${OUTPUT_FOLDER}/${FRAMEWORK_NAME}.xcframework"; then
      echo "Create XCFramework for ${FRAMEWORK_NAME} failed. Exiting."
      echo
      exit 1
  fi
  echo "Done creating XCFramework for ${FRAMEWORK_NAME}."
  echo 
done

echo "Done with all frameworks."
echo

echo
echo "Copying .xcframework/dependencies to binding project path."
echo

SOURCE_DIR="${OUTPUT_FOLDER}"
TARGET_DIR="./Bindings"

echo "Cleaning up old .xcframework files at ${TARGET_DIR}."
echo
find "${TARGET_DIR}" -name "*.xcframework" -type d -exec rm -rf {} \;
if [ $? -ne 0 ]; then
  echo "Failed to clean up old .xcframework files. Exiting."
  exit 1
fi

# Find .xcframework files in the source directory
echo "Copying frameworks from ${SOURCE_DIR} to target directory ${TARGET_DIR}."
echo
find "$SOURCE_DIR" -name "*.xcframework" -type d | while read -r framework
do
  # Copy the framework to the target directory
  cp -R "$framework" "$TARGET_DIR"
  if [ $? -ne 0 ]; then
    echo "Failed to copy $framework. Exiting."
    exit 1
  fi
done

echo "Copying CrashReporter.xcframework to target directory ${TARGET_DIR}."
echo
cp -R "${CARTHAGE_OUTPUT}/CrashReporter.xcframework" "${TARGET_DIR}"
if [ $? -ne 0 ]; then
  echo "Failed to copy CrashReporter.xcframework. Exiting."
  exit 1
fi

HEADER_FILE_PREFIXES=("DatadogObjc" "DatadogCrashReporting" "DatadogInternal" "DatadogSessionReplay")

echo "Copying Swift header files to target directory ${TARGET_DIR} for Objective Sharpie."

for FRAMEWORK_NAME in "${HEADER_FILE_PREFIXES[@]}"; do
  XCFRAMEWORK_PATH="${OUTPUT_FOLDER}/${FRAMEWORK_NAME}.xcframework"
  HEADER_FILE_PATH=$(find "${XCFRAMEWORK_PATH}" -name "${FRAMEWORK_NAME}-Swift.h" | head -n 1)
  if [ -z "${HEADER_FILE_PATH}" ]; then

    echo "Failed to find ${FRAMEWORK_NAME}-Swift.h in ${XCFRAMEWORK_PATH}. Exiting."
    exit 1
  fi
  cp -f "${HEADER_FILE_PATH}" "${TARGET_DIR}"
  if [ $? -ne 0 ]; then
    echo "Failed to copy ${HEADER_FILE_PATH} to ${TARGET_DIR}. Exiting."
    exit 1
  fi
done

echo
echo "Done."
echo
