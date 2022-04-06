# $Env:API_LOGIN = "enter-your-api-login-here"
# $Env:API_PASSWORD = "enter-your-api-password-here"

$ErrorActionPreference = "Stop";

New-Item -ItemType Directory -Force -Path ./nuget

# build
Push-Location ./src/Bambins.ApiShip
dotnet build -c Release
Pop-Location

# test
Push-Location ./src/Bambins.ApiShip.Tests
dotnet test -c Release
Pop-Location

# pack
Push-Location ./src/Bambins.ApiShip
dotnet pack -c Release -o ../../nuget --no-build
Pop-Location