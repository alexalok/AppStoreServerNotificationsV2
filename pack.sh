#!/bin/sh

DOTNET_EXE='dotnet'
$DOTNET_EXE 2>/dev/null || DOTNET_EXE='dotnet.exe'

$DOTNET_EXE pack ./AppStoreServerNotificationsV2/AppStoreServerNotificationsV2.csproj \
 -c release --include-source --include-symbols -o ./output