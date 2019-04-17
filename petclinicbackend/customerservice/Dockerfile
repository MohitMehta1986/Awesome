FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
RUN ls -a

COPY petclinicmicroservice.csproj petclinicmicroservice/
WORKDIR /src/petclinicmicroservice

RUN dotnet restore
COPY . ./

WORKDIR /src/petclinicmicroservice
#RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "petclinicmicroservice.dll"]