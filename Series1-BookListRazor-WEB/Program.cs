using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

// TODO: Continue at https://youtu.be/C5cnZ-gZy2I?t=5926


namespace Series1_BookListRazor_WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
