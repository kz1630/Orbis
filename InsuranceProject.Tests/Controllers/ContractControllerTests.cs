using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Orbis.Controllers;
using Orbis.Models;

namespace InsuranceProject.Tests.Controllers
{
    public class ContractsControllerTests
    {
        [Test]
        public async Task Index_Returns_List_Of_Contracts()
        {
            var context = TestDbContextFactory.Create();

            var person = new Person
            {
                Name = "Тест",
                PersonType = "Физическое",
                INN = "123456789012",
                Address = "Москва",
                Phone = "123",
                Email = "test@test.ru"
            };

            context.Persons.Add(person);
            await context.SaveChangesAsync();

            var service = new InsuranceService
            {
                Name = "ОСАГО",
                Description = "Тест",
                Category = "Авто",
                Cost = 1000,
                DurationMonths = 12,
                IsActive = true
            };

            context.InsuranceServices.Add(service);
            await context.SaveChangesAsync();

            var contract = new Contract
            {
                ContractNumber = "TEST-001",
                ContractDate = DateTime.Today,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddYears(1),
                Amount = 1000,
                Status = "Активный",
                Notes = "Тестовый договор",
                PersonId = person.Id,
                InsuranceServiceId = service.Id
            };

            context.Contracts.Add(contract);
            await context.SaveChangesAsync();

            Assert.That(await context.Contracts.CountAsync(), Is.EqualTo(1));

            var controller = new ContractsController(context);

            var result = await controller.Index("", null, null, "", null, null)
                as ViewResult;

            Assert.That(result, Is.Not.Null);

            var model = result!.Model as IEnumerable<Contract>;

            Assert.That(model, Is.Not.Null);
            Assert.That(model!.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task Details_Returns_NotFound_For_Invalid_Id()
        {
            var context = TestDbContextFactory.Create();

            var controller = new ContractsController(context);

            var result = await controller.Details(999);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}