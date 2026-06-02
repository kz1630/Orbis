using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Orbis.Controllers;
using Orbis.Models;

namespace InsuranceProject.Tests.Controllers
{
    public class InsuranceServicesControllerTests
    {
        [Test]
        public async Task Index_Returns_All_Services()
        {
            var context = TestDbContextFactory.Create();

            context.InsuranceServices.Add(new InsuranceService
            {
                Name = "ОСАГО",
                Description = "Тест",
                Category = "Авто",
                Cost = 1000,
                DurationMonths = 12,
                IsActive = true
            });

            await context.SaveChangesAsync();

            var controller = new InsuranceServicesController(context);

            var result = await controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);

            var model = result!.Model as IEnumerable<InsuranceService>;

            Assert.That(model!.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task Details_Returns_NotFound_For_Invalid_Id()
        {
            var context = TestDbContextFactory.Create();

            var controller = new InsuranceServicesController(context);

            var result = await controller.Details(100);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}