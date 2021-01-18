# ASPDotNetCore5Template

This is a template to get started making an MVC ASP website using .NET Core 5 written in C#.

The standard template that comes out of the box from visual studio is ok but needs some love.

Instead of bootstrap this uses tailwind, and jquery is simply ripped out because... yuck!

Structure and organisation of all the files has been refactored.

This contains integration with Azure microsoft login which you can manage by adding your client ID in the secrets,
alternativley you can remove the integration from the services in the startup file.

This contains a seperate project in the solution as the database layer which you can remove if you arent using 
a database by deleting the lines from the services in the startup file, and removing references.

## Getting setup

You need to be in the project directory not the root directory as this readme is in the solution directory.

```
npm install
```

For the above command to work, you must have node version 14 LTS installed.

Open the solution in Visual Studio 2019 and open the package manager console. to run the migrations type

```
update-database
```

Run the startup project using visual studio.

If not using docker or IIS, The site should launch at https://localhost:5001
