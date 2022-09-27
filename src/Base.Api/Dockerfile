#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ARG ARTIFACTS_ENDPOINT
ARG ACCESS_TOKEN

ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS "{\"endpointCredentials\": [{\"endpoint\":\"${ARTIFACTS_ENDPOINT}\", \"password\":\"${ACCESS_TOKEN}\"}]}"

WORKDIR /build

RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash

COPY *.sln .
COPY nuget.config .

COPY ./src/*/*.csproj ./

RUN for file in $(ls *.csproj); do mkdir -p ./src/${file%.*} && mv ${file} ./src/${file%.*}/${file}; done

RUN dotnet restore

COPY . ./

RUN dotnet build --no-restore -c Release

FROM build AS publish

RUN dotnet publish --no-build -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final

WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Base.dll"]