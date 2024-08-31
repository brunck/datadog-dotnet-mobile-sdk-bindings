#!/usr/bin/env bash
#

# Define workspace and scheme
WORKSPACE="../../../dd-sdk-ios/Datadog.xcworkspace"
FRAMEWORK_NAMES=("DatadogInternal" "DatadogCore" "DatadogLogs" "DatadogTrace" "DatadogRUM" "DatadogSessionReplay" "DatadogCrashReporting" "DatadogObjc" "DatadogWebViewTracking")
XCFRAMEWORK_NAMES=("DDInt" "DDC" "DDL" "DDT" "DDR" "DDSR" "DDCR" "DDObjc" "DWVT")
CONFIGURATION="Release"
DERIVED_DATA_PATH="./DerivedData"
BUILD_DIR="${DERIVED_DATA_PATH}/Build/Products/${CONFIGURATION}"
CARTFILE_DIRECTORY="../../../dd-sdk-ios"
CARTHAGE_OUTPUT="${CARTFILE_DIRECTORY}/Carthage/Build"

echo
echo "Building XCFrameworks for Datadog SDK."
if ! carthage bootstrap --platform iOS --use-xcframeworks --project-directory "${CARTFILE_DIRECTORY}"; then
  echo "Carthage bootstrap failed. Exiting."
  exit 1
fi

# Define output folder environment variable
OUTPUT_FOLDER="${PWD}/build"

echo
echo "Cleaning up old .xcframework files at ${OUTPUT_FOLDER}."
if find "${OUTPUT_FOLDER}" -name "*.xcframework" -type d | grep -q .; then
  find "${OUTPUT_FOLDER}" -name "*.xcframework" -type d -exec rm -rf {} \;
  echo "Removed existing .xcframework files."
else
  echo "No existing .xcframework files to remove."
fi

function archive {
  echo "▸ Start archiving the scheme: $1 sdk: $2 for destination: $3;\n▸ Archive path: $4"
  if ! xcodebuild -workspace "${WORKSPACE}" archive \
    -scheme "$1" \
    -sdk "$2" \
    -destination "$3" \
    -archivePath "$4" \
    -derivedDataPath "${DERIVED_DATA_PATH}" \
    -IDECustomBuildProductsPath="" -IDECustomBuildIntermediatesPath="" \
    ONLY_ACTIVE_ARCH=NO \
    IPHONEOS_DEPLOYMENT_TARGET=13.0 \
    ENABLE_BITCODE=NO \
    SKIP_INSTALL=NO \
    BUILD_LIBRARY_FOR_DISTRIBUTION=YES; then
      echo "Build for $5 failed. Exiting."
      echo
      exit 1
  fi
}

for INDEX in "${!FRAMEWORK_NAMES[@]}"; do
  FRAMEWORK_NAME="${FRAMEWORK_NAMES[$INDEX]}"
  XCFRAMEWORK_NAME="${XCFRAMEWORK_NAMES[$INDEX]}"
  SCHEME="${FRAMEWORK_NAME} iOS"
  SIMULATOR_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphonesimulator.xcarchive"
  DEVICE_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphoneos.xcarchive"
  xcoptions=()

  ### Build archives
  # Simulator
  echo 
  echo "Creating Simulator archive for ${FRAMEWORK_NAME}."
  echo

  archive "${SCHEME}" iphonesimulator "generic/platform=iOS Simulator" "${SIMULATOR_ARCHIVE_PATH}" "${FRAMEWORK_NAME}"
  xcoptions+=(-archive "${SIMULATOR_ARCHIVE_PATH}" -framework "${FRAMEWORK_NAME}.framework")

  # Device
  echo
  echo "Creating Device archive for ${FRAMEWORK_NAME}."
  echo

  archive "${SCHEME}" iphoneos "generic/platform=iOS" "${DEVICE_ARCHIVE_PATH}" "${FRAMEWORK_NAME}"
  xcoptions+=(-archive "${DEVICE_ARCHIVE_PATH}" -framework "${FRAMEWORK_NAME}.framework")

  # Create XCFramework by combining all frameworks
  # Datadog class conflicts with module name and Swift emits invalid module interface
  # cf. https://github.com/apple/swift/issues/56573
  #
  # Therefore, we cannot provide ABI stability and we have to supply '-allow-internal-distribution'.
  echo "Creating XCFramework ${XCFRAMEWORK_NAME} for ${FRAMEWORK_NAME} framework."
  echo
  if ! xcodebuild -create-xcframework \
    -allow-internal-distribution \
    "${xcoptions[@]}" \
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
