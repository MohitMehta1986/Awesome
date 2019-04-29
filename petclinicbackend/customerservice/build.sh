#!/bin/bash
set -ev
dotnet restore
dotnet build -c Release
