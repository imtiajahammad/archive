using System;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
	public static class Dependencies
	{
		public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
		{
			/*var useOnlyInMemoryDatabase = false;
			if (configuration["UseOnlyInMemoryDatabase"] != null)
			{
				useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
			}
			if (useOnlyInMemoryDatabase)
			{
				services.AddDbContext<ArchiveContext>(c => c.UseInMemoryDatabase("Catalog"));
				services.AddDbContext<AppIdentityDbContext>(options => options.UseInMemoryDatabase("Identity"));
			}
			else
			{*/
				// use real database
				// requires LocalDB which can be installed with SQL Server Express 2016
				services.AddDbContext<ArchiveContext>(c => c.UseSqlServer(configuration.GetConnectionString("ArchiveConnection")));
				services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
			//}
		}
	}
}

/*
-- go to publicApi project and run these commands

dotnet restore
dotnet tool restore

dotnet ef migrations add InitialModel --context archiveContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj -o Data/Migrations

dotnet ef migrations add InitialIdentityModel --context appIdentityDbContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj -o Identity/Migrations


dotnet ef database update -c archiveContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj
dotnet ef database update -c appIdentityDbContext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj
*/