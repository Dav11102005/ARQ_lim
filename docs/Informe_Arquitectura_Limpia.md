# Informe de Arquitectura Limpia

## 1. Introducción

La arquitectura limpia busca separar responsabilidades para que cada capa del sistema tenga un propósito claro. Esto reduce el acoplamiento, mejora la mantenibilidad y facilita la evolución del código a medida que cambian los requisitos.

En una solución C#, esto se suele reflejar con capas como:

- Domain: entidades y reglas del negocio.
- Application: casos de uso y validación de la lógica de negocio.
- Infrastructure: acceso a datos y servicios externos.
- WebApi: entrada HTTP que consume la aplicación.

## 2. Problema identificado

El proyecto inicial tenía varios puntos típicos de una arquitectura débil:

- lógica de validación mezclada dentro del servicio;
- responsabilidades no claramente separadas;
- mayor complejidad en el servicio;
- dificultades para realizar análisis de calidad y pruebas unitarias.

## 3. Cambios aplicados

Se refactorizó la solución para mejorar el diseño:

- Se separó la validación de la lógica del servicio mediante un validador específico.
- Se mantiene el servicio enfocado en coordinar acciones y delegar responsabilidades.
- Se conserva la dependencia hacia el dominio y la capa de aplicación, evitando acoplamientos innecesarios.
- Se deja configurado el proyecto para análisis estático con SonarQube.

## 4. Relación con Clean Architecture

Estos cambios alinean el proyecto con principios clave de Clean Architecture:

- separación de responsabilidades;
- dependencia de abstracciones;
- reducción del acoplamiento entre capas;
- mejor capacidad de prueba y evolución.

## 5. Métricas de SonarQube

SonarQube ayuda a revisar los siguientes indicadores importantes:

- code smells;
- complejidad cognitiva;
- duplicación;
- deuda técnica;
- calidad general de mantenibilidad.

La intención de este proyecto es que esos indicadores disminuyan conforme se refactoriza el código y se mejora la estructura.

## 6. Conclusión

Aplicar Clean Architecture no solo ordena el proyecto, sino que mejora la calidad, la sostenibilidad y la evolución del sistema. Al combinar esta estrategia con métricas de SonarQube, se obtiene una visión más clara de qué aspectos necesitan refactorización para llegar a un software más robusto y profesional.
