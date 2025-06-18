namespace Projeto_Aplicado_II_API.Infrastructure.Middlewares
{
    public static class ConfigureMiddlewares
    {
        public static void AddMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<RequestLimiterMiddleware>();
        }

        public static void AddMiddlewares(this IServiceCollection collection)
        {
            collection.AddTransient<ExceptionHandlerMiddleware>();
            collection.AddTransient<RequestLimiterMiddleware>();
        }
    }
}
