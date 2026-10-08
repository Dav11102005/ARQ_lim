# Repositorio para ejercicio de Clean Architecture en C#

## Objetivo
Este repositorio contiene una solución de ejemplo basada en arquitectura limpia para una API de productos. La estructura separa dominio, aplicación, infraestructura y capa web.

## Estructura
- `src/Domain`: entidades y contratos del dominio.
- `src/Application`: casos de uso, servicios y DTOs.
- `src/Infrastructure`: implementaciones de persistencia en memoria.
- `src/WebApi`: API REST con ASP.NET Core.

## Ejecución
```bash
dotnet restore
dotnet build
dotnet run --project src/WebApi/WebApi.csproj
```

## Endpoints principales
- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`

## Calidad
El proyecto incluye una configuración mínima para análisis estático con SonarQube.
