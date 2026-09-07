# CodeBuddies — padrão do professor

Projeto ASP.NET Core MVC + Entity Framework Core + SQL Server.

## Requisitos
- .NET 10 SDK
- SQL Server Express (`.\\SQLEXPRESS`) ou ajuste da connection string
- PowerShell

## 1. Restaurar
```powershell
dotnet restore
```

## 2. Instalar/atualizar EF CLI
```powershell
dotnet tool install --global dotnet-ef
# se já existir:
dotnet tool update --global dotnet-ef
```

## 3. Criar o banco com Migrations
Se esta for a primeira execução:
```powershell
dotnet ef migrations add ModelagemCompleta
dotnet ef database update
```

Se você recebeu uma pasta Migrations pronta e quiser recriar tudo do zero em desenvolvimento:
```powershell
dotnet ef database drop -f
Remove-Item -Recurse -Force .\Migrations
dotnet ef migrations add ModelagemCompleta
dotnet ef database update
```

## 4. Executar
```powershell
dotnet build
dotnet run
```

Abra a URL exibida no terminal.

## 5. Ordem para testar os relacionamentos
1. Cadastre um Professor.
2. Cadastre um Aluno e selecione o Professor.
3. Cadastre uma Fase do Jogo.
4. Cadastre um Progresso e selecione Aluno + Fase.
5. Cadastre um Ranking para o Aluno.

## Estrutura
- Models: 5 entidades relacionadas.
- Data: CodeBuddiesContext.
- Controllers: CRUD das 5 entidades.
- Views: Index/Create/Edit/Details/Delete.
- Migrations: geradas pelo EF Core.

## Connection String
Por padrão:
`Server=.\\SQLEXPRESS;Database=CodeBuddiesDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true`

Se seu SQL Server for LocalDB, use:
`Server=(localdb)\\MSSQLLocalDB;Database=CodeBuddiesDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true`
