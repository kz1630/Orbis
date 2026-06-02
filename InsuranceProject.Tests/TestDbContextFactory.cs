using Microsoft.EntityFrameworkCore;
using Orbis.Models;

namespace InsuranceProject.Tests
{
    public static class TestDbContextFactory
    {
        public static OrbisDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OrbisDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new OrbisDbContext(options);
        }
    }
}