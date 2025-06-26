:: Configuração do console
@echo off
title Projeto Aplicado II - Docker setup
color 0f

:: Variáveis
set NOME_NETWORK=projeto-aplicado-ii

set NOME_DOCKER_API=projeto-aplicado-ii-api
set PORTA_DOCKER_API=6969

set NOME_DOCKER_BANCO=projeto-aplicado-ii-sqlserver
set PORTA_DOCKER_BANCO=1433

:: Excluir anteriores
echo $ Limpando containers anteriores...

docker stop %NOME_DOCKER_BANCO%
docker rm %NOME_DOCKER_BANCO%

docker stop %NOME_DOCKER_API%
docker rm %NOME_DOCKER_API%

:: Network
docker network rm %NOME_NETWORK%
docker network create %NOME_NETWORK%

:: SQL Server
echo.
echo $ Criando o container do SQL Server...

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Gabriel@13242872924" -p %PORTA_DOCKER_BANCO%:%PORTA_DOCKER_BANCO% --network %NOME_NETWORK% --name %NOME_DOCKER_BANCO% -d mcr.microsoft.com/mssql/server:2019-latest

echo.
echo $ Aguardando a inicializacao do SQL Server...
:aguardando_banco
docker logs %NOME_DOCKER_BANCO% 2>&1 | findstr /C:"Recovery is complete." >nul

if errorlevel 1 (
    timeout /t 1 >nul
    goto aguardando_banco
)

:: API
echo.
echo $ Criando o container da API...

docker build -t %NOME_DOCKER_API%:latest .
docker run -d -p %PORTA_DOCKER_API%:%PORTA_DOCKER_API% --network %NOME_NETWORK% --name %NOME_DOCKER_API% %NOME_DOCKER_API%

:: Fim
echo.
echo $ Containers inicializados com sucesso!

pause
