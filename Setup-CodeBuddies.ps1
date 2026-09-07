$ErrorActionPreference = "Stop"

Write-Host "=== CodeBuddies - configuração ===" -ForegroundColor Cyan

dotnet --version
if ($LASTEXITCODE -ne 0) { throw "Instale o .NET 10 SDK antes de continuar." }

Write-Host "`nRestaurando pacotes..." -ForegroundColor Yellow
dotnet restore

Write-Host "`nVerificando dotnet-ef..." -ForegroundColor Yellow
dotnet ef --version
if ($LASTEXITCODE -ne 0) {
    dotnet tool install --global dotnet-ef
}

Write-Host "`nCompilando..." -ForegroundColor Yellow
dotnet build

Write-Host "`nCriando migration..." -ForegroundColor Yellow
dotnet ef migrations add ModelagemCompleta

Write-Host "`nAtualizando banco..." -ForegroundColor Yellow
dotnet ef database update

Write-Host "`nConcluído. Para executar:" -ForegroundColor Green
Write-Host "dotnet run" -ForegroundColor White
