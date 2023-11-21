# Proyecto Racer Track
***
![Image text](https://static.wixstatic.com/media/279b70_07d1f5ba938e4f0fa2fa745371a35533.jpg)
En este repositorio se encuentra el proyecto correspondiente al segundo parcial, el mismo consiste en un sistema de gestion de un autodoromo que cuenta con la funcionalidad de pista libre.

## Contenido
1. [Informacion general](#general-info)
2. [Tecnologias](#technologies)
3. [Instalacion](#installation)


## Informacion General 
***
La aplicación perteneciente al autodromo "Racer Track" tiene como objetivo la gestión de pistas y  nomina de pilotos/propietarios de vehiculos para su uso dentro del autodromo (desde sus datos personales hasta la asignación de vehiculos, pistas y cocheras.  El proyecto se encuentra aun aun en proceso de desarrollo pero ya cuenta con los siguientes ABM donde se puede crear, editar, observar detalle y eliminar registros, una funcionalidad de autenticacion y registro de usuarios llegando hasta el desarrollo de una funcionalidad de calculo de costos para el uso de la pista libre por horas. 
### Menu principal

### Pantalla agregar piloto:


## Tecnologias
***
Las tecnologias aplicadas en el proyecto son las siguientes:
* [Dotnet](https://dotnet.microsoft.com/en-us/download): Version 7.0.203 
* [Dotnet SDK](https://example.com): Version 7.0
.203
* [Entity framework core](https://learn.microsoft.com/en-us/ef/core/): Version 8.0

## Instalacion del proyecto
***
Clonar el proyecto desde la siguiente URL de Github. 
```
$ git clone https://github.com/jorgedan88/herramientas-parcial1-OliveraJorgeDaniel.git

```

Instalar las siguientes herramientas de manera global:
```
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef

```
Instalar las siguientes herramientas de manera local:
```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

```
Desde la carpeta donde se clono el proyecto ejecutar el siguiente comando para ejecutarlo. 
```
dotnet run

```
