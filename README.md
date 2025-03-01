# Enterprise Applications whith ASP.NET Core Clean Architecture and CQRS
  This project was designed to simplify the initial development of a business management 
  application by providing the essential modules needed. It adopts a scalable, low-latency 
  architecture, utilizing the most advanced and modern technologies available.

[![Prject Skills](https://skillicons.dev/icons?i=dotnet,cs,angular,ts,html,css,bootstrap,docker,github,rabbitmq,aws,mongodb,postgres,)](https://skillicons.dev)

![Screenshot of the documentation using Swagger.](.doc/img/1-swagger-identity-manager.JPG)

## How to Run the Project
1. Clone the repository.
2. Open the solution in Visual Studio 2022.
3. Configure your SQL Server connection in the appsettings.json file.
4. Run the database migrations to create the necessary tables.
   - Check if the .NET Entity Framework CLI is installed.
   - The first step is to verify that the Entity Framework CLI is installed correctly. Run the following command:

```
 dotnet tool list -g
```

   - If dotnet-ef is not listed, install with the following command:

```
dotnet tool install --global dotnet-ef
```

   - After installing the package, run the following command:

```
dotnet ef database update -p Enterprise.Applications.Identity.Infra -s Enterprise.Applications.Identity.API -c ApplicationDbContext
```

5. Build and run the ASP.NET Core Web API.



## Project Features ASP.NET Core Web API.
| Status | Feature | Issue Url |
|--------|--------|------|
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/6) | Role - Create | [Role - Create](https://github.com/jeffreysSharp/enterprise-applications/issues/6) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/7) | Role - GetAll | [Role - GetAll](https://github.com/jeffreysSharp/enterprise-applications/issues/7) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/8) | Role - Get/{id}| [🔗 Issue #8](https://github.com/jeffreysSharp/enterprise-applications/issues/8) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/9) | Role - Delete/{id} | [🔗 Issue #9](https://github.com/jeffreysSharp/enterprise-applications/issues/9) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/10) | Role - Delete/{id} | [🔗 Issue #10](https://github.com/jeffreysSharp/enterprise-applications/issues/10) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/11) | User - Create | [🔗 Issue #11](https://github.com/jeffreysSharp/enterprise-applications/issues/11) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/12) | User - GetAll | [🔗 Issue #12](https://github.com/jeffreysSharp/enterprise-applications/issues/12) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/13) | User - Delete/{userId} | [🔗 Issue #13](https://github.com/jeffreysSharp/enterprise-applications/issues/13) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/14) | User - GetUserDetails/{userId} | [🔗 Issue #14](https://github.com/jeffreysSharp/enterprise-applications/issues/14) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/15) | User - GetUserDetailsByUserName/{userName} | [🔗 Issue #15](https://github.com/jeffreysSharp/enterprise-applications/issues/15) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/16) | User - AssignRoles | [🔗 Issue #16](https://github.com/jeffreysSharp/enterprise-applications/issues/16) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/17) | User - EditUserRoles | [🔗 Issue #17](https://github.com/jeffreysSharp/enterprise-applications/issues/17) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/18) | User - GetAllUserDetails | [🔗 Issue #18](https://github.com/jeffreysSharp/enterprise-applications/issues/18) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/19) | User - EditUserProfile/{id}| [🔗 Issue #19](https://github.com/jeffreysSharp/enterprise-applications/issues/19) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/20) | Auth - Login | [🔗 Issue #20](https://github.com/jeffreysSharp/enterprise-applications/issues/20) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/21) | Auth - Logout | [🔗 Issue #21](https://github.com/jeffreysSharp/enterprise-applications/issues/21) |
| ![Status](https://img.shields.io/github/issues/detail/s/jeffreysSharp/enterprise-applications/22) | Auth - RememberPassword | [🔗 Issue #22](https://github.com/jeffreysSharp/enterprise-applications/issues/22) |


## Project Structure
- **back-end**: Contains the source code for the ASP.NET Core Web API.
- **front-end**: Contains the source code for the Angular project..
- **tests**: Contains unit tests for the project.

## Technologies Used
- ASP.NET Core 8.0
- C#
- Clean Architecture
- CQRS Pattern
- Identity (Role and User Management)
- SQL Server
- Dapper
- Entity Framework
- AutoMapper
- MediatR
- JWT Authentication and Authorization

## Additional Notes
- Make sure to secure sensitive information such as connection strings and secret keys.
- Customize the project according to your specific requirements.

Feel free to contribute, report issues, or provide feedback!

