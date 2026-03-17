$ErrorActionPreference = "Stop"

$ScriptDir = $PSScriptRoot
$BindingsRoot = "$ScriptDir\Bindings"
$OutputDir = "$ScriptDir\nupkgs"
$InstallDir = "C:\local"

New-Item -ItemType Directory -Force -Path $OutputDir | Out-Null
New-Item -ItemType Directory -Force -Path $InstallDir | Out-Null

function Build-Pack-Install {
    param([string]$Dir)

    $TmpOut = "$OutputDir\$Dir"
    New-Item -ItemType Directory -Force -Path $TmpOut | Out-Null

    Write-Host "Building $Dir..."
    dotnet build "$BindingsRoot\$Dir" -c Release

    Write-Host "Packing $Dir..."
    dotnet pack "$BindingsRoot\$Dir" -c Release --no-build -o $TmpOut

    Write-Host "Installing $Dir to $InstallDir..."
    Copy-Item -Force "$TmpOut\*.nupkg" $InstallDir
}

# Build in dependency order: Internal first, then Core, then the rest
Build-Pack-Install "Internal"
Build-Pack-Install "Core"

$RemainingDirs = @(
    "DatadogLogs"
    "Ndk"
    "Rum"
    "SessionReplay"
    "SessionReplay.Material"
    "Trace"
    "Trace.Otel"
    "WebView"
)

foreach ($Dir in $RemainingDirs) {
    Build-Pack-Install $Dir
}

Write-Host ""
Write-Host "Done. Android packages installed in $InstallDir`:"
Get-Item "$InstallDir\Bcr.Datadog.Android.*.nupkg" | Select-Object -ExpandProperty Name
