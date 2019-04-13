FROM microsoft/aspnetcore AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build AS build
WORKDIR /src
COPY *.sln ./
COPY customerservice/petclinicmicroservice.csproj petclinicmicroservice/
RUN dotnet restore
COPY . .
WORKDIR /src/petclinicmicroservice
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "petclinicmicroservice.dll"]
