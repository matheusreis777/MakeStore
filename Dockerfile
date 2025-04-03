# Use a imagem base do SDK do .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos de projeto e restaure as dependências
COPY ["MakeStore.API/MakeStore.API.csproj", "MakeStore.API/"]
COPY ["MakeStore.Application/MakeStore.Application.csproj", "MakeStore.Application/"]
COPY ["MakeStore.Domain/MakeStore.Domain.csproj", "MakeStore.Domain/"]
COPY ["MakeStore.Infrastructure/MakeStore.Infrastructure.csproj", "MakeStore.Infrastructure/"]

RUN dotnet restore "MakeStore.API/MakeStore.API.csproj"

# Copie todo o restante do código
COPY . .

# Compile o projeto
WORKDIR "/src/MakeStore.API"
RUN dotnet build "MakeStore.API.csproj" -c Release -o /app/build

# Publique o projeto
FROM build AS publish
RUN dotnet publish "MakeStore.API.csproj" -c Release -o /app/publish

# Use uma imagem base do ASP.NET para o ambiente de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MakeStore.API.dll"]
