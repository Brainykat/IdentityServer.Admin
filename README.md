

# IdentityServer.Admin 

> The administration for the  IdentityServer and Asp.Net Core Identity
The application is written in the **Asp.Net Core MVC - using .NET 8.0**

## Requirements

- [Install](https://www.microsoft.com/net/download/windows#/current) the latest .NET 8 SDK (using older versions may lead to 502.5 errors when hosted on IIS or application exiting immediately after starting when self-hosted)

### Running in Visual Studio

- Set Startup projects:
  - IdentityServer.Admin
  - IdentityServer.Admin.Api
  - IdentityServer.STS.Identity
## Administration UI preview

- This administration uses bootstrap 4


## Running via Docker

- It is possible to run Admin UI through the docker.

### Docker setup

### DNS

We need some resolving capabilities in order for the project to work. The domain `identity.local` is used here to represent the domain this setup is hosted on. The domain-name needs to be FQDN (fully qualified domain name).

Thus first, we need the domain `identity.local` to resolve to the docker-host machine. If you want this to work on your local machine only, use the first option.

#### DNS on docker-host machine only

Edit your hosts file:

- On Linux: `\etc\hosts`
- On Windows: `C:\Windows\system32\drivers\etc\hosts`

and add the following entries:

```custom
127.0.0.1 identity.local sts.identity.local admin.identity.local admin-api.identity.local
```

This way your host machine resolves `identity.local` and its subdomains to itself.

### Certificates

We also need certificates in order to serve on HTTPS. We'll make our own self-signed certificates with [mkcert](https://github.com/FiloSottile/mkcert).

> If the domain is publicly available through DNS, you can use [Let's Encypt](https://letsencrypt.org/). Nginx-proxy has support for that, which is left out in this setup.

#### MkCert

##### Create the root certificate

Use [mkcert](https://github.com/FiloSottile/mkcert) to generate local self-signed certificates.

On windows `mkcert -install` must be executed under elevated Administrator privileges. Then copy over the CA Root certificate over to the project as we want to mount this in later into the containers without using an environment variable. Use PowerShell to run the commands.

```bash
cd shared/nginx/certs
mkcert --install
copy $env:LOCALAPPDATA\mkcert\rootCA-key.pem ./cacerts.pem
copy $env:LOCALAPPDATA\mkcert\rootCA.pem ./cacerts.crt
```

##### Create the `identity.local` certificates

Generate a certificate for `identity.local` with wildcards for the subdomains. The name of the certificate files need to match with actual domain-names in order for the nginx-proxy to pick them up correctly. We want both the crt-key and the pfx version.

```bash
cd shared/nginx/certs
mkcert -cert-file identity.local.crt -key-file identity.local.key identity.local *.identity.local
mkcert -pkcs12 identity.local.pfx identity.local *.identity.local
```
### Run docker-compose

- Project contains the `docker-compose.vs.debug.yml` and `docker-compose.override.yml` to enable debugging with a seeded environment.
- The following possibility to get a running seeded and debug-able (in VS) environment:

```
docker-compose build
docker-compose up -d
```

> It is also possible to set as startup project the project called `docker-compose` in Visual Studio.

### Docker images

- Docker images will be available also in [docker hub](https://hub.docker.com/u/identity)

### Publish Docker images to Docker hub

- Check the script in `build/publish-docker-images.ps1` - change the profile name according to your requirements.

## Installation of the Client Libraries

```sh
cd src/IdentityServer.Admin
npm install

cd src/IdentityServer.STS.Identity
npm install
```

## Bundling and Minification

The following Gulp commands are available:

- `gulp fonts` - copy fonts to the `dist` folder
- `gulp styles` - minify CSS, compile SASS to CSS
- `gulp scripts` - bundle and minify JS
- `gulp clean` - remove the `dist` folder
- `gulp build` - run the `styles` and `scripts` tasks
- `gulp watch` - watch all changes in all sass files

## EF Core & Data Access

- The solution uses these `DbContexts`:

  - `AdminIdentityDbContext`: for Asp.Net Core Identity
  - `AdminLogDbContext`: for logging
  - `IdentityServerConfigurationDbContext`: for IdentityServer configuration store
  - `IdentityServerPersistedGrantDbContext`: for IdentityServer operational store
  - `AuditLoggingDbContext`: for Audit Logging
  - `IdentityServerDataProtectionDbContext`: for dataprotection

### Run entity framework migrations:

> NOTE: Initial migrations are a part of the repository.

- It is possible to use powershell script in folder `build/add-migrations.ps1`.
- This script take two arguments:

  - --migration (migration name)
  - --migrationProviderName (provider type - available choices: All, SqlServer, MySql, PostgreSQL)

- For example:
  `.\add-migrations.ps1 -migration DbInit -migrationProviderName SqlServer`

### Available database providers:

- SqlServer
- MySql
- PostgreSQL

> It is possible to switch the database provider via `appsettings.json`:

```
"DatabaseProviderConfiguration": {
        "ProviderType": "SqlServer"
    }
```

### Connection strings samples for available db providers:

**PostgreSQL**:

> Server=localhost;Port=5432;Database=IdentityServerAdmin;User Id=sa;Password=#;

**MySql:**

> server=localhost;database=IdentityServerAdmin;user=root;password=#

### We suggest to use seed data:

- In `Program.cs` -> `Main`, uncomment `DbMigrationHelpers.EnsureSeedData(host)` or use dotnet CLI `dotnet run /seed` or via `SeedConfiguration` in `appsettings.json`
- The `Clients` and `Resources` files in `identityserverdata.json` (section called: IdentityServerData) - are the initial data, based on a sample from Duende IdentityServer
- The `Users` file in `identitydata.json` (section called: IdentityData) contains the default admin username and password for the first login

## Authentication and Authorization

- Change the specific URLs and names for the IdentityServer and Authentication settings in `appsettings.json`
- In the controllers is used the policy which name is stored in - `AuthorizationConsts.AdministrationPolicy`. In the policy - `AuthorizationConsts.AdministrationPolicy` is defined required role stored in - `appsettings.json` - `AdministrationRole`.
- With the default configuration, it is necessary to configure and run instance of  IdentityServer. It is possible to use initial migration for creating the client as it mentioned above

## Azure Key Vault

- It is possible to use Azure Key Vault and configure it in the `appsettings.json` with following configuration:

```
"AzureKeyVaultConfiguration": {
    "AzureKeyVaultEndpoint": "",
    "ClientId": "",
    "ClientSecret": "",
    "UseClientCredentials": true
  }
```

If your application is running in `Azure App Service`, you can specify `AzureKeyVaultEndpoint`. For applications which are running outside of Azure environment it is possible to use the client credentials flow - so it is necesarry to go to Azure portal, register new application and connect this application to Azure Key Vault and setup the client secret.

- It is possible to use Azure Key Vault for following parts of application:

### Application Secrets and Database Connection Strings:

- It is necesarry to configure the connection to Azure Key Vault and allow following settings:

```
"AzureKeyVaultConfiguration": {
    "ReadConfigurationFromKeyVault": true
  }
```

### Dataprotection:

Enable Azure Key Vault for dataprotection with following configuration:

```
"DataProtectionConfiguration": {
    "ProtectKeysWithAzureKeyVault": false
  }
```

The you need specify the key identifier in configuration:

```
"AzureKeyVaultConfiguration": {
    "DataProtectionKeyIdentifier": ""
  }
```

### IdentityServer certificate for signing tokens:

- It is possible to go to Azure Key Vault - generate new certificate and use this certificate name below:

```
"AzureKeyVaultConfiguration": {
    "IdentityServerCertificateName": ""
  }
```

## Logging

- We are using `Serilog` with pre-definded following Sinks - white are available in `serilog.json`:

  - Console
  - File
  - MSSqlServer
  - Seq

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Error",
      "Override": {
        "identity": "Information"
      }
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "log.txt",
          "rollingInterval": "Day"
        }
      },
      {
        "Name": "MSSqlServer",
        "Args": {
          "connectionString": "...",
          "tableName": "Log",
          "columnOptionsSection": {
            "addStandardColumns": ["LogEvent"],
            "removeStandardColumns": ["Properties"]
          }
        }
      }
    ]
  }
}
```

## Audit Logging

- This solution uses audit logging via - https://github.com/identity/AuditLogging (check this link for more detal about this implementation :blush:)
- In the Admin UI project is following setup:

```cs
services.AddAuditLogging(options => { options.Source = auditLoggingConfiguration.Source; })
                .AddDefaultHttpEventData(subjectOptions =>
                    {
                        subjectOptions.SubjectIdentifierClaim = auditLoggingConfiguration.SubjectIdentifierClaim;
                        subjectOptions.SubjectNameClaim = auditLoggingConfiguration.SubjectNameClaim;
                    },
                    actionOptions =>
                    {
                        actionOptions.IncludeFormVariables = auditLoggingConfiguration.IncludeFormVariables;
                    })
                .AddAuditSinks<DatabaseAuditEventLoggerSink<TAuditLog>>();

            // repository for library
            services.AddTransient<IAuditLoggingRepository<TAuditLog>, AuditLoggingRepository<TAuditLoggingDbContext, TAuditLog>>();

            // repository and service for admin
            services.AddTransient<IAuditLogRepository<TAuditLog>, AuditLogRepository<TAuditLoggingDbContext, TAuditLog>>();
            services.AddTransient<IAuditLogService, AuditLogService<TAuditLog>>();
