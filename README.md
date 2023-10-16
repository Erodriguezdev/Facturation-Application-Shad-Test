# Facturation-Application-Shad-Test

Esta es una aplicación de facturación desarrollada en .NET Core 7 que utiliza Entity Framework Core 7 para la gestión de datos y Microsoft SQL Server como base de datos.

## Diagrama de datos
![Facturacion_Shad drawio](https://github.com/Erodriguezdev/Facturation-Application-Shad-Test/assets/61694328/d4a99525-6f53-4bd4-8dce-4761440071f7)


## Requisitos

Para utilizar esta aplicación, asegúrate de tener instalados los siguientes requisitos:

- .NET Core 7: Descarga e instala .NET Core 7 desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/7.0).

- Entity Framework Core 7: La aplicación utiliza Entity Framework Core 7 como ORM para la gestión de datos. Puedes instalarlo a través de NuGet.

- Microsoft SQL Server: Debes tener una instancia de Microsoft SQL Server en funcionamiento. Asegúrate de que la cadena de conexión de la base de datos en la aplicación esté configurada correctamente.

## Configuración

Antes de ejecutar la aplicación, asegúrate de configurar la cadena de conexión de la base de datos en el archivo `appsettings.json`. Aquí tienes un ejemplo de cómo se vería la sección de configuración de la base de datos:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=tu_servidor_sql;Database=nombre_de_la_base_de_datos;User Id=usuario;Password=contraseña;"
}

Diagrama base de datos

[Facturacion_Shad drawio](https://github.com/Erodriguezdev/Facturation-Application-Shad-Test/assets/61694328/1b4e9306-eafd-4e3e-966c-1b9d6ceab877)

Desarrollado por Ezequiel Rodriguez
