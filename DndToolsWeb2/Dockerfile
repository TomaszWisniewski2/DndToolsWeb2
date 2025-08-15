# Etap 1: Budowanie i publikowanie projektu .NET
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DndToolsWeb2/DndToolsWeb2.csproj", "DndToolsWeb2/"]
RUN dotnet restore "./DndToolsWeb2/DndToolsWeb2.csproj"
COPY . .
WORKDIR "/src/DndToolsWeb2"
RUN dotnet build "./DndToolsWeb2.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/DndToolsWeb2"
RUN dotnet publish "./DndToolsWeb2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etap 2: Finalny obraz produkcyjny
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Dodaj tê liniê, aby skopiowaæ zawartoœæ wwwroot
COPY DndToolsWeb2/wwwroot/ ./wwwroot/
ENTRYPOINT ["dotnet", "DndToolsWeb2.dll"]