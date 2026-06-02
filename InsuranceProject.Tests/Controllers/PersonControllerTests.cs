using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Orbis.Controllers;
using Orbis.Models;

namespace InsuranceProject.Tests.Controllers
{
    public class PersonsControllerTests
    {
        [Test]
        public async Task Index_Returns_All_Persons()
        {
            var context = TestDbContextFactory.Create();

            context.Persons.Add(new Person
            {
                Name = "Иван Иванов",
                PersonType = "Физическое",
                INN = "123456789012",
                Address = "Москва",
                Phone = "123",
                Email = "ivan@test.ru"
            });

            await context.SaveChangesAsync();

            var controller = new PersonsController(context);

            var result = await controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);

            var model = result!.Model as IEnumerable<Person>;

            Assert.That(model!.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task Details_Returns_NotFound_When_Id_Not_Exists()
        {
            var context = TestDbContextFactory.Create();

            var controller = new PersonsController(context);

            var result = await controller.Details(999);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}