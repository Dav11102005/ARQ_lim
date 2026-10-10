# BadCleanArch

Repositorio de ejemplo para una solución C# aplicando principios de Clean Architecture.

## Objetivo

Esta solución separa las responsabilidades en capas para mejorar la calidad, mantenibilidad y evolución del software. El proyecto incluye:

- Domain: entidades, reglas del negocio y contratos.
- Application: casos de uso, validaciones y servicios.
- Infrastructure: implementación de repositorios y persistencia.
- WebApi: capa HTTP para exponer la funcionalidad.

## Ejecución

```bash
dotnet restore
dotnet build
```

```bash
dotnet run --project src/WebApi/WebApi.csproj
```

## Análisis con SonarQube

El proyecto está preparado para análisis estático con SonarQube mediante `sonar-project.properties` y configuración de analizadores.
