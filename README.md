# Documentación del Proyecto Backend

## Introducción

En esta documentación se proporciona una visión general del proyecto Backend desarrollado utilizando una arquitectura hexagonal. Se detallan la estructura del proyecto, los componentes principales y las tecnologías utilizadas.

## Arquitectura

El proyecto sigue una arquitectura hexagonal, también conocida como puertos y adaptadores, que se caracteriza por su enfoque en la separación de la lógica de negocio de los detalles técnicos de implementación y las interfaces de entrada y salida.

## Estructura del Proyecto

El proyecto está estructurado en varias capas, cada una con una responsabilidad específica:

- **Controladores**: Puntos de entrada para las solicitudes HTTP.
- **Servicios**: Contienen la lógica de negocio de la aplicación.
- **Repositorios**: Interfaz para acceder a los datos, proporcionando una capa de abstracción sobre el almacenamiento.
- **Mapeadores**: Se encargan de mapear los objetos de dominio a DTOs (Data Transfer Objects) y viceversa.

## Componentes Principales

### Controladores:
- **EmployeeController**: Gestiona las solicitudes relacionadas con los empleados.

### Servicios:
- **EmployeeService**: Contiene la lógica para obtener y manipular datos de empleados.

### Repositorios:
- **ApiClientEmployeeRepository**: Interactúa con una API externa para obtener datos de empleados.

## Integración con Servicios Externos

El proyecto se integra con servicios externos, como una API de empleados, a través de adaptadores específicos que interactúan con estos servicios y proporcionan una capa de abstracción sobre su funcionalidad.

## Configuración e Instalación

### Requisitos Previos
Antes de comenzar, asegúrate de tener instalado lo siguiente en tu entorno de desarrollo:
- [.NET Core SDK](https://dotnet.microsoft.com/download) - para compilar y ejecutar el proyecto.

### Configuración del Proyecto
1. Clona el repositorio del proyecto desde GitHub:
   ```
   git clone https://github.com/Sebastian2759/Empleados.git
   ```
2. Navega al directorio del proyecto:
   ```
   cd tu-proyecto-backend
   ```
3. Abre el proyecto en tu entorno de desarrollo preferido (por ejemplo, Visual Studio Code).

Con esto, el proyecto estará configurado y listo para ser ejecutado en tu entorno de desarrollo local.

## Ejecución del Proyecto

Para ejecutar el proyecto, sigue los pasos de Configuración e Instalación y luego inicia el servidor local utilizando el comando `dotnet run`.

## Ejecución de Pruebas

Para ejecutar las pruebas unitarias y de integración del proyecto, sigue los pasos de Configuración e Instalación y luego utiliza el comando `dotnet test`.

Gracias.
