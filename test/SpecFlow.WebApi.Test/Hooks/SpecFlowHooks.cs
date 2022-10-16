using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace SpecFlow.WebApi.Test.Hooks
{
    [Binding]
    public class SpecFlowHooks
    {
        private readonly IObjectContainer _container;

        public SpecFlowHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void RegisterServices()
        {
            var factory = GetWebApplicationFactory();
            _container.RegisterInstanceAs(factory);
        }

        private static WebApplicationFactory<Program> GetWebApplicationFactory()
        {
            return new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureAppConfiguration((context, config) =>
                    {
                        config.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
                    });
                });
        }
    }
}