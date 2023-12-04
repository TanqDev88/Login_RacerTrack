# Proyect RacerTrack
>  In this repository there is the project corresponding to a management system for a car park that has free lane functionality.
---


![Image text](https://i0.wp.com/www.revistaracingcar.com/wp-content/uploads/2015/10/TC-2000-FOTO-PRESENTACION.jpg)

## Content
* [General information](#introduccion)
* [Technologies](#technologies)
* [Project installation](#installation)
---


<a name="introduccion"></a> 


## Project status 🚧 
<details>
    <summary>Click Here for Detail ↩️</summary>
    <br>
   <p align="justify">The project is currently in development. Although the main management functionalities of Drivers, Tracks, Garages, Vehicles and authentication are already ready, along with the main functionality which is the free track calculator, with respect to security, in the short term an ABM will be developed that will allow the creation of different roles to enter the system and restrict functionalities based on these🔨 </p>
   </details>
   <hr>


 <a name="preguntas"></a> 
<a name="technologies"></a> 
   ## Used technology  💻 
   
<details>
    <summary>Click Here for Detail ↩️</summary>
    <br>
   <p>Used technology:</p>
<ul>
    <li>CSS: <a href="https://lenguajecss.com/css/">Link to the official language documentation</a></li>
  <li>HTML5: <a href="https://lenguajehtml.com/html/">Link to the official language documentation</a></li>
    <li>C#: <a href="https://docs.microsoft.com/en-us/dotnet/csharp/">Link to the official language documentation</a></li>
  <li>VS Code: <a href="https://code.visualstudio.com/">Link to the official page</a></li>
  <li>Bootstrap: <a href="https://getbootstrap.com/docs/">ELink to the official page</a></li>
  <li>Razor Pages: <a href="https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-5.0">Link to the official page</a></li>
</ul>

   </details>
   <hr>

<a name="installation"></a>    
## Project installation
1 - Clone the project from the following Github URL. 
```
$ git clone https://github.com/Tanqueta88/Login_RacerTrack.git

```
2 - Install the following tools globally:
```
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef

```
3 - Install the following tools locally:
```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

```
4 - From the folder where the project was cloned, run the following command to run it:
```
dotnet run

```

   ## Free-runway calculation  📖🖍️


<details>
    <summary>Click Here for Detail ↩️</summary>
    <br>
   <p>Functionality:</p>
<ul>
  <li>The system has a working calculator although open to future improvements whose operation is as follows:<br>

STEPS<br>
1- Log in to the Racer Track system<br>
2- From the main menu enter the calculator tab.<br>
3- On the calculator screen, complete the following fields:<br>

   - Enter the value in Argentine pesos of the liter of fuel.<br>
   - Enter the consumption in liters per hour of the vehicle (a table with these values will be implemented soon for this functionality)<br>
   - Select the competition category of the vehicle to use among the following: . Single-seater (Adds $3000 to the hourly value). GT (Adds $4000 to the hourly value) . Track Tourism (Adds $4500 to the hourly value). Stop Car (Adds $5500 to hourly value) . Rally (Add $7000 to hourly value)<br>
   - In the case of hiring an instructor, activate the check (if activated, it adds $5000 to the hourly value)<br>
  
4- To perform the calculation press the calculate button.<br>
5- If you want to make another calculation, press the "Clear" button <br>
6- If you want to return to the main menu, press the "Back" button</a></li><br>
   </ul>

Example case:<br>
to. A fuel cost of 20 is entered with a consumption per hour of 1<br>
b. Select the Single-seat category which adds 3000 to the calculation<br>
c. The assistance of an instructor is requested which adds 5000 to the calculation<br>
d. The cost of the free track hour must be 8020.00<br>
    </details>
    <hr>
