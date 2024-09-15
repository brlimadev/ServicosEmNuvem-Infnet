# Usando a imagem base do ASP.NET Core para a fase de runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://*:80

# Usando a imagem base do SDK do .NET para a fase de build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copie o arquivo de projeto e restaure as dependências
COPY ["SpotifyLike.STS/SpotifyLike.STS.csproj", "SpotifyLike.STS/"]
RUN dotnet restore "SpotifyLike.STS/SpotifyLike.STS.csproj"

# Copie o restante do código-fonte e compile o projeto
COPY . .
WORKDIR "/src/SpotifyLike.STS"
RUN dotnet build "SpotifyLike.STS.csproj" -c Release -o /app/build

# Publicar a aplicação em um diretório específico
FROM build AS publish
RUN dotnet publish "SpotifyLike.STS.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Configuração final da imagem
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpotifyLike.STS.dll"]
