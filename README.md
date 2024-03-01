# Proyecto Racer Track
***

![Image text](https://www.competirclaroquesi.com.ar/images/Emiliozzi_1.jpg)

In this repository there is the project corresponding to the second partial, it consists of a management system for a car dome that has free lane functionality.

## Content
1. [General information](#general-info)
2. [Technologies](#technologies)
3. [Installation](#installation)
4. [Use of search engines](#search)
5. [Functionality](#functionality)
6. [Role Management](#roles)


<a name="general-info"></a>
## General information
***
The application belonging to the "Racer Track" autodrome aims to manage tracks and list drivers/vehicle owners for use within the autodrome (from their personal data to the assignment of vehicles, tracks and garages. The project is still still in the development process but it already has the following ABM where you can create, edit, observe details and delete records, a user authentication and registration functionality, reaching the development of a cost calculation functionality for the use of the track free for hours.

## Project Status 🚧
<details>
     <summary>Click Here for Detail ↩️</summary>
     <br>
    <p align="justify">The project is currently in development. Although the main management functionalities of Drivers, Tracks, Garages, Vehicles and authentication are already ready, along with the main functionality, which is the free track calculator, with respect to security, in the short term an ABM will be developed that will allow the creation of different roles to enter the system and restrict functionalities based on these🔨 </p>
    </details>
    <hr>

   ## Technologies Used 💻
   
<details>
    <summary>Click Here for Detail ↩️</summary>
    <br>
   <p>Technologies Used:</p>
<ul>
  <li>Bootstrap: <a href="https://getbootstrap.com/docs/">Link to official documentation</a></li>
   <li>Razor Pages: <a href="https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-5.0">Link to official documentation</a> </li>
   <li>C#: <a href="https://docs.microsoft.com/en-us/dotnet/csharp/">Link to official documentation</a></li>
</ul>

   </details>
   <hr>

 <a name="installation"></a>  
## Project installation
***
Clone the project from the following Github URL.
```
$ git clone https://github.com/jorgedan88/herramientas-parcial1-OliveraJorgeDaniel.git

```

Install the following tools globally:
```
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef

```
Install the following tools locally:
```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

```
From the folder where the project was cloned, run the following command to run it.
```
dotnet run

```

<a name="search"></a> 
   ## Uso de buscadores  💻 
   
<details>
    <summary>Click Aquí para Detalle ↩️</summary>
    <br>
   <p>Funcionamiento de buscadores por ABM:</p>
<ul>
  <li>Pantalla Pilotos:</li>
    - Filtra por nombre (case sensitive), apellido (case sensitive) y DNI (Valor exacto)
  <li>Pantalla Vehiculos:</li>
    - Funciona por Tipo de vehículo  (case sensitive) y Matrícula (Valor exacto) 
  <li>Pantalla Cocheras:</li>
    - Funciona por Nombre (case sensitive) y Numero (Valor exacto)
  <li>Pantalla Pistas:</li>
    - Funciona por Nombre (case sensitive) y Nomenclatura (Valor exacto)
</ul>

   </details>
   <hr>


 <a name="functionality"></a>  
   ## Calculo de pista libre  📖🖍️


<details>
    <summary>Click Aquí para Detalle ↩️</summary>
    <br>
   <p>Funcionalidad:</p>
<ul>
  <li>El sistema cuenta con una calculadora en funcionamiento aunque abierta a mejoras a futuro cuyo funcionamiento es el siguiente:<br>
  
  PASOS<br>
1- Loguearse en el sistema Racer Track<br> 
2- Desde el menu principal ingresar a la pestaña calculadora.<br> 
3- En la pantalla calculadora campletar los siguientes campos:<br>

  - Ingresar el valor en pesos Argentinos del litro de combustible.<br>
  - Ingresar el consumo en litros por hora del vehiculo (proximamente se implementara una tabla con estos valores para esta funcionalidad)<br>
  - Seleccionar la categoria de competición del vehiculo a utilizar entre las siguientes: . Monoplaza (Agrega $3000 al valor hora) . GT (Agrega $4000 al valor hora) . Turismo Pista     (Agrega $4500 al valor hora) . Stop Car (Agrega $5500 al valor hora) . Rally (Agrega $7000 al valor hora)<br>
  - En el caso de contratar un instructor activar el check (el mismo de estar activado agrega $5000 al valor hora)<br>
  
4- Para realizar el calculo presione el botón calcular.<br> 
5- Si se decea realizar otro calculo presionar el boton "Limpiar" <br>
6- Si se desea volver al menu principal presionar el boton "Volver"</a></li><br>
  </ul>

Caso ejemplo:<br>
a. Se ingresa un costo de combustible de 20 con un consumo por hora de 1<br>
b. Se seleccionar la categoria Monoplaza la cual le agrega al cálculo 3000<br>
c. Se solicita la asistencia de un instructor lo cual le agrega al cálculo 5000<br>

d. El costo de la hora de pista libre debe ser de 8020.00<br>
   </details>
   <hr>

 <a name="roles"></a>  
   ## Gestion de roles para usuarios del sistema  💻 
   
<details>
    <summary>Click Aquí para Detalle ↩️</summary>
    <br>
   <p>Roles disponibles en el sistema:</p>
<ul>
    <strong> Importante: Al crear un nuevo usuario para que el mismo tenga acceso a los módulos del sistema un administrador deberá asignarle un rol. </strong><br>
    
<li>Propietario:</li>
    - Rol que permite al usuario el acceso total a todos lo módulos del sistema y ejecutar todas las acciones de estas pantallas.
<li>Encargado de pista:</li>
    - Rol que permite al usuario el acceso a los módulos Pilotos, Vehículos, Cocheras y Pistas con ejecución de todas las acciones de los ABM’s de estas pantallas.
<li>Administrador:</li>
    - Solo permite el acceso a los módulos Pilotos y Vehículos pero no la creación o edición de los registros de estas pantallas (Usuario del tipo consulta)
</ul>

   </details>
   <hr>

 ## 💻 Usuarios para pruebas:

ADMINISTRADOR:
USER:admin@adimn.com
PASS:PmU3.UCj3pPt-rp
JEFE DE PISTA:
USER:hp@gmail.com
PASS:.w_Q93GWDNJvivu
PROPIETARIO:
USER:owner@owner.com
PASS: 3KTU_Ffub5s-ZFd


