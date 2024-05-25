#!/usr/bin/env bash
#

# Define workspace and scheme
WORKSPACE="../../../dd-sdk-ios/Datadog.xcworkspace"
FRAMEWORK_NAME="DatadogObjc"
SCHEME="${FRAMEWORK_NAME} iOS"
CONFIGURATION="Release"
DERIVED_DATA_PATH="./DerivedData"
BUILD_DIR="${DERIVED_DATA_PATH}/${FRAMEWORK_NAME}/Build/Products/${CONFIGURATION}"
SIMULATOR_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphonesimulator.xcarchive"
DEVICE_ARCHIVE_PATH="${BUILD_DIR}/${FRAMEWORK_NAME}-iphoneos.xcarchive"

# Define output folder environment variable
OUTPUT_FOLDER="${PWD}/build"

### Build archives
# Simulator
echo 
echo "Creating Simulator archive."
echo

# xcodebuild -workspace "${WORKSPACE}" -scheme "${SCHEME}" -configuration Release -sdk iphoneos -derivedDataPath "${OUTPUT_FOLDER}/iphoneos" BUILD_LIBRARY_FOR_DISTRIBUTION=YES SKIP_INSTALL=NO
if ! xcodebuild -workspace "${WORKSPACE}" archive \
  -scheme "${SCHEME}" \
  -archivePath ${SIMULATOR_ARCHIVE_PATH} \
  -destination "generic/platform=iOS Simulator" \
  -derivedDataPath "${DERIVED_DATA_PATH}" \
  -IDECustomBuildProductsPath="" -IDECustomBuildIntermediatesPath="" \
  ENABLE_BITCODE=NO \
  SKIP_INSTALL=NO \
  BUILD_LIBRARY_FOR_DISTRIBUTION=YES; then
    echo "Simulator build failed. Exiting."
    echo
    exit 1
fi

# Device
echo "Creating Device archive."
echo
#xcodebuild -workspace "${WORKSPACE}" -scheme "${SCHEME}" -configuration Release -sdk iphonesimulator -derivedDataPath "${OUTPUT_FOLDER}/iphonesimulator" BUILD_LIBRARY_FOR_DISTRIBUTION=YES SKIP_INSTALL=NO

if ! xcodebuild -workspace "${WORKSPACE}" archive \
  -scheme "${SCHEME}" \
  -archivePath ${DEVICE_ARCHIVE_PATH} \
  -destination "generic/platform=iOS" \
  -derivedDataPath "${DERIVED_DATA_PATH}" \
  -IDECustomBuildProductsPath="" -IDECustomBuildIntermediatesPath="" \
  ENABLE_BITCODE=NO \
  SKIP_INSTALL=NO \
  BUILD_LIBRARY_FOR_DISTRIBUTION=YES; then
    echo "Device build failed. Exiting."
    echo
    exit 1
fi

# Clean up old output directory
if [[ -d "${OUTPUT_FOLDER}" ]]; then
    rm -rf "${OUTPUT_FOLDER:?}"
fi

# Create XCFramework by combining all frameworks
echo "Creating XCFramework."
echo

if ! xcodebuild -create-xcframework \
  -framework ${SIMULATOR_ARCHIVE_PATH}/Products/Library/Frameworks/${FRAMEWORK_NAME}.framework \
  -framework ${DEVICE_ARCHIVE_PATH}/Products/Library/Frameworks/${FRAMEWORK_NAME}.framework \
  -output ${OUTPUT_FOLDER}/${FRAMEWORK_NAME}.xcframework; then
    echo "Create XCFramework failed. Exiting."
    echo
    exit 1
fi

echo "Done creating XCFramework."
echo 

echo
echo "Copying .xcframework/dependencies to binding project path."
echo

SOURCE_DIR="${DERIVED_DATA_PATH}"
TARGET_DIR="./Bindings"

# Find .framework files in the source directory
echo "Copying frameworks from ${SOURCE_DIR} to target directory ${TARGET_DIR}."
echo
find "$SOURCE_DIR" -name "*.framework" -type d | while read -r framework
do
  # Get the name of the framework
  framework_name=$(basename "$framework")

  if [ "$framework_name" != "${FRAMEWORK_NAME}.framework" ]; then
    # Copy the framework to the target directory
    cp -R "$framework" "$TARGET_DIR"
  fi
done

# if [[ -d "${BINDING_PROJECT_PATH}/${DEPENDENCY_FILE_NAME}" ]]; then
#     rm -rf "${BINDING_PROJECT_PATH:?}/${DEPENDENCY_FILE_NAME}"
# fi

echo
echo "Cleaning up old .xcframework at ${TARGET_DIR}."
echo
if [[ -d "${TARGET_DIR}/${FRAMEWORK_NAME}.xcframework" ]]; then
    rm -rf "${TARGET_DIR}/${FRAMEWORK_NAME}.xcframework"
fi

echo "Copying .xcframework to binding project path: ${TARGET_DIR}."
cp -R "${OUTPUT_FOLDER}/${FRAMEWORK_NAME}.xcframework" ${TARGET_DIR}

echo
echo "Done."
echo

# Create XCFramework
# xcodebuild -create-xcframework \
# -framework "${OUTPUT_FOLDER}/iphoneos/Build/Products/Release-iphoneos/${SCHEME}.framework" \
# -framework "${OUTPUT_FOLDER}/iphonesimulator/Build/Products/Release-iphonesimulator/${SCHEME}.framework" \
# -output "${OUTPUT_FOLDER}/${SCHEME}.xcframework"