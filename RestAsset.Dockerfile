FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RestServices/AssetApi/AssetApi.csproj", "RestServices/AssetApi/"]
RUN dotnet restore "RestServices/AssetApi/AssetApi.csproj"
COPY . .
WORKDIR "/src/RestServices/AssetApi"
RUN dotnet build "AssetApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AssetApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssetApi.dll"]