```

### Admin Configuration

Admin and STS can be customized without editing code in `appsettings.json` under AdminConfiguration section

#### Themes

UI can be customized using themes integrated from [bootswatch](https://bootswatch.com).

It's possible to change theme from UI. 🎈

By default, configuration value is null to use default theme. If you want to use a theme, just fill the lowercase theme name as configuration value of `Theme` key.

You can also use your custom theme by integrating it in your project or hosting css on your place to pass the url in `CustomThemeCss` key. (Note that custom theme override standard theme)

- Important Note: Theme can use external ressources which caused errors due to CSP. If you get errors, please make sure that you configured correctly CSP section in your `appsettings.json` with thrusted domains for ressources.

```json
  "AdminConfiguration": {
    "PageTitle": "IdentityServer",
    "HomePageLogoUri": "~/images/identity-icon.png",
    "FaviconUri": "~/favicon.ico",
    "Theme": "united",
    "CustomThemeCss": null,
    ...
  },
```

### Audit Logging Configuration

In `appsettings.json` is following configuration:

```json
"AuditLoggingConfiguration": {
    "Source": "IdentityServer.Admin.Web",
    "SubjectIdentifierClaim": "sub",
    "SubjectNameClaim": "name",
    "IncludeFormVariables": false
  }
```

The `IdentityServer.Admin.BusinessLogic` layer contains folder called `Events` for audit logging. In each method in Services is called function `LogEventAsync` like this:

```
await AuditEventLogger.LogEventAsync(new ClientDeletedEvent(client));
```

Final audit log is available in the table `dbo.AuditLog`.

### Login Configuration

- In `IdentityServer.STS.Identity` - in `appsettings.json` is possible to specify which column will be used for login (`Username` or `Email`):

```
  "LoginConfiguration": {
    "ResolutionPolicy": "Username"
  }
```

or using `Email`:

```
  "LoginConfiguration": {
    "ResolutionPolicy": "Email"
  }
```

### Register Configuration

- In `IdentityServer.STS.Identity` - in `appsettings.json` is possible to disable user registration (`default: true`):

```
 "RegisterConfiguration": {
    "Enabled": false
  }
```

## How to configure API & Swagger

- For development is running on url - `https://localhost:44302` and swagger UI is available on url - `https://localhost:44302/swagger`
- For swagger UI is configured a client and an API in STS:

```
"AdminApiConfiguration": {
  "IdentityServerBaseUrl": "https://localhost:44310",
  "OidcSwaggerUIClientId": "identity_admin_api_swaggerui",
  "OidcApiName": "identity_admin_api"
}
```

## How to configure an external provider in STS

- In `IdentityServer.STS.Identity/Helpers/StartupHelpers.cs` - is method called `AddExternalProviders` which contains the example with `GitHub`, `AzureAD` configured in `appsettings.json`:

```
"ExternalProvidersConfiguration": {
        "UseGitHubProvider": false,
        "GitHubClientId": "",
        "GitHubClientSecret": "",
        "UseAzureAdProvider": false,
        "AzureAdClientId": "",
        "AzureAdTenantId": "",
        "AzureInstance": "",
        "AzureAdSecret": "",
        "AzureAdCallbackPath": "",
        "AzureDomain": ""
}
```

- It is possible to extend `ExternalProvidersConfiguration` with another configuration properties.
- If you use DockerHub built image, you can use appsettings to configure these providers without changing the code
  - GitHub
  - AzureAD

### List of external providers for ASP.NET Core:

- https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/

### Azure AD

- Great article how to set up Azure AD:
  - https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp

## Email service

- It is possible to set up emails via:

### SendGrid

In STS project - in `appsettings.json`:

```
"SendgridConfiguration": {
        "ApiKey": "",
        "SourceEmail": "",
        "SourceName": ""
    }
```

### SMTP

```
"SmtpConfiguration": {
        "From": "",
        "Host": "",
        "Login": "",
        "Password": ""
    }
```

## CSP - Content Security Policy

