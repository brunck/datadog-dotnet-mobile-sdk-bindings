#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
REPO_ROOT="$(cd "$SCRIPT_DIR/../.." && pwd)"
DD_SDK_ROOT="$REPO_ROOT/dd-sdk-android"
GRADLEW="$DD_SDK_ROOT/gradlew"

if [ ! -d "$DD_SDK_ROOT" ]; then
  echo "Error: dd-sdk-android not found at $DD_SDK_ROOT"
  exit 1
fi
if [ ! -f "$GRADLEW" ]; then
  echo "Error: gradlew not found in $DD_SDK_ROOT"
  exit 1
fi
chmod +x "$GRADLEW"

# stop any running daemon to avoid cached state
cd "$DD_SDK_ROOT"
"$GRADLEW" --stop || true

# run a clean first to ensure fresh outputs (disable build cache)
echo "Running Gradle clean..."
"$GRADLEW" clean --no-daemon --no-build-cache --info

tasks=()
tasks+=( ":dd-sdk-android-core:assembleRelease" )
tasks+=( ":dd-sdk-android-internal:assembleRelease" )

FEATURES_DIR="$DD_SDK_ROOT/features"
if [ -d "$FEATURES_DIR" ]; then
  for d in "$FEATURES_DIR"/dd-sdk-android-*; do
    [ -e "$d" ] || continue
    [ -d "$d" ] || continue
    name=$(basename "$d")
    if [ -f "$d/build.gradle" ] || [ -f "$d/build.gradle.kts" ]; then
      # use the full project path under the 'features' container
      tasks+=( ":features:$name:assembleRelease" )
    fi
  done
fi

if [ "${#tasks[@]}" -eq 0 ]; then
  echo "No Gradle tasks to run."
  exit 0
fi

echo "Running Gradle tasks:"
for t in "${tasks[@]}"; do echo "  $t"; done

# run assemble with no build cache and force task execution
"$GRADLEW" "${tasks[@]}" --no-daemon --no-build-cache --rerun-tasks --info