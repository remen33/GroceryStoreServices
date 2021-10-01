#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GroceryStoreServices.Api.Author.Tests/GroceryStoreServices.Api.Author.Tests.csproj", "GroceryStoreServices.Api.Author.Tests/"]
RUN dotnet restore "GroceryStoreServices.Api.Author.Tests/GroceryStoreServices.Api.Author.Tests.csproj"
COPY . .
WORKDIR "/src/GroceryStoreServices.Api.Author.Tests"
RUN dotnet build "GroceryStoreServices.Api.Author.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroceryStoreServices.Api.Author.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroceryStoreServices.Api.Author.Tests.dll"]
