# Starting from MS's dotnet image that has all the SDKs installed,
# build and unit test the app
#FROM mcr.microsoft.com/dotnet/sdk:7.0.202-bullseye-slim AS build

#COPY . /
#WORKDIR /
#RUN dotnet restore ClientConfiguration.sln

# Build
#RUN dotnet build --configuration Release --no-restore ClientConfiguration.sln

# Create dotnet artifacts
#RUN dotnet publish --no-restore -c Release --output /app ClientConfiguration.sln

# Build the deployment container. Switch base images from 'sdk' to
# 'runtime', and use Apline Linux, to reduce image size
#FROM mcr.microsoft.com/dotnet/sdk:7.0.202-alpine3.17 AS runtime

# Set up the app to run
#WORKDIR /app
#COPY --from=build /app .
#EXPOSE 5000
#ENTRYPOINT ["dotnet", "ClientConfiguration.Api.dll"]

# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0.202-bullseye-slim AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./src/ClientConfiguration.Api/ClientConfiguration.Api.csproj" --disable-parallel
RUN dotnet publish "./src/ClientConfiguration.Api/ClientConfiguration.Api.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0.202-alpine3.17 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
#EXPOSE 5000/tcp
#ENV ASPNETCORE_URLS=http://*:5000

ENTRYPOINT ["dotnet", "ClientConfiguration.Api.dll"]
