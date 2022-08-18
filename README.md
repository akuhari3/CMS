# CMS

In this project, a simple Content Management System was created that will serve for the E-Commerce Web Shop. 
The following technologies were used to create the application:
 C#, .NET Core, .NET WEB API, HTML and CSS.
The MVC pattern of software architecture was used.

## Requirements
Visual Studio 2019 (or newer) with .NET6

NuGet Packages:\
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore 6.0.6
Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.6
Microsoft.AspNetCore.Identity.UI 6.0.6
Microsoft.EntityFrameworkCore.SqlServer 6.0.6
Microsoft.EntityFrameworkCore.Tools 6.0.6
Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.8

SQL Server:
MSSQL server, used 2019 version\
The ConnectionString is configured to use a local instance with Windows based authentication of the MSSQL server within the appsettings.json file

## Deployment

To deploy this project run Visual Studio

When selecting the project, select Clone Repository and enter the project url https://github.com/akuhari3/CMS.git , start its download from the web.

Then it is necessary to open the Package Manager Console and start creating the database with the command "update-database"

Start the application by pressing the play button.


## Roles and Users:

There are 3 users in the system, of which one role has been assigned:

Username: superadmin@admin.com\
Password: Superadmin12345\
Role: SuperAdmin

Username: admin@admin.com\
Password: Admin12345\
Role: Admin

UserName: operator@admin.com\
Password: Operator12345\
Role: Operator


## API Reference

with the help of the REST WEB API, access to the Product endpoint is enabled with the HTTP GET protocol.
#### Get all products

```http
  GET /api/productapi
```


#### Get product

```http
  GET /api/productapi/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of product to fetch |

