
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GrpcServices/AssetGrpc/AssetGrpc.csproj", "GrpcServices/AssetGrpc/"]
RUN dotnet restore "GrpcServices/AssetGrpc/AssetGrpc.csproj"
COPY . .
WORKDIR "/src/GrpcServices/AssetGrpc"
RUN dotnet build "AssetGrpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AssetGrpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssetGrpc.dll"]