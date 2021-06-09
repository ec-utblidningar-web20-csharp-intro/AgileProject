using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using WeddingApi;
using WeddingApi.Data;
using WeddingApi.Models;
using WeddingApi.Repositories;

namespace Testing2
{
    [TestClass]
    public class TestWithFactory
    {
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Startup>();
            _factory.CreateClient();
        }

        [ClassCleanup]
        public static void ClassCleanupTest()
        {
            _factory.Dispose();
        }

        private IServiceScope _scope;
        private WeddingDbContext _context;
        private IGuestRepository _guestRepo;
        private HttpClient _client;

        [TestInitialize]
        public void InitTests()
        {
            _scope = _factory.Services.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<WeddingDbContext>();
            _guestRepo = _scope.ServiceProvider.GetRequiredService<IGuestRepository>();
            _client = _factory.CreateClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _scope.Dispose();
        }

        [TestMethod]
        public async Task GetGuests()
        {
            var guests = _guestRepo.Get(new Wedding(), null);
            Assert.IsTrue(guests != null);
        }
    }
}
