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

<a name="technologies"></a>
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
## Use of search engines 💻 
   
<details>
<summary>Click Here for Detail ↩️</summary>
    <br>
<p>Operation of search engines by ABM:</p>
<ul>
   <li>Pilots Screen:</li>
     - Filter by first name (case sensitive), last name (case sensitive) and DNI (exact value)
   <li>Vehicles Screen:</li>
     - Works by Vehicle Type (case sensitive) and License Plate (exact value)
   <li>Garage Screen:</li>
     - Works by Name (case sensitive) and Number (exact value)
   <li>Tracks Screen:</li>
     - Works by Name (case sensitive) and Nomenclature (exact value)
</ul>

   </details>
   <hr>


 <a name="functionality"></a>  
## Free runway calculation 📖🖍️


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

 <a name="roles"></a>  
## Role management for system users 💻
   
<details>
     <summary>Click Here for Detail ↩️</summary>
     <br>
    <p>Roles available in the system:</p>
<ul>
     <strong>Important: When creating a new user so that he or she has access to the system modules, an administrator must assign him or her a role. </strong><br>
    
<li>Owner:</li>
     - Role that allows the user full access to all system modules and execute all actions on these screens.
<li>Rink manager:</li>
     - Role that allows the user access to the Drivers, Vehicles, Garages and Tracks modules with execution of all the ABM actions on these screens.
<li>Administrator:</li>
     - Only allows access to the Drivers and Vehicles modules but not the creation or editing of the records of these screens (Query type user)
</ul>

## 💻 Users for testing:

### ADMINISTRATOR:
- **Usuario:** admin@admin.com
- **Contraseña:** PmU3.UCj3pPt-rp

### RINGMASTER:
- **Usuario:** jefe@pista.com
- **Contraseña:** .w_Q93GWDNJvivu

### OWNER:
- **Usuario:** propietario@dominio.com
- **Contraseña:** 3KTU_Ffub5s-ZFd

   </details>
   <hr>




