namespace isk.GeneralAPI
{
    public static class WebApplicationBuilder
    {
        public static IHostBuilder ConfigureMyAppSettings(this IHostBuilder host)
        {
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            host.ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddJsonFile("appsettings.json", false, true);
                builder.AddJsonFile($"appsettings.{enviroment}.json", true, true);
                builder.AddEnvironmentVariables();
            });

            return host;
        }

    }
}
