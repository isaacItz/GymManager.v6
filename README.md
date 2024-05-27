# GymManager

## How to run this project

Install dotnet using winget

```
dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json
dotnet restore

dotnet ef database update
```
Make sure conneciton string is valid in `GymManager.Web/.appsettings.json`

Grab the default User & Password in ``GymManager.Web\Controllers\AccountController.cs:26``

Run the project

```
dotnet run
```