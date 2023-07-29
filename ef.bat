@REM dotnet ef migrations add InitDatabase --project YourDataAccessLibraryName -s YourWebProjectName -c YourDbContextClassName --verbose 
@REM dotnet ef database update InitDatabase --project YourDataAccessLibraryName -s YourWebProjectName -c YourDbContextClassName --verbose
@REM dotnet ef migrations remove --project YourDataAccessLibraryName -s YourWebProjectName -c YourDbContextClassName --verbose

dotnet ef migrations add InitDatabase --project App.DataAccess -s App.Api -c AppDbContext --verbose