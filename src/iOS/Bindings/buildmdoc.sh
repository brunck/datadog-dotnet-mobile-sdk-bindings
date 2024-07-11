#!/bin/bash

# Define the library path and output directory
LIBRARY_PATH="/usr/local/share/dotnet/packs/Microsoft.iOS.Ref/17.2.8053/ref/net8.0"
OUTPUT_DIR="Mdoc"
DLL_PATH="/Users/brian/Documents/SourceCode/datadog-dotnet-mobile-sdk-bindings/src/iOS/Bindings/bin/Debug/net8.0-ios/ios.dll"

# Execute the mdoc update command with sudo
sudo mdoc update -L "$LIBRARY_PATH" --out "$OUTPUT_DIR" "$DLL_PATH" --debug

output=$(sudo chown -R brian Mdoc/Datadog.iOS 2>&1)
echo "$output"

output=$(sudo chown -R brian Mdoc/index.xml 2>&1)
echo "$output"

output=$(sudo chown -R brian Mdoc/ns-Datadog.iOS.xml 2>&1)
echo "$output"