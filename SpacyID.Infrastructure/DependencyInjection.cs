using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpacyID.Application.Interfaces.Senders;
using SpacyID.Infrastructure.Configuration;
using SpacyID.Infrastructure.Senders;

namespace SpacyID.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrustractionLayer(
        this IServiceCollection services, 
        IConfiguration configuration)
    {

        //var connectionString = configuration.GetConnectionString("DefaultConnection")
        //    ?? throw new NullReferenceException("ConnectionString to database is null");

        var emailSection = configuration.GetSection("Senders:Email:Google");

        services.Configure<EmailOptions>(emailSection);

        services.AddSingleton<IEmailSender, EmailSender>();

        //services.AddDbContext<AppDbContext>(options =>
        //{
        //    options.UseNpgsql(connectionString, o =>
        //    {
        //        o.EnableRetryOnFailure();
        //    });
        //});




        return services;
    }
}

//public static class MigrationExtensions
//{
//    public static void ApplyMigrations(this IApplicationBuilder app)
//    {
//        using var scope = app.ApplicationServices.CreateScope();

//        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//        db.Database.Migrate();
//    }
//}