#!/usr/bin/env bash
#

TARGET_SDK="iphoneos"
FOLDER_PATH="./Bindings"
BINDING_OUTPUT_PATH="${FOLDER_PATH}"
HEADER_FILES_TARGET_PATH="${FOLDER_PATH}/Headers"
OUTPUT_FOLDER="${PWD}/build"
HEADER_FILE_PREFIXES=("DatadogObjc" "DatadogCrashReporting" "DatadogSessionReplay" "DatadogWebViewTracking")
XCFRAMEWORK_NAMES=("DDObjc" "DDCR" "DDSR" "DWVT")
NAMESPACES=("Datadog.iOS.ObjC" "Datadog.iOS.CrashReporting" "Datadog.iOS.SessionReplay" "Datadog.iOS.WebViewTracking")
BINDING_PROJECT_PATHS=("ObjC" "CrashReporting" "SessionReplay" "WebViewTracking")

# Objective Sharpie
# echo "Creating bindings with Objective Sharpie."
echo

for ((i=0; i<${#HEADER_FILE_PREFIXES[@]}; i++)); do
  FRAMEWORK_NAME="${HEADER_FILE_PREFIXES[i]}"
  HEADER_FILE_PATH=$(find "${HEADER_FILES_TARGET_PATH}" -name "${FRAMEWORK_NAME}-Swift.h" | head -n 1)
  BINDING_PROJECT_FOLDER="${BINDING_PROJECT_PATHS[i]}"
  if [ -z "${HEADER_FILE_PATH}" ]; then
    echo "Failed to find ${FRAMEWORK_NAME}-Swift.h in ${HEADER_FILE_PATH}. Exiting."
    exit 1
  fi
  echo
  echo "Creating bindings for ${FRAMEWORK_NAME} with Objective Sharpie."
  echo
  echo sharpie bind -v -output "$BINDING_OUTPUT_PATH/$BINDING_PROJECT_FOLDER" -namespace "${NAMESPACES[i]}" -sdk $TARGET_SDK -scope "$HEADER_FILES_TARGET_PATH" $HEADER_FILE_PATH
  echo
  sharpie bind -v -output "$BINDING_OUTPUT_PATH/$BINDING_PROJECT_FOLDER" -namespace "${NAMESPACES[i]}" -sdk $TARGET_SDK -scope "$HEADER_FILES_TARGET_PATH" $HEADER_FILE_PATH
  if [ $? -ne 0 ]; then
    echo "Failed to create bindings for ${FRAMEWORK_NAME}. Exiting."
    exit 1
  fi
  echo "Done creating bindings for ${FRAMEWORK_NAME}."
  echo
done

echo "Done creating bindings."
echo