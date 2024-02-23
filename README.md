# Heig.VehicleControl

# How to use:
You will need the latest Visual Studio 2022 and the latest .NET Core SDK.
Please check if you have installed the same runtime version (SDK) described in global.json
The latest SDK and tools can be downloaded from https://dot.net/core.

You will need a instance of SQL Server acessible from your machine.

Inside Visual Studio setup WebApi as your main project and Run this to create the script from database

dotnet ef migrations add Initial --context VehicleControlContext --project ../Heig.VehicleControl.Infra/Heig.VehicleControl.Infra.csproj

dotnet ef migrations script --context VehicleControlContext --project ../Heig.VehicleControl.Infra/Heig.VehicleControl.Infra.csproj -o script.sql


# Technologies implemented:
- ASP.NET 8.0
- ASP.NET WebApi Core with JWT Bearer Authentication
- ASP.NET Identity Core ([doc](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-8.0))
- Entity Framework Core 8.0
- .NET Core Native DI
- AutoMapper
- FluentValidation
- MediatR
- Swagger UI with JWT support

# Architecture:
- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Notification
- Domain Validations
- CQRS (Imediate Consistency)
- Unit of Work
- Repository
