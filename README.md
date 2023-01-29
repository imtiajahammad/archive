# archive



-- go to publicApi project and run these commands

dotnet restore

dotnet tool restore

dotnet ef migrations add InitialModel --context archiveContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj -o Data/Migrations

dotnet ef migrations add InitialIdentityModel --context appIdentityDbContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj -o Identity/Migrations

dotnet ef database update -c archiveContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj

dotnet ef database update -c appIdentityDbContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj
