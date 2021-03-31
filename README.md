# Integrating AdminLTE with .NET5 or ASP.NET Core 3.1
We will learn how integrating AdminLTE with ASP.NET Core 3.1 MVC or really any other Bootstrap based UI Frameworks completely from scratch. We will also go through about integrating Identity Server to our MVC Applicaiton. Also, you will gain quite a lot of practical knowledge on Views, Layouts, Partial Views, Conditional Rendering, Navigation Indicator and much more.

For more details about this project, you can read my post titled [Integrating AdminLTE with ASP.NET Core](https://www.puresourcecode.com/dotnet/net-core/integrating-adminlte-with-asp-net-core/) from my blog [PureSourceCode](https://www.puresourcecode.com)

> I updated the project to `.NET5`. You can use the same project with `.NET Core 3.1` if you downgrade the project from `.NET5` to `.NET Core 3.1` and the NuGet packages.

In this project template you have already:

- [AdminLTE integrated](https://www.puresourcecode.com/dotnet/net-core/integrating-adminlte-with-asp-net-core/)
- [Navigation indicator](https://www.puresourcecode.com/dotnet/net-core/features-for-adminlte-with-asp-net-core/#h-adding-navigation)
- [Breadcrumbs](https://www.puresourcecode.com/dotnet/net-core/features-for-adminlte-with-asp-net-core/#h-breadcrumbs)
- [Gravatar](https://www.puresourcecode.com/dotnet/net-core/features-for-adminlte-with-asp-net-core/#h-gravatar)
- [Authentication\Authorization with ASP.NET Identity](https://www.puresourcecode.com/dotnet/net-core/integration-with-identity-in-adminlte-project/)
- Authentication\Authorization with IdentityServer4
- [Authentication with other providers](https://www.puresourcecode.com/dotnet/net-core/external-providers-in-adminlte-project/):
    - [Facebook](https://www.puresourcecode.com/dotnet/net-core/external-providers-in-adminlte-project/#h-add-facebook-authentication)
    - [Google](https://www.puresourcecode.com/dotnet/net-core/external-providers-in-adminlte-project/#h-add-google-authentication)
    - [Microsoft](https://www.puresourcecode.com/dotnet/net-core/external-providers-in-adminlte-project/#h-add-microsoft-authentication)
    - [Twitter](https://www.puresourcecode.com/dotnet/net-core/external-providers-in-adminlte-project/#h-add-twitter-authentication)
- [Integration with a mail server (such as Outlook.com) to send emails from the authentication process](https://www.puresourcecode.com/dotnet/net-core/integration-with-identity-in-adminlte-project#h-account-confirmation-and-password-recovery-in-asp-net-core)
- [New View Components in AdminLTE project](https://www.puresourcecode.com/dotnet/net-core/new-view-components-in-adminlte-project/)
- API controllers
- Integration with Swagger functionalities and comment generation
- Integration with Hangfire.io for background processes
- Integration with SignalR
- Add `Tables` area for common tables such as **Countries**
- Create API for the [DataTables](https://www.datatables.net/)
- Integration with DataTables
    - View template to display data
    - Flexible model to manage the Datatables in the UI
- Import Microsoft Excel files
    - Import a file from the UI
    - Validation of the structure of the file
    - Start a background process with Hangfire.io to import the Excel file
    - Save in the database and create common tables

If you have any question, please use the [PureSourceCode Forum](https://www.puresourcecode.com/forum/).

## Screenshots
The result of the main application is this one:

![AdminLTE integration with ASP.NET Core 5](https://www.puresourcecode.com/wp-content/uploads/2021/02/adminlte-aspnet-core-integration-3.png)

## Login

![Login in ASP.NET 5 with AdminLTE](https://www.puresourcecode.com/wp-content/uploads/2021/02/adminlte-aspnet-core-integration-login.png)

## How do I organize the solution?
The project is divided into the following layers:

- Domain
- Infrastructure
- Persistence
- Specs/Tests
- UI

This because I want to follow the guide lines for a [clean architecture](https://www.puresourcecode.com/tag/clean-architecture/) solution. I have create some posts about it and you have the link here:
*   [Architecting ASP.NET Core applications](https://www.puresourcecode.com/dotnet/net-core/architecting-asp-net-core-applications/)
*   [Setting up the application core](https://www.puresourcecode.com/dotnet/net-core/setting-up-the-application-asp-net-core/)
*   [Introducing CQRS in the architecture](https://www.puresourcecode.com/dotnet/introducing-cqrs-in-the-architecture)
*   [Adding Validation using Fluent](https://www.puresourcecode.com/dotnet/adding-validation-using-fluent-validation/)
*   [Creating the infrastructure project](https://www.puresourcecode.com/dotnet/creating-the-infrastructure-project/)
*   [Adding an API using ASP.NET Core](https://www.puresourcecode.com/dotnet/net-core/adding-an-api-using-asp-net-core/)
*   [How testing the application code](https://www.puresourcecode.com/dotnet/csharp/how-testing-the-application-code/)
*   [How adding an UI built in Blazor](https://www.puresourcecode.com/dotnet/net-core/how-adding-an-ui-built-in-blazor/)
*   [Improving on the application's behaviour](https://www.puresourcecode.com/dotnet/net-core/improving-on-the-applications-behaviour/)

### Layers and code
*   Core (no dependency to any Infrastructure-related code or package)
    *   Entities
    *   Interfaces
        *   Core
        *   Infrastructure
    *   Services
    *   Exceptions
*   Infrastructure
    *   Data access (Entity Framework Core)
    *   Logging
    *   Identity
    *   API clients
    *   File access
*   UI
    *   API/MVC/Razor
    *   Specific ASP.NET Core items
        *   Middleware
        *   Filters
    *   Interact with services through MediatR
        *   Loose coupling
        *   Lightweight controllers

## New View Components

There are new ASP.NET Core [ViewComponents](https://www.puresourcecode.com/dotnet/net-core/create-view-components-in-asp-net-core/) to enrich the UI:
- Boxes
    - simple
    - progressbox
    - showbox
- Charts with Chart.js
    - Bar
    - Line
    - Pie
- Card (simple)
- Timeline

## Integration with IdentityServer4
In the project you find an integration with `IdentityServer4`. To enable the authentication with `IdentityServer`, you have to change the `appsettings.json` under **Authentication** and modify **UseIdentityServer** to `true`.

```
"Authentication": {
    "UseIdentityServer": true,
    "IdentityServer": {
        "IdentityServerUrl": "https://youridentityserver.com",
        "ClientId": "",
        "ClientSecret": ""
    }
}

```

Although the implementation in the project is correct, you will face an issue: after the login with `IdentityServer`, the application calls again and again `IdentityServer` for authentication. Basically, there is a loop between the application and `IdentityServer`. I discovered that this issue is coming from `Microsoft Identity`. 

If you want the authentication with `IdentityServer`, you have to remove all packages related to `Microsoft Identity` and under the **Area** folder remove the **Pages** folder and **IdentityHostingStartup.cs**. 
Clean the solution, the cookies in your browser and then everything will work.

I left the branch named [Only IdentityServer](https://github.com/erossini/AdminLTEWithASPNETCore/tree/feature/only-identityserver) where I removed all the `Microsoft.Identity` Nuget packages and clean the solution for that.

## Integration with DataTables
I love this javascript component! [DataTables](https://www.datatables.net/) is a very powerful script to create a table with data from your database. It is doing everything for you if you have the right configuration.

In this project, I added under `Area` a folder called `Tables`. In all my projects, the admin wants to have a list of items for dropdown lists across all the application. So, with DataTables it is easy to create a view with search, order, column visibility, pagination, export (copy the table, csv, Excel, PDF and print). And all of it just adding few libraries.

The result is quite nice and I'm working to generalize as much as possible this part.

![Integration with DataTables](https://www.puresourcecode.com/wp-content/uploads/2021/03/adminlte-aspnet-core-integration-datatables.png)

## Swagger

![Swagger integration](https://www.puresourcecode.com/wp-content/uploads/2021/03/adminlte-aspnet-core-integration-swagger.png)

## More info

If you want an implementation of a particular view or feature, please use our [Forum](https://www.puresourcecode.com/forum/) and explain what you like to have.

More features are coming...
