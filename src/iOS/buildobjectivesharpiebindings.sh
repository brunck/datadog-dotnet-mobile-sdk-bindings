#!/usr/bin/env bash
#

TARGET_SDK="iphoneos"
FOLDER_PATH="./Bindings"
BINDING_OUTPUT_PATH="${FOLDER_PATH}"
HEADER_FILES_TARGET_PATH="${FOLDER_PATH}/Headers"
OUTPUT_FOLDER="${PWD}/build"
HEADER_FILE_PREFIXES=("DatadogObjc" "DatadogCrashReporting" "DatadogInternal")

if [[ -d $HEADER_FILES_TARGET_PATH ]]; then
    rm -r $HEADER_FILES_TARGET_PATH
fi

if ! mkdir $HEADER_FILES_TARGET_PATH; then
    echo "Failed to create Sharpie header files target path at ${HEADER_FILES_TARGET_PATH}. Exiting."
    exit 1
fi

echo "Copying Swift header files to target directory ${HEADER_FILES_TARGET_PATH} for Objective Sharpie."
echo

for FRAMEWORK_NAME in "${HEADER_FILE_PREFIXES[@]}"; do
  XCFRAMEWORK_PATH="${OUTPUT_FOLDER}/${FRAMEWORK_NAME}.xcframework"
  HEADER_FILE_PATH=$(find "${XCFRAMEWORK_PATH}" -name "${FRAMEWORK_NAME}-Swift.h" | head -n 1)
  if [ -z "${HEADER_FILE_PATH}" ]; then

    echo "Failed to find ${FRAMEWORK_NAME}-Swift.h in ${XCFRAMEWORK_PATH}. Exiting."
    exit 1
  fi
  cp -f "${HEADER_FILE_PATH}" "${HEADER_FILES_TARGET_PATH}"
  if [ $? -ne 0 ]; then
    echo "Failed to copy ${HEADER_FILE_PATH} to ${HEADER_FILES_TARGET_PATH}. Exiting."
    exit 1
  fi
done

# Objective Sharpie
echo "Creating bindings with Objective Sharpie."
echo

# Exclude DatadogSessionReplay-Swift.h. Right now, it duplicates what is in DatadogObjc-Swift.h, the latter having deprecated versions of the same thing in the former.
# Objective Sharpie will throw an error if it finds two declarations of the same thing.
# We can remove this exclusion if the deprecated versions from DatadogObjc-Swift.h are removed.
SHARPIE_HEADER_FILES=$(find "${HEADER_FILES_TARGET_PATH}" -type f -name "*.h" | grep -v "DatadogSessionReplay-Swift.h")

echo sharpie bind -v -output "$BINDING_OUTPUT_PATH" -namespace "Datadog.iOS" -sdk $TARGET_SDK -scope "$HEADER_FILES_TARGET_PATH" $SHARPIE_HEADER_FILES
echo

sharpie bind -v -output "$BINDING_OUTPUT_PATH" -namespace "Datadog.iOS" -sdk $TARGET_SDK -scope "$HEADER_FILES_TARGET_PATH" $SHARPIE_HEADER_FILES

echo "Done creating bindings."
echo