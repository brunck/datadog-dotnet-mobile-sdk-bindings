#!/usr/bin/env bash
#

TARGET_SDK="iphoneos"
FOLDER_PATH="./Bindings"
BINDING_OUTPUT_PATH="${FOLDER_PATH}"
HEADER_FILE_PATH="${FOLDER_PATH}/Headers"

# Objective Sharpie
echo "Creating bindings with Objective Sharpie."
echo

# Exclude DatadogSessionReplay-Swift.h. Right now, it duplicates what is in DatadogObjc-Swift.h, the latter having deprecated versions of the same thing in the former.
# Objective Sharpie will throw an error if it finds two declarations of the same thing.
# We can remove this exclusion if the deprecated versions from DatadogObjc-Swift.h are removed.
SHARPIE_HEADER_FILES=$(find "${HEADER_FILE_PATH}" -type f -name "*.h" | grep -v "DatadogSessionReplay-Swift.h")

echo sharpie bind -v -output "$BINDING_OUTPUT_PATH" -namespace "Datadog.iOS" -sdk $TARGET_SDK -scope "$HEADER_FILE_PATH" $SHARPIE_HEADER_FILES
echo

sharpie bind -v -output "$BINDING_OUTPUT_PATH" -namespace "Datadog.iOS" -sdk $TARGET_SDK -scope "$HEADER_FILE_PATH" $SHARPIE_HEADER_FILES

echo "Done creating bindings."
echo