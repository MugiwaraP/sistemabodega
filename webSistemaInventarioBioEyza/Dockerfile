FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build-env

ARG	soruce
WORKDIR /inetpub/wwwroot
COPY ${source:-bin/app.publish}