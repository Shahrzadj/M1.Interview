using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Personnel.Data.Contracts;
using System.Net.Http;

namespace Personnel.Api.Test
{
    [TestClass]
    public class TestInitializer
    {
        public static HttpClient TestHttpClient;
        public static Mock<IPersonnelRepository> MockPersonnelRepository;
        [AssemblyInitialize]
        public static void InitializeTestServer(TestContext testContext)
        {
            var testServer = new TestServer(new WebHostBuilder()
               .UseStartup<TestStartup>()
               // this would cause it to use StartupIntegrationTest class
               // or ConfigureServicesIntegrationTest / ConfigureIntegrationTest
               // methods (if existing)
               // rather than Startup, ConfigureServices and Configure
               .UseEnvironment("IntegrationTest"));

            TestHttpClient = testServer.CreateClient();
        }
        public static void RegisterMockRepositories(IServiceCollection services)
        {
            MockPersonnelRepository = (new Mock<IPersonnelRepository>());
            services.AddSingleton(MockPersonnelRepository.Object);

            //add more mock repositories below
        }
    }
}