- If you want to use favicon or logo not included/hosted on the same place, you need to declare trusted domain where ressources are hosted in appsettings.json.

```
  "CspTrustedDomains": [
    "google.com",
    "mydomain.com"
  ],
```

## Health checks

- AdminUI, AdminUI Api and STS contain endpoint `health`, which check databases and IdentityServer.

## Localizations - labels, messages

- The project has following translations:
  - English
  - Chinese
  - Russian
  - Persian
  - Swedish
  - Danish
  - Spanish
  - French
  - Finish
  - German
  - Portuguese


## Overview

### Solution structure:

- STS:

- Admin UI Api:

  - `IdentityServer.Admin.Api` - project with Api for managing data IdentityServer and Asp.Net Core Identity, with swagger support as well

- Admin UI:

  - `IdentityServer.Admin.UI` - ASP.NET Core MVC application that contains Admin UI

  - `IdentityServer.Admin` - ASP.NET Core MVC application that uses Admin UI package and it's only for application bootstrap

  - `IdentityServer.Admin.BusinessLogic` - project that contains Dtos, Repositories, Services and Mappers for the IdentityServer

  - `IdentityServer.Admin.BusinessLogic.Identity` - project that contains Dtos, Repositories, Services and Mappers for the Asp.Net Core Identity

  - `IdentityServer.Admin.BusinessLogic.Shared` - project that contains shared Dtos and ExceptionHandling for the Business Logic layer of the IdentityServer and Asp.Net Core Identity

  - `IdentityServer.Shared` - Shared common Identity DTOS for Admin UI, Admin UI Api and STS

  - `IdentityServer.Shared.Configuration` - Shared common layer for Admin UI, Admin UI Api and STS

  - `IdentityServer.Admin.EntityFramework` - EF Core data layer that contains Entities for the IdentityServer

  - `IdentityServer.Admin.EntityFramework.Configuration` - EF Core data layer that contains configurations

  - `IdentityServer.Admin.EntityFramework.Identity` - EF Core data layer that contains Repositories for the Asp.Net Core Identity

  - `IdentityServer.Admin.EntityFramework.Extensions` - project that contains extensions related to EntityFramework

  - `IdentityServer.Admin.EntityFramework.Shared` - project that contains DbContexts for the IdentityServer, Logging and Asp.Net Core Identity, inluding shared Identity entities

  - `IdentityServer.Admin.EntityFramework.SqlServer` - project that contains migrations for SqlServer

  - `IdentityServer.Admin.EntityFramework.MySql` - project that contains migrations for MySql

  - `IdentityServer.Admin.EntityFramework.PostgreSQL` - project that contains migrations for PostgreSQL

- Tests:

  - `IdentityServer.Admin.IntegrationTests` - xUnit project that contains the integration tests for AdminUI

  - `IdentityServer.Admin.Api.IntegrationTests` - xUnit project that contains the integration tests for AdminUI Api

  - `IdentityServer.Admin.UnitTests` - xUnit project that contains the unit tests for AdminUI

  - `IdentityServer.STS.IntegrationTests` - xUnit project that contains the integration tests for STS

### The admininistration contains the following sections:

## IdentityServer

**Clients**

It is possible to define the configuration according the client type - by default the client types are used:

- Empty
- Web Application - Server side - Authorization Code Flow with PKCE
- Single Page Application - Javascript - Authorization Code Flow with PKCE
- Native Application - Mobile/Desktop - Hybrid flow
- Machine/Robot - Client Credentials flow
- TV and Limited-Input Device Application - Device flow

- Actions: Add, Update, Clone, Remove
- Entities:
  - Client Cors Origins
  - Client Grant Types
  - Client IdP Restrictions
  - Client Post Logout Redirect Uris
  - Client Properties
  - Client Redirect Uris
  - Client Scopes
  - Client Secrets

**API Resources**

- Actions: Add, Update, Remove
- Entities:
  - Api Claims
  - Api Scopes
  - Api Scope Claims
  - Api Secrets
  - Api Properties

**Identity Resources**

- Actions: Add, Update, Remove
- Entities:
  - Identity Claims
  - Identity Properties

## Asp.Net Core Identity

**Users**

- Actions: Add, Update, Delete
- Entities:
  - User Roles
  - User Logins
  - User Claims

**Roles**

- Actions: Add, Update, Delete
- Entities:
  - Role Claims



This web application is based on these projects:

- ASP.NET Core
- IdentityServer.EntityFramework
- ASP.NET Core Identity
- XUnit
- Fluent Assertions
- Bogus
- AutoMapper
- Serilog