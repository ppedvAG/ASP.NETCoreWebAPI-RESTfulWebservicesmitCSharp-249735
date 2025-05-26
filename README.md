# ASP.NET Core WebAPI  -RESTful Webservices mit C#
---
KursRepository zu Kurs ASP.NET Core Web API - RESTful Webservices mit C# der ppedv AG

## Modul 001 Einführung WebAPI

-	[ ] WheaterForecastAPI erstellt
-	[ ] Projektstruktur erklärt
-	[ ] [httpFiles](https://learn.microsoft.com/en-us/aspnet/core/test/http-files)

## Modul 002 Konfiguration

-	[ ] IOC mittels Dependency Injection
	- ServiceCollection
	- Dependency Tree
-	[ ] Logging in ASP.Net Core
	- Serilog, FileSink, OpenTelemetry
	- OpenTelemetry und datalust/seq

## Modul 003 Services & Controllers

-	[ ] BusinessLogic Class Library Project erstellt
	- Service und Domain Model
	- Contracts
-	[ ] Controller mit CRUD Operationen
	- Route constraints
	- [Model Binding](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/)
-	[ ] LAB: Movie Store Api

## Modul 004 MediaTypes & Dto Mapping

-	[ ] MediaTypes & [Formatters](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/media-formatters)
	- ActionResults als JSON, XML und CSV
-	[ ] Best Practices: DTOs, Mapper
-	[ ] ModelState & Validation Attributes
-	[ ] LAB: Movie Store Refactoring


## Modul 005 EF Core, Async/Await

-	[ ] Code First: VehicleManagement Datenbank
-	[ ] Datenklasse mit Attriuten versetzt
-	[ ] DbContext & Seeding
-	[ ] Abhängigkeiten via DI registriert
-	[ ] Async/Await Pattern
-	[ ] LAB: DB für Movie Store erstellen

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add myInitialScript --project myProject
dotnet ef database update --project myProject
```
Alternativ DB erzeugen via Package Manager Console
```
Add-Migration MyInitialScriptName [-Context VehicleDbContext]
Update-Database [-Context VehicleDbContext]
```

-	[ ] Db First: Northwind Datenbank
-   [ ] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)
-	[ ] VS Extension [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
-	[ ] Controller erzeugen
-	[ ] LAB: Daten von Northwind abfragen
		* Alle Bestellungen
		* Alle Bestellungen innerhalb eines Zeitraumes (Parameter: StartDate, EndDate)
		* Bestellungen pro Kunde (Parameter: CustomerID)
		* Kunden pro Land (Parameter: Country)

## Modul 006 Testing

-	[ ] [Überblick Strategien](https://learn.microsoft.com/de-de/ef/core/testing/)
-	[ ] [Unit Testing Controllers](https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api)
-	[ ] Moq benutzen um Controller Dependencies zu mocken
-	[ ] LocalDB benutzen

## Modul 007 HttpClient

-	[ ] Console App welche Anfragen auf die Northwind API macht
-	[ ] Response als JSON deserialisieren

## Modul 008 Authentication

-	[ ] Middleware für Authentication konfigurieren
-	[ ] IdentityDbContext verwenden
-	[ ] JwtToken erstellen

-	[ ] Authentication mit Microsoft Identity Platform via Entra (ehem. Azure AD)
-	[ ] [Client Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
-	[ ] [Graph Explorer](https://developer.microsoft.com/en-us/graph/graph-explorer)

	
## Modul 009 OData

-	[ ] OData Abfragen auf VehicleManagement
-	[ ] LAB: OData Abfragen auf Northwind
