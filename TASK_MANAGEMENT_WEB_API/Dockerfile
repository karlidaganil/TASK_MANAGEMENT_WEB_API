FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TASK_MANAGEMENT_WEB_API/TASK_MANAGEMENT_WEB_API.csproj", "TASK_MANAGEMENT_WEB_API/"]
RUN dotnet restore "TASK_MANAGEMENT_WEB_API/TASK_MANAGEMENT_WEB_API.csproj"
COPY . .
WORKDIR "/src/TASK_MANAGEMENT_WEB_API"
RUN dotnet build "./TASK_MANAGEMENT_WEB_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TASK_MANAGEMENT_WEB_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TASK_MANAGEMENT_WEB_API.dll"]
