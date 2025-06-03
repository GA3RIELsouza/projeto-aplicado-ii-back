# Criar Docker do SQL Server
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Gabriel@13242872924" -p 1433:1433 --name sqlserver-container -d mcr.microsoft.com/mssql/server:2019-latest
```

# Criar Docker da API
```bash
docker build -t projeto-aplicado-ii .
```

# Rodar Docker da API
```bash
docker run -d -p 6969:6969 --name projeto-aplicado-ii-api projeto-aplicado-ii
```


# Auth.BearerToken
bBK=^h$08P0}ci!cStJ85r2jKy&wO,9u

# SQL Server connection string
Data Source=localhost,1433;Initial Catalog=projeto_aplicado_ii;Persist Security Info=True;User ID=sa;Password=Gabriel@13242872924;Encrypt=False;Trust Server Certificate=True

# Gerar migration
```bash
dotnet ef migrations add Migration
```

# Restaurar migration
```bash
dotnet ef database update
```