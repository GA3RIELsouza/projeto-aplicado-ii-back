# Etapa 1: build com SDK e dotnet-ef
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copia os arquivos do projeto
COPY . .

# Instala a ferramenta dotnet-ef globalmente
RUN dotnet tool install --global dotnet-ef

# Adiciona o diretório das ferramentas globais ao PATH
ENV PATH="${PATH}:/root/.dotnet/tools"
ENV ASPNETCORE_ENVIRONMENT=Production

# Restaura as dependências
RUN dotnet restore
RUN dotnet tool restore

# Migrations
RUN dotnet ef migrations add docker_migration
RUN dotnet ef database update

# Publica o projeto
RUN dotnet publish -c Release -o /app

# Etapa 2: runtime com ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app

# Copia o build publicado
COPY --from=build /app .

# Define o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "Projeto_Aplicado_II_API.dll"]
