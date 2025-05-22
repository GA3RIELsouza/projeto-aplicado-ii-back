namespace Projeto_Aplicado_II_API.Infrastructure.Middlewares
{
    public static class ConfigureMiddlewares
    {
        public static void AddMiddlewares(this IServiceCollection middlewares)
        {
            middlewares.AddTransient<ExceptionHandlerMiddleware>();
        }
    }
}
