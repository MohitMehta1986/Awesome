#!/bin/bash
set -ev
dotnet restore petclinicbackend/customerservice/petclinicmicroservice.csproj
dotnet build -c Release
