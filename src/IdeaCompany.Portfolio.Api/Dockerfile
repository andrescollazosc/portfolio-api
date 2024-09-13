FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IdeaCompany.Portfolio.Api.csproj", "src/IdeaCompany.Portfolio.Api/"]
RUN dotnet restore "src/IdeaCompany.Portfolio.Api/IdeaCompany.Portfolio.Api.csproj"
COPY . .
WORKDIR "/src/src/IdeaCompany.Portfolio.Api"
RUN dotnet build "/src/IdeaCompany.Portfolio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "/src/IdeaCompany.Portfolio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdeaCompany.Portfolio.Api.dll"]
