# Proyecto Aeroclub rio de la plata
***
![Image text](https://static.wixstatic.com/media/279b70_07d1f5ba938e4f0fa2fa745371a35533.jpg)
En este repositorio se encuentra el proyecto correspondiente al primer parcial, el mismo consiste en un sistema de gestion de instructores de vuelo.

## Contenido
1. [Informacion general](#general-info)
2. [Tecnologias](#technologies)
3. [Instalacion](#installation)


## Informacion General 
***
La aplicación perteneciente al aeroclub del río de la plata tiene como objetivo la gestión de la nomina de instructores de vuelo desde sus datos personales hasta la asignación de aeronaves a los mismos.  El proyecto se encuentra aun aun en proceso de desarrollo llegando hasta la conexión del mismo su propia base de datos. 
### Menu principal

![Image text](https://github.com/jorgedan88/ProyectoPrimerParcial/blob/main/Resources/Index.jpg);

### Pantalla agregar instructor
![Image text](https://github.com/jorgedan88/ProyectoPrimerParcial/blob/main/Resources/Crear.jpg)


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
$ git clone https://github.com/jorgedan88/ProyectoPrimerParcial.git

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
