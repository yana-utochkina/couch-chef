using CouchChefDAL.Data;
using Microsoft.EntityFrameworkCore;

namespace CouchChefWebApiPL.Configurations;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<CouchChefDbContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        return webApp;
    }
}
