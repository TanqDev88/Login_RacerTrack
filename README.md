# Proyecto Racer Track
***

![Image text](https://www.competirclaroquesi.com.ar/images/Emiliozzi_1.jpg)

En este repositorio se encuentra el proyecto correspondiente al segundo parcial, el mismo consiste en un sistema de gestion de un autodoromo que cuenta con la funcionalidad de pista libre.

## Contenido
1. [Informacion general](#general-info)
2. [Tecnologias](#technologies)
3. [Instalacion](#installation)
4. [Uso de buscadores](#search)
5. [Funcionalidad](#functionality)
6. [Gestion de roles](#roles)


<a name="general-info"></a>
## Informacion General 
***
La aplicación perteneciente al autodromo "Racer Track" tiene como objetivo la gestión de pistas y  nomina de pilotos/propietarios de vehiculos para su uso dentro del autodromo (desde sus datos personales hasta la asignación de vehiculos, pistas y cocheras.  El proyecto se encuentra aun aun en proceso de desarrollo pero ya cuenta con los siguientes ABM donde se puede crear, editar, observar detalle y eliminar registros, una funcionalidad de autenticacion y registro de usuarios llegando hasta el desarrollo de una funcionalidad de calculo de costos para el uso de la pista libre por horas. 
### Menu principal

## Estado del Proyecto 🚧 
<details>
    <summary>Click Aquí para Detalle ↩️</summary>
    <br>
   <p align="justify">El proyecto se encuentra actualmente en desarrollo. Aunque ya se encuentran listas las funcionalidades principales de administración de Pilotos, Pistas, Cocheras, Vehiculos y autenticacion junto con la funcionalidad principal que es la calculadora de pista libre y , respecto a la seguridad en el corto plazo se desarrollara un ABM que permitira la creacion de distintos roles para ingresar al sistema y restringir funcionalidades en base a estos🔨 </p>
   </details>
   <hr>

<a name="technologies"></a> 
   ## Tecnologías Utilizadas  💻 
   
<details>
    <summary>Click Aquí para Detalle ↩️</summary>
    <br>
   <p>Tecnologías Utilizadas:</p>
<ul>
  <li>Bootstrap: <a href="https://getbootstrap.com/docs/">Enlace a la documentación oficial</a></li>
  <li>Razor Pages: <a href="https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-5.0">Enlace a la documentación oficial</a></li>
  <li>C#: <a href="https://docs.microsoft.com/en-us/dotnet/csharp/">Enlace a la documentación oficial</a></li>
</ul>

   </details>
   <hr>

 <a name="installation"></a>  
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



