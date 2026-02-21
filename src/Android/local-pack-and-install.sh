#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
BINDINGS_ROOT="$SCRIPT_DIR/Bindings"
OUTPUT_DIR="$SCRIPT_DIR/nupkgs"
INSTALL_DIR="/usr/local/share/dotnet/library-packs"

mkdir -p "$OUTPUT_DIR"
mkdir -p "$INSTALL_DIR"

# Function to build, pack, and immediately install a binding project
build_pack_install() {
  local dir=$1
  local tmp_out="$OUTPUT_DIR/$dir"
  mkdir -p "$tmp_out"

  echo "Building $dir..."
  dotnet build "$BINDINGS_ROOT/$dir" -c Release

  echo "Packing $dir..."
  dotnet pack "$BINDINGS_ROOT/$dir" -c Release --no-build -o "$tmp_out"

  echo "Installing $dir to $INSTALL_DIR..."
  cp -f "$tmp_out"/*.nupkg "$INSTALL_DIR/"
}

# Build in dependency order: Internal first, then Core, then the rest
build_pack_install "Internal"
build_pack_install "Core"

REMAINING_DIRS=(
  "DatadogLogs"
  "Ndk"
  "Rum"
  "SessionReplay"
  "SessionReplay.Material"
  "Trace"
  "Trace.Otel"
  "WebView"
)

for dir in "${REMAINING_DIRS[@]}"; do
  build_pack_install "$dir"
done

echo ""
echo "Done. Android packages installed in $INSTALL_DIR:"
ls "$INSTALL_DIR"/Bcr.Datadog.Android.*.nupkg
