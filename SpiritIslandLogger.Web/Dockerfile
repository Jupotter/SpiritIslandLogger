#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["SpiritIslandLogger.Web/SpiritIslandLogger.Web.csproj", "SpiritIslandLogger.Web/"]
RUN dotnet restore "SpiritIslandLogger.Web/SpiritIslandLogger.Web.csproj"
COPY . .
WORKDIR "/src/SpiritIslandLogger.Web"
RUN dotnet build "SpiritIslandLogger.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpiritIslandLogger.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpiritIslandLogger.Web.dll"]