#!/bin/bash
set -ev
dotnet restore petclinicbackend/customerservice/petclinicmicroservice.csproj
dotnet build --source petclinicbackend/customerservice/petclinicmicroservice.csproj -c Release
