# JugueteriaTesApi

Este proyecto fue generado con [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) versión 6.

## Creación de DB, tablas y procedimientos almacenados

En una instancia de base de datos, para facilitar el proceso con la versión más reciente de  [SQL Server Managent Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) ejecutar los scripts `tabla_productos.sql`, `producto_insertar_actualizar_eliminar.sql`, `producto_obtener.sql` que se encuentran en `ugueteriaTestApi\prueba-frontend-querys`; en ese orden.

## Información importante
Una vez que se ejecuten los queries, cambiar `ConnectionStrings` en `JugueteriaTestApi\JugueteriaTestApi\appsettings.json`
por las credenciales de la instancia. Ejemplo: `Server=localhost;Database=Prueba;Integrated Security=True; Encrypt=False`.

## Servidor de desarrollo

Con la versión más reciente de [Visual Studio](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false), abrir la solución y ejecutar el servidor de pruebas con `F5`.
Y listo! la aplicación debería funcionar.