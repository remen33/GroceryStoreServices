#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GroceryStoreServices.Api.Autor/GroceryStoreServices.Api.Autor.csproj", "GroceryStoreServices.Api.Autor/"]
RUN dotnet restore "GroceryStoreServices.Api.Autor/GroceryStoreServices.Api.Autor.csproj"
COPY . .
WORKDIR "/src/GroceryStoreServices.Api.Autor"
RUN dotnet build "GroceryStoreServices.Api.Autor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroceryStoreServices.Api.Autor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroceryStoreServices.Api.Autor.dll"]