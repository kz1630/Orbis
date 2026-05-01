using Orbis.Models;

namespace Orbis.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OrbisDbContext context)
        {
            context.Database.EnsureCreated();

            // Проверяем, есть ли уже данные
            if (context.Users.Any())
            {
                return; // БД уже заполнена
            }

            // Пользователи
            var users = new User[]
            {
                new User
                {
                    Username = "admin",
                    Password = "admin123",
                    Role = "Admin",
                    FullName = "Администратор системы",
                    Email = "admin@orbis.ru",
                    CreatedAt = new DateTime(2026, 1, 1)
                },
                new User
                {
                    Username = "manager",
                    Password = "manager123",
                    Role = "Manager",
                    FullName = "Иванов Иван Иванович",
                    Email = "manager@orbis.ru",
                    CreatedAt = new DateTime(2026, 1, 15)
                },
                new User
                {
                    Username = "user",
                    Password = "user123",
                    Role = "User",
                    FullName = "Петрова Мария Сергеевна",
                    Email = "user@orbis.ru",
                    CreatedAt = new DateTime(2026, 2, 1)
                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            // Физические лица
            var persons = new Person[]
            {
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Смирнов Алексей Петрович",
                    INN = "123456789012",
                    PassportSeries = "4509",
                    PassportNumber = "123456",
                    Address = "г. Москва, ул. Ленина, д. 10, кв. 5",
                    Phone = "+7 (495) 123-45-67",
                    Email = "smirnov@mail.ru",
                    CreatedAt = new DateTime(2025, 6, 10)
                },
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Кузнецова Ольга Викторовна",
                    INN = "234567890123",
                    PassportSeries = "4510",
                    PassportNumber = "234567",
                    Address = "г. Санкт-Петербург, пр. Невский, д. 25, кв. 12",
                    Phone = "+7 (812) 234-56-78",
                    Email = "kuznetsova@gmail.com",
                    CreatedAt = new DateTime(2025, 7, 15)
                },
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Попов Дмитрий Сергеевич",
                    INN = "345678901234",
                    PassportSeries = "4511",
                    PassportNumber = "345678",
                    Address = "г. Новосибирск, ул. Красный проспект, д. 5, кв. 8",
                    Phone = "+7 (383) 345-67-89",
                    Email = "popov@yandex.ru",
                    CreatedAt = new DateTime(2025, 8, 20)
                },
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Соколова Анна Михайловна",
                    INN = "456789012345",
                    PassportSeries = "4512",
                    PassportNumber = "456789",
                    Address = "г. Екатеринбург, ул. Малышева, д. 30, кв. 15",
                    Phone = "+7 (343) 456-78-90",
                    Email = "sokolova@mail.ru",
                    CreatedAt = new DateTime(2025, 9, 5)
                },
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Лебедев Игорь Александрович",
                    INN = "567890123456",
                    PassportSeries = "4513",
                    PassportNumber = "567890",
                    Address = "г. Казань, ул. Баумана, д. 15, кв. 20",
                    Phone = "+7 (843) 567-89-01",
                    Email = "lebedev@gmail.com",
                    CreatedAt = new DateTime(2025, 10, 12)
                },
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Морозова Елена Дмитриевна",
                    INN = "678901234567",
                    PassportSeries = "4514",
                    PassportNumber = "678901",
                    Address = "г. Нижний Новгород, ул. Большая Покровская, д. 8, кв. 3",
                    Phone = "+7 (831) 678-90-12",
                    Email = "morozova@yandex.ru",
                    CreatedAt = new DateTime(2025, 11, 18)
                },
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Волков Сергей Николаевич",
                    INN = "789012345678",
                    PassportSeries = "4515",
                    PassportNumber = "789012",
                    Address = "г. Самара, ул. Ленинградская, д. 22, кв. 7",
                    Phone = "+7 (846) 789-01-23",
                    Email = "volkov@mail.ru",
                    CreatedAt = new DateTime(2025, 12, 25)
                },
                new Person
                {
                    PersonType = "Физическое",
                    Name = "Новикова Татьяна Ивановна",
                    INN = "890123456789",
                    PassportSeries = "4516",
                    PassportNumber = "890123",
                    Address = "г. Ростов-на-Дону, пр. Буденновский, д. 12, кв. 18",
                    Phone = "+7 (863) 890-12-34",
                    Email = "novikova@gmail.com",
                    CreatedAt = new DateTime(2026, 1, 8)
                },
                // Юридические лица
                new Person
                {
                    PersonType = "Юридическое",
                    Name = "ООО \"Альфа Строй\"",
                    INN = "7701234567",
                    PassportSeries = null,
                    PassportNumber = null,
                    Address = "г. Москва, ул. Тверская, д. 5, офис 301",
                    Phone = "+7 (495) 111-22-33",
                    Email = "info@alfastroy.ru",
                    CreatedAt = new DateTime(2025, 5, 15)
                },
                new Person
                {
                    PersonType = "Юридическое",
                    Name = "ЗАО \"Бета Транс\"",
                    INN = "7802345678",
                    PassportSeries = null,
                    PassportNumber = null,
                    Address = "г. Санкт-Петербург, ул. Восстания, д. 18, офис 205",
                    Phone = "+7 (812) 222-33-44",
                    Email = "contact@betatrans.ru",
                    CreatedAt = new DateTime(2025, 6, 20)
                },
                new Person
                {
                    PersonType = "Юридическое",
                    Name = "ИП Гамма Логистика",
                    INN = "5403456789",
                    PassportSeries = null,
                    PassportNumber = null,
                    Address = "г. Новосибирск, ул. Ленина, д. 50, офис 12",
                    Phone = "+7 (383) 333-44-55",
                    Email = "gamma@logistics.ru",
                    CreatedAt = new DateTime(2025, 7, 10)
                },
                new Person
                {
                    PersonType = "Юридическое",
                    Name = "ООО \"Дельта Технологии\"",
                    INN = "6604567890",
                    PassportSeries = null,
                    PassportNumber = null,
                    Address = "г. Екатеринбург, пр. Ленина, д. 40, офис 501",
                    Phone = "+7 (343) 444-55-66",
                    Email = "info@deltatech.ru",
                    CreatedAt = new DateTime(2025, 8, 5)
                },
                new Person
                {
                    PersonType = "Юридическое",
                    Name = "АО \"Эпсилон Энергия\"",
                    INN = "1605678901",
                    PassportSeries = null,
                    PassportNumber = null,
                    Address = "г. Казань, ул. Пушкина, д. 25, офис 102",
                    Phone = "+7 (843) 555-66-77",
                    Email = "office@epsilon-energy.ru",
                    CreatedAt = new DateTime(2025, 9, 12)
                },
                new Person
                {
                    PersonType = "Юридическое",
                    Name = "ООО \"Зета Финанс\"",
                    INN = "5206789012",
                    PassportSeries = null,
                    PassportNumber = null,
                    Address = "г. Нижний Новгород, ул. Горького, д. 100, офис 305",
                    Phone = "+7 (831) 666-77-88",
                    Email = "info@zetafinance.ru",
                    CreatedAt = new DateTime(2025, 10, 20)
                },
                new Person
                {
                    PersonType = "Юридическое",
                    Name = "ИП Эта Консалтинг",
                    INN = "6307890123",
                    PassportSeries = null,
                    PassportNumber = null,
                    Address = "г. Самара, ул. Куйбышева, д. 80, офис 201",
                    Phone = "+7 (846) 777-88-99",
                    Email = "eta@consulting.ru",
                    CreatedAt = new DateTime(2025, 11, 15)
                }
            };
            context.Persons.AddRange(persons);
            context.SaveChanges();

            // Услуги страхования
            var services = new InsuranceService[]
            {
                new InsuranceService
                {
                    Name = "ОСАГО",
                    Description = "Обязательное страхование автогражданской ответственности",
                    Cost = 8500,
                    DurationMonths = 12,
                    Category = "Автострахование",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 10)
                },
                new InsuranceService
                {
                    Name = "КАСКО",
                    Description = "Добровольное страхование транспортных средств",
                    Cost = 45000,
                    DurationMonths = 12,
                    Category = "Автострахование",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 10)
                },
                new InsuranceService
                {
                    Name = "Страхование жизни",
                    Description = "Накопительное страхование жизни и здоровья",
                    Cost = 25000,
                    DurationMonths = 60,
                    Category = "Жизнь и здоровье",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 15)
                },
                new InsuranceService
                {
                    Name = "ДМС",
                    Description = "Добровольное медицинское страхование",
                    Cost = 35000,
                    DurationMonths = 12,
                    Category = "Жизнь и здоровье",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 15)
                },
                new InsuranceService
                {
                    Name = "Страхование недвижимости",
                    Description = "Комплексное страхование квартир и домов",
                    Cost = 15000,
                    DurationMonths = 12,
                    Category = "Имущество",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 20)
                },
                new InsuranceService
                {
                    Name = "Страхование от несчастных случаев",
                    Description = "Защита от несчастных случаев и травм",
                    Cost = 12000,
                    DurationMonths = 12,
                    Category = "Жизнь и здоровье",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 2, 1)
                },
                new InsuranceService
                {
                    Name = "Страхование грузов",
                    Description = "Страхование грузов при транспортировке",
                    Cost = 50000,
                    DurationMonths = 12,
                    Category = "Бизнес",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 2, 5)
                },
                new InsuranceService
                {
                    Name = "Страхование ответственности",
                    Description = "Страхование профессиональной ответственности",
                    Cost = 40000,
                    DurationMonths = 12,
                    Category = "Бизнес",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 2, 10)
                },
                new InsuranceService
                {
                    Name = "Туристическая страховка",
                    Description = "Страхование выезжающих за рубеж",
                    Cost = 3500,
                    DurationMonths = 1,
                    Category = "Путешествия",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 2, 15)
                },
                new InsuranceService
                {
                    Name = "Страхование имущества предприятий",
                    Description = "Комплексное страхование имущества юридических лиц",
                    Cost = 120000,
                    DurationMonths = 12,
                    Category = "Бизнес",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 3, 1)
                }
            };
            context.InsuranceServices.AddRange(services);
            context.SaveChanges();

            // Договоры
            var contracts = new Contract[]
            {
                // Активные договоры
                new Contract
                {
                    ContractNumber = "ДГ-2025-001",
                    ContractDate = new DateTime(2025, 6, 15),
                    StartDate = new DateTime(2025, 7, 1),
                    EndDate = new DateTime(2026, 6, 30),
                    Amount = 8500,
                    Status = "Активный",
                    Notes = "Первый договор клиента",
                    PersonId = 1,
                    InsuranceServiceId = 1,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 6, 15)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-002",
                    ContractDate = new DateTime(2025, 7, 20),
                    StartDate = new DateTime(2025, 8, 1),
                    EndDate = new DateTime(2026, 7, 31),
                    Amount = 45000,
                    Status = "Активный",
                    Notes = "КАСКО на новый автомобиль",
                    PersonId = 2,
                    InsuranceServiceId = 2,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 7, 20)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-003",
                    ContractDate = new DateTime(2025, 8, 25),
                    StartDate = new DateTime(2025, 9, 1),
                    EndDate = new DateTime(2030, 8, 31),
                    Amount = 25000,
                    Status = "Активный",
                    Notes = "Накопительное страхование на 5 лет",
                    PersonId = 3,
                    InsuranceServiceId = 3,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2025, 8, 25)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-004",
                    ContractDate = new DateTime(2025, 9, 10),
                    StartDate = new DateTime(2025, 10, 1),
                    EndDate = new DateTime(2026, 9, 30),
                    Amount = 35000,
                    Status = "Активный",
                    Notes = "ДМС для семьи",
                    PersonId = 4,
                    InsuranceServiceId = 4,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 9, 10)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-005",
                    ContractDate = new DateTime(2025, 10, 15),
                    StartDate = new DateTime(2025, 11, 1),
                    EndDate = new DateTime(2026, 10, 31),
                    Amount = 15000,
                    Status = "Активный",
                    Notes = "Страхование квартиры",
                    PersonId = 5,
                    InsuranceServiceId = 5,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2025, 10, 15)
                },
                // Договоры, истекающие скоро (проблемные)
                new Contract
                {
                    ContractNumber = "ДГ-2025-006",
                    ContractDate = new DateTime(2025, 5, 1),
                    StartDate = new DateTime(2025, 5, 15),
                    EndDate = new DateTime(2026, 5, 14),
                    Amount = 12000,
                    Status = "Активный",
                    Notes = "Истекает через 2 недели",
                    PersonId = 6,
                    InsuranceServiceId = 6,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 5, 1)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-007",
                    ContractDate = new DateTime(2025, 4, 20),
                    StartDate = new DateTime(2025, 5, 1),
                    EndDate = new DateTime(2026, 4, 30),
                    Amount = 8500,
                    Status = "Активный",
                    Notes = "Истекает в этом месяце",
                    PersonId = 7,
                    InsuranceServiceId = 1,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2025, 4, 20)
                },
                // Просроченные договоры
                new Contract
                {
                    ContractNumber = "ДГ-2025-008",
                    ContractDate = new DateTime(2025, 3, 10),
                    StartDate = new DateTime(2025, 3, 15),
                    EndDate = new DateTime(2026, 3, 14),
                    Amount = 45000,
                    Status = "Просрочен",
                    Notes = "Требуется продление",
                    PersonId = 8,
                    InsuranceServiceId = 2,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 3, 10)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-009",
                    ContractDate = new DateTime(2025, 2, 5),
                    StartDate = new DateTime(2025, 2, 10),
                    EndDate = new DateTime(2026, 2, 9),
                    Amount = 35000,
                    Status = "Просрочен",
                    Notes = "Клиент не отвечает на звонки",
                    PersonId = 1,
                    InsuranceServiceId = 4,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2025, 2, 5)
                },
                // Договоры с юридическими лицами
                new Contract
                {
                    ContractNumber = "ДГ-2025-010",
                    ContractDate = new DateTime(2025, 6, 1),
                    StartDate = new DateTime(2025, 6, 15),
                    EndDate = new DateTime(2026, 6, 14),
                    Amount = 50000,
                    Status = "Активный",
                    Notes = "Страхование грузоперевозок",
                    PersonId = 9,
                    InsuranceServiceId = 7,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 6, 1)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-011",
                    ContractDate = new DateTime(2025, 7, 1),
                    StartDate = new DateTime(2025, 7, 15),
                    EndDate = new DateTime(2026, 7, 14),
                    Amount = 40000,
                    Status = "Активный",
                    Notes = "Страхование ответственности директора",
                    PersonId = 10,
                    InsuranceServiceId = 8,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 7, 1)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-012",
                    ContractDate = new DateTime(2025, 8, 1),
                    StartDate = new DateTime(2025, 8, 15),
                    EndDate = new DateTime(2026, 8, 14),
                    Amount = 120000,
                    Status = "Активный",
                    Notes = "Комплексное страхование офиса и склада",
                    PersonId = 11,
                    InsuranceServiceId = 10,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2025, 8, 1)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-013",
                    ContractDate = new DateTime(2025, 9, 1),
                    StartDate = new DateTime(2025, 9, 15),
                    EndDate = new DateTime(2026, 9, 14),
                    Amount = 50000,
                    Status = "Активный",
                    Notes = "Страхование грузов при международных перевозках",
                    PersonId = 12,
                    InsuranceServiceId = 7,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 9, 1)
                },
                // Завершенные договоры
                new Contract
                {
                    ContractNumber = "ДГ-2024-001",
                    ContractDate = new DateTime(2024, 6, 1),
                    StartDate = new DateTime(2024, 6, 15),
                    EndDate = new DateTime(2025, 6, 14),
                    Amount = 8000,
                    Status = "Завершен",
                    Notes = "Договор завершен успешно",
                    PersonId = 1,
                    InsuranceServiceId = 1,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2024, 6, 1)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2024-002",
                    ContractDate = new DateTime(2024, 7, 1),
                    StartDate = new DateTime(2024, 7, 15),
                    EndDate = new DateTime(2025, 7, 14),
                    Amount = 42000,
                    Status = "Завершен",
                    Notes = "Без страховых случаев",
                    PersonId = 2,
                    InsuranceServiceId = 2,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2024, 7, 1)
                },
                // Расторгнутые договоры
                new Contract
                {
                    ContractNumber = "ДГ-2025-014",
                    ContractDate = new DateTime(2025, 1, 10),
                    StartDate = new DateTime(2025, 1, 15),
                    EndDate = new DateTime(2026, 1, 14),
                    Amount = 15000,
                    Status = "Расторгнут",
                    Notes = "Расторгнут по инициативе клиента, возврат части премии",
                    PersonId = 5,
                    InsuranceServiceId = 5,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2025, 1, 10)
                },
                // Дополнительные активные договоры для статистики
                new Contract
                {
                    ContractNumber = "ДГ-2025-015",
                    ContractDate = new DateTime(2025, 11, 1),
                    StartDate = new DateTime(2025, 11, 15),
                    EndDate = new DateTime(2026, 11, 14),
                    Amount = 3500,
                    Status = "Активный",
                    Notes = "Туристическая страховка в Турцию",
                    PersonId = 3,
                    InsuranceServiceId = 9,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2025, 11, 1)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2025-016",
                    ContractDate = new DateTime(2025, 12, 1),
                    StartDate = new DateTime(2025, 12, 15),
                    EndDate = new DateTime(2026, 12, 14),
                    Amount = 40000,
                    Status = "Активный",
                    Notes = "Страхование профессиональной ответственности",
                    PersonId = 13,
                    InsuranceServiceId = 8,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2025, 12, 1)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2026-001",
                    ContractDate = new DateTime(2026, 1, 15),
                    StartDate = new DateTime(2026, 2, 1),
                    EndDate = new DateTime(2027, 1, 31),
                    Amount = 120000,
                    Status = "Активный",
                    Notes = "Новый договор на 2026 год",
                    PersonId = 14,
                    InsuranceServiceId = 10,
                    CreatedByUserId = 2,
                    CreatedAt = new DateTime(2026, 1, 15)
                },
                new Contract
                {
                    ContractNumber = "ДГ-2026-002",
                    ContractDate = new DateTime(2026, 2, 10),
                    StartDate = new DateTime(2026, 3, 1),
                    EndDate = new DateTime(2027, 2, 28),
                    Amount = 50000,
                    Status = "Активный",
                    Notes = "Страхование грузов",
                    PersonId = 15,
                    InsuranceServiceId = 7,
                    CreatedByUserId = 3,
                    CreatedAt = new DateTime(2026, 2, 10)
                }
            };
            context.Contracts.AddRange(contracts);
            context.SaveChanges();
        }
    }
}
