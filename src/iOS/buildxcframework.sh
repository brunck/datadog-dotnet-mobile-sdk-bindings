#!/usr/bin/env bash
#

# Define workspace and scheme
WORKSPACE="../../../dd-sdk-ios/Datadog.xcworkspace"
FRAMEWORK_NAMES=("DatadogInternal" "DatadogCore" "DatadogLogs" "DatadogTrace" "DatadogRUM" "DatadogSessionReplay" "DatadogCrashReporting" "DatadogObjc")
XCFRAMEWORK_NAMES=("DDInt" "DDC" "DDL" "DDT" "DDR" "DDSR" "DDCR" "DDObjc")
CONFIGURATION="Release"
DERIVED_DATA_PATH="./DerivedData"
BUILD_DIR="${DERIVED_DATA_PATH}/Build/Products/${CONFIGURATION}"
CARTFILE_DIRECTORY="../../../dd-sdk-ios"
CARTHAGE_OUTPUT="${CARTFILE_DIRECTORY}/Carthage/Build"

echo
echo "Building XCFrameworks for Datadog SDK."
if ! carthage update --platform iOS --use-xcframeworks --project-directory "${CARTFILE_DIRECTORY}"; then
  echo "Carthage update failed. Exiting."
  exit 1
fi

# Define output folder environment variable
OUTPUT_FOLDER="${PWD}/build"

echo
echo "Cleaning up old .xcframework files at ${OUTPUT_FOLDER}."
if find "${OUTPUT_FOLDER}" -name "*.xcframework" -type d | read -r; then
  find "${OUTPUT_FOLDER}" -name "*.xcframework" -type d -exec rm -rf {} \;
  echo "Removed existing .xcframework files."
else
  echo "No existing .xcframework files to remove at."
fi

for INDEX in "${!FRAMEWORK_NAMES[@]}"; do
  FRAMEWORK_NAME="${FRAMEWORK_NAMES[$INDEX]}"
  XCFRAMEWORK_NAME="${XCFRAMEWORK_NAMES[$INDEX]}"
  SCHEME="${FRAMEWORK_NAME} iOS"
  SIMULATOR_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphonesimulator.xcarchive"
  DEVICE_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphoneos.xcarchive"

  ### Build archives
  # Simulator
  echo 
  echo "Creating Simulator archive for ${FRAMEWORK_NAME}."
  echo
  if ! xcodebuild -workspace "${WORKSPACE}" archive \
    -sdk iphonesimulator \
    -scheme "${SCHEME}" \
    -archivePath "${SIMULATOR_ARCHIVE_PATH}" \
    -destination "generic/platform=iOS Simulator" \
    -derivedDataPath "${DERIVED_DATA_PATH}" \
    -IDECustomBuildProductsPath="" -IDECustomBuildIntermediatesPath="" \
    ONLY_ACTIVE_ARCH=NO \
    IPHONEOS_DEPLOYMENT_TARGET=13.0 \
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
    -sdk iphoneos \
    -scheme "${SCHEME}" \
    -archivePath "${DEVICE_ARCHIVE_PATH}" \
    -destination "generic/platform=iOS" \
    -derivedDataPath "${DERIVED_DATA_PATH}" \
    -IDECustomBuildProductsPath="" -IDECustomBuildIntermediatesPath="" \
    ONLY_ACTIVE_ARCH=NO \
    IPHONEOS_DEPLOYMENT_TARGET=13.0 \
    ENABLE_BITCODE=NO \
    SKIP_INSTALL=NO \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES; then
      echo "Device build for ${FRAMEWORK_NAME} failed. Exiting."
      echo
      exit 1
  fi

  # Create XCFramework by combining all frameworks
  echo "Creating XCFramework ${XCFRAMEWORK_NAME} for ${FRAMEWORK_NAME} framework."
  echo
  if ! xcodebuild -create-xcframework \
    -framework "${SIMULATOR_ARCHIVE_PATH}/Products/Library/Frameworks/${FRAMEWORK_NAME}.framework" \
    -framework "${DEVICE_ARCHIVE_PATH}/Products/Library/Frameworks/${FRAMEWORK_NAME}.framework" \
    -output "${OUTPUT_FOLDER}/${XCFRAMEWORK_NAME}.xcframework"; then
      echo "Creating XCFramework ${XCFRAMEWORK_NAME} for ${FRAMEWORK_NAME} failed. Exiting."
      echo
      exit 1
  fi
  echo "Done creating XCFramework ${XCFRAMEWORK_NAME} for ${FRAMEWORK_NAME} framework."
  echo 
done

echo "Done with all frameworks."
echo

echo
echo "Copying .xcframework/dependencies to binding project path."
echo

SOURCE_DIR="${OUTPUT_FOLDER}"
TARGET_DIR="./Bindings/Libs"

echo "Cleaning up old .xcframework files at ${TARGET_DIR}."
echo
if find "${TARGET_DIR}" -name "*.xcframework" -type d | grep -q .; then
  find "${TARGET_DIR}" -name "*.xcframework" -type d -exec rm -rf {} +
  echo "Removed existing .xcframework files."
else
  echo "No existing .xcframework files to remove."
fi

# Find .xcframework files in the source directory
echo
echo "Copying .xcframeworks from ${SOURCE_DIR} to target directory ${TARGET_DIR}."
echo
find "$SOURCE_DIR" -name "*.xcframework" -type d | while read -r framework
do
  # Copy the framework to the target directory
  if ! cp -R "$framework" "$TARGET_DIR"; then
    echo "Failed to copy $framework. Exiting."
    exit 1
  fi
done

echo "Copying OpenTelemetryApi.xcframework to target directory ${TARGET_DIR}."
echo
if ! cp -R "${CARTHAGE_OUTPUT}/OpenTelemetryApi.xcframework" "${TARGET_DIR}"; then
  echo "Failed to copy OpenTelemetryApi.xcframework. Exiting."
  exit 1
fi

echo
echo "Done."
echo
