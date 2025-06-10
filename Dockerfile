# Etapa 1: build com SDK e dotnet-ef
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copia os arquivos do projeto
COPY . .

# Instala a ferramenta dotnet-ef globalmente
RUN dotnet tool install --global dotnet-ef

# Adiciona o diretório das ferramentas globais ao PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Restaura as dependências
RUN dotnet restore

# (Opcional) Rodar migrações aqui, se desejar
# RUN dotnet ef migrations add MinhaMigrationInicial

# Publica o projeto
RUN dotnet publish -c Release -o /app

# Etapa 2: runtime com ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development

# Copia o build publicado
COPY --from=build /app .

# Define o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "Projeto_Aplicado_II_API.dll"]
