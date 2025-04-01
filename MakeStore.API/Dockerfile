# Fase de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos de projeto para o contexto de construção correto
COPY ./MakeStore.API/MakeStore.API.csproj ./MakeStore.API/
COPY ./MakeStore.Application/MakeStore.Application.csproj ./MakeStore.Application/
COPY ./MakeStore.Infrastructure/MakeStore.Infrastructure.csproj ./MakeStore.Infrastructure/
COPY ./MakeStore.Domain/MakeStore.Domain.csproj ./MakeStore.Domain/

# Restaure as dependências
RUN dotnet restore "MakeStore.API/MakeStore.API.csproj"

# Copie o restante dos arquivos e compile
COPY . .
WORKDIR "/src/MakeStore.API"
RUN dotnet build -c Release -o /app/build

# Publicação
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Fase final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MakeStore.API.dll"]
