# ASPDotNetCore5Template

This is a template to get started making an MVC ASP website using .NET Core 5 written in C#.

> It's intended purpose is for creating local private intranet projects instead of public facing websites.

The standard template that comes out of the box from Microsoft Visual Studio is ok but needs some love.

Instead of bootstrap this uses tailwind, and jquery is simply ripped out because... yuck!

Structure and organisation of all the files has been refactored.

This contains integration with Azure Microsoft Login (For Work or School Accounts Only) which you can manage by adding your azure application credentials
in the secrets, alternativley you can remove the integration from the services in the startup file.

> Failure to setup your Azure application credentials or remove the integration means you will get errors when starting the website

This contains a seperate project in the solution as the database layer which you can remove if you arent using 
a database by deleting the lines from the services in the startup file, and removing references.

## Getting setup

### Frontend Setup

Open a console and change to the ApplicationLayer project. Run the following to Install dependancies required to build the frontend when you make changes

```
.\frontend.ps1 init
```

> This command runs in a node docker container to save you the pain of dealing with node on your computer

### Database Setup

Make sure you have started your local SQL database by running this command on your console

```
sqllocaldb start MSSQLLocalDB
```

This will mean that the default development connection string will work and migrations and data will be done on your localdb. If you want a database with better visual access though you will want to download Microsoft SQL Server Management Studio and get set up a database using that. If you do this you can change you database connection string by right clicking the ApplicationLayer project in Visual Studio and selecting `manage user secrets`.

### Migrations Setup

In Visual Studio goto `Tools > Nuget Package Manager > Package Manager Console`

Run the migrations by typing the following command

```
update-database
```

### Authentication

You will need to add some active directory credentials in your secrets file to allow you to login

Right click the ApplicationLayer project and select `manage user secrets`.

In the file that pops up add the following replacing the null values with your own...

```
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": null,
    "TenantId": null,
    "ClientId": null,
    "CallbackPath": "/signin-oidc",
    "AllowedGroupName": null,
    "AllowedGroupId": null,
    "SignOutRedirectUri": "/User/SignedOut"
  }
}
```

The AllowedGroupId is the object ID of the group in azure active directory that is allowed to log in, the same with the AllowedGroupName but this time its the name of the group.

The TenantId and ClientId are Ids which can be found on your azure active directory portal.

This method of auth is only really designed for intranet type applications which are not public as only work active directory accounts can log in. Personal microsoft accounts are unable to log in.

You would get an error like the following if you tried...

```
User account 'test@test.com' from identity provider 'live.com' does not exist in tenant 'My Active Directory' and cannot access the application 'SomeRandomId'(ApplicationName) in that tenant. The account needs to be added as an external user in the tenant first. Sign out and sign in again with a different Azure Active Directory user account.
```

To add authentication for those type of accounts you need to change a lot more than configuration.

### Running

Run the startup project using Microsoft Visual Studio. 

OR

In your console from the ApplicationLayer Project type

```
dotnet watch
```

If not using docker or IIS, The site should launch at https://localhost:5001

### Compiling frontend 

To compile frontend assets like Javascript and SASS run the one of the following commands in a console from the ApplicationLayer project

```
.\frontend.ps1 build:dev
```

```
.\frontend.ps1 build:prod
```

> These commands run in a node docker container to save you the pain of dealing with node on your computer