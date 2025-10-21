#!/bin/bash

SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# Define the library path and output directory
BASE_REF_PATH="/usr/local/share/dotnet/packs"
LIBRARY_PATH=$(find "$BASE_REF_PATH" -maxdepth 1 -type d -name "Microsoft.iOS.Ref.net9.0*" | head -n 1)
OUTPUT_DIR="Mdoc"

# If no directory found, exit
if [ -z "$LIBRARY_PATH" ]; then
  echo "Path not found under '$BASE_REF_PATH'"
  exit 1
fi

DLL_NAMES=("core.dll" "cr.dll" "log.dll" "int.dll" "objc.dll" "rum.dll" "sr.dll" "trace.dll" "wvt.dll")

DLL_PATHS=()
for dllName in "${DLL_NAMES[@]}"; do
  # Search recursively from the script directory
  path=$(find "$SCRIPT_DIR" -type f -name "$dllName" 2>/dev/null | head -n 1)
  if [ -z "$path" ]; then
    echo "Could not find $dllName in $SCRIPT_DIR or its subdirectories"
  else
    echo "Found $dllName at $path"
    DLL_PATHS+=("$path")
  fi
done

# Check if we found any DLLs
if [ ${#DLL_PATHS[@]} -eq 0 ]; then
  echo "No DLLs found. Exiting."
  exit 1
fi

# Execute the mdoc update command with sudo
echo "Running mdoc update with ${#DLL_PATHS[@]} DLLs"
sudo mdoc update -L "$LIBRARY_PATH" --out "$OUTPUT_DIR" "${DLL_PATHS[@]}" --debug

# Change ownership of the files/folders to the current user
for fileToOwn in "Mdoc/Datadog.iOS.CrashReporting" "Mdoc/Datadog.iOS.ObjC" "Mdoc/Datadog.iOS.SessionReplay" "Mdoc/Datadog.iOS.WebViewTracking" "Mdoc/index.xml" "Mdoc/ns-Datadog.iOS.CrashReporting.xml" "Mdoc/ns-Datadog.iOS.ObjC.xml" "Mdoc/ns-Datadog.iOS.SessionReplay.xml" "Mdoc/ns-Datadog.iOS.WebViewTracking.xml"; do
  if [ -e "$fileToOwn" ]; then
    output=$(sudo chown -R "$USER" "$fileToOwn" 2>&1)
    echo "$output"
  fi
done
