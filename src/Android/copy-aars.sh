#!/bin/bash

# Source and destination paths
DD_SDK_ROOT="dd-sdk-android"
BINDINGS_ROOT="src/Android/Bindings"

# Function to copy AAR file if it exists
copy_aar() {
    local project_name=$1
    local source_dir=$2
    local dest_dir=$3
    local aar_name="$project_name-release.aar"
    
    # Source path in build/outputs/aar
    local source_path="$source_dir/build/outputs/aar/dd-$aar_name"
    
    # ensure destination directory exists
    mkdir -p "$dest_dir/aars"
    
    # Copy and overwrite destination if it exists
    if [ -f "$source_path" ]; then
        echo "Copying $source_path to $dest_dir/aars/dd-$aar_name..."
        cp -f "$source_path" "$dest_dir/aars/dd-$aar_name"
    else
        echo "Warning: $source_path not found."
    fi
}

# Root level projects
copy_aar "sdk-android-core" "$DD_SDK_ROOT/dd-sdk-android-core" "$BINDINGS_ROOT/Core"
copy_aar "sdk-android-internal" "$DD_SDK_ROOT/dd-sdk-android-internal" "$BINDINGS_ROOT/Internal"

# Feature projects
FEATURES_DIR="$DD_SDK_ROOT/features"
copy_aar "sdk-android-logs" "$FEATURES_DIR/dd-sdk-android-logs" "$BINDINGS_ROOT/DatadogLogs"
copy_aar "sdk-android-ndk" "$FEATURES_DIR/dd-sdk-android-ndk" "$BINDINGS_ROOT/Ndk"
copy_aar "sdk-android-rum" "$FEATURES_DIR/dd-sdk-android-rum" "$BINDINGS_ROOT/Rum"
copy_aar "sdk-android-session-replay" "$FEATURES_DIR/dd-sdk-android-session-replay" "$BINDINGS_ROOT/SessionReplay"
copy_aar "sdk-android-session-replay-material" "$FEATURES_DIR/dd-sdk-android-session-replay-material" "$BINDINGS_ROOT/SessionReplay.Material"
copy_aar "sdk-android-trace" "$FEATURES_DIR/dd-sdk-android-trace" "$BINDINGS_ROOT/Trace"
copy_aar "sdk-android-trace-otel" "$FEATURES_DIR/dd-sdk-android-trace-otel" "$BINDINGS_ROOT/Trace.Otel"
copy_aar "sdk-android-webview" "$FEATURES_DIR/dd-sdk-android-webview" "$BINDINGS_ROOT/WebView"

echo "AAR copy process complete"