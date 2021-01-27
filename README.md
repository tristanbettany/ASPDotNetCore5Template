# ASPDotNetCore5Template

This is a template to get started making an MVC ASP website using .NET Core 5 written in C#.

The standard template that comes out of the box from visual studio is ok but needs some love.

Instead of bootstrap this uses tailwind, and jquery is simply ripped out because... yuck!

Structure and organisation of all the files has been refactored.

This contains integration with Azure microsoft login which you can manage by adding your azure application credentials
in the secrets, alternativley you can remove the integration from the services in the startup file.

> Failure to setup your Azure application credentials or remove the integration means you will get errors when starting the website

This contains a seperate project in the solution as the database layer which you can remove if you arent using 
a database by deleting the lines from the services in the startup file, and removing references.

## Getting setup

- Install NPM dependancies by typing

```
npm install
```

> For the above command to work, you must be in the project directory not this root directory 
and you must have node version 14 LTS installed.

- Open the solution in Visual Studio 2019

Set your connection string to your database in `appsettings.Development.json` or your `secrets.json` file
which can be accessed by right clicking the project and selecting `manage user secrets`.

- Open the package manager console and run the migrations by typing

```
update-database
```

Run the startup project using visual studio.

If not using docker or IIS, The site should launch at https://localhost:5001
