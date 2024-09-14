#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SpotifyLike.STS/SpotifyLike.STS.csproj", "SpotifyLike.STS/"]
RUN dotnet restore "SpotifyLike.STS/SpotifyLike.STS.csproj"
COPY . .
WORKDIR "/src/SpotifyLike.STS"
RUN dotnet build "SpotifyLike.STS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpotifyLike.STS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpotifyLike.STS.dll"]