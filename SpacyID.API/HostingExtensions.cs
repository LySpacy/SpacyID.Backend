using SpacyID.Application;
using SpacyID.Infrastructure;

namespace SpacyID.API;

internal static class HostingExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Добавляем контроллеры
        builder.Services.AddControllers();

        // Подключаем Swagger
        builder.Services.AddCustomSwagger();

        //Подключение слоев
        builder.Services.RegisterInfrustractionLayer(builder.Configuration);

        builder.Services.RegisterApplicationLayer();

        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseRouting();

        // Подключаем Swagger UI
        app.UseCustomSwagger();

        app.MapGet("/", () =>
         Results.Redirect("/swagger"))
         .ExcludeFromDescription();

        //app.UseMiddleware<GlobalErrorHandlingMiddleware>();
        // Маршрутизация контроллеров
        app.MapControllers();

        //Миграции бд
        // app.ApplyMigrations();

        return app;
    }
}
