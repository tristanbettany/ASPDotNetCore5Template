# ASPDotNetCore5Template

This is a template to get started making an MVC ASP website using .NET Core 5 written in C#.

The standard template that comes out of the box from visual studio is ok but needs some love.

Instead of bootstrap this uses tailwind, and jquery is simply ripped out because... yuck!

Structure and organisation of all the files has been refactored.

This contains integration with Azure microsoft login which you can manage by adding your client ID in the secrets,
alternativley you can remove the integration from the services in the startup file.

## Getting setup

You need to be in the project directory not the root directory as this is the solution directory.

```
npm install
dotnet watch run
```

for the above commands to work, you must have node version 14 LTS installed and dotnet core 5 installed.

The site should launch at https://localhost:5001
