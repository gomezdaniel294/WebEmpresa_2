# WebEmpresa.Api

La tabla dbo.clientes ya existe en Azure SQL; no hay que crearla.

1. Guardar la cadena de conexión (sin escribir la contraseña en archivos):
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:ConexionSQLServer" "Server=tcp:gsserver1.database.windows.net,1433;Initial Catalog=db_empresa;Persist Security Info=False;User ID=GS_server;Password=NUEVA_PASSWORD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
2. dotnet dev-certs https --trust
3. dotnet run --launch-profile https
4. Probar: https://localhost:7180/api/salud y https://localhost:7180/api/Clientes
