using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orbis.Models;

namespace Orbis.Controllers
{
    public class ContractsController : Controller
    {
        private readonly OrbisDbContext _context;

        public ContractsController(OrbisDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchNumber, int? personId, int? serviceId, string status, DateTime? startDate, DateTime? endDate)
        {
            var contracts = _context.Contracts
                .Include(c => c.Person)
                .Include(c => c.InsuranceService)
                .Include(c => c.CreatedByUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchNumber))
            {
                contracts = contracts.Where(c => c.ContractNumber.Contains(searchNumber));
            }

            if (personId.HasValue)
            {
                contracts = contracts.Where(c => c.PersonId == personId.Value);
            }

            if (serviceId.HasValue)
            {
                contracts = contracts.Where(c => c.InsuranceServiceId == serviceId.Value);
            }

            if (!string.IsNullOrEmpty(status))
            {
                contracts = contracts.Where(c => c.Status == status);
            }

            if (startDate.HasValue)
            {
                contracts = contracts.Where(c => c.ContractDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                contracts = contracts.Where(c => c.ContractDate <= endDate.Value);
            }

            ViewBag.Persons = new SelectList(await _context.Persons.ToListAsync(), "Id", "Name");
            ViewBag.Services = new SelectList(await _context.InsuranceServices.ToListAsync(), "Id", "Name");

            return View(await contracts.OrderByDescending(c => c.ContractDate).ToListAsync());
        }

        public async Task<IActionResult> ProblematicContracts()
        {
            var today = DateTime.Now;
            var problematicContracts = await _context.Contracts
                .Include(c => c.Person)
                .Include(c => c.InsuranceService)
                .Where(c => 
                    (c.Status == "Активный" && c.EndDate < today) ||
                    (c.Status == "Просрочен") ||
                    (c.Status == "Активный" && c.EndDate <= today.AddDays(30)))
                .OrderBy(c => c.EndDate)
                .ToListAsync();

            return View(problematicContracts);
        }

        public async Task<IActionResult> Report(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue)
                startDate = DateTime.Now.AddMonths(-1);
            if (!endDate.HasValue)
                endDate = DateTime.Now;

            var contracts = await _context.Contracts
                .Include(c => c.Person)
                .Include(c => c.InsuranceService)
                .Where(c => c.ContractDate >= startDate.Value && c.ContractDate <= endDate.Value)
                .OrderByDescending(c => c.ContractDate)
                .ToListAsync();

            ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");
            ViewBag.TotalAmount = contracts.Sum(c => c.Amount);
            ViewBag.TotalCount = contracts.Count;

            return View(contracts);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Person)
                .Include(c => c.InsuranceService)
                .Include(c => c.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name");
            ViewData["InsuranceServiceId"] = new SelectList(_context.InsuranceServices.Where(s => s.IsActive), "Id", "Name");
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractNumber,ContractDate,StartDate,EndDate,Amount,Status,Notes,PersonId,InsuranceServiceId,CreatedByUserId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                contract.CreatedAt = DateTime.Now;
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", contract.PersonId);
            ViewData["InsuranceServiceId"] = new SelectList(_context.InsuranceServices, "Id", "Name", contract.InsuranceServiceId);
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "FullName", contract.CreatedByUserId);
            return View(contract);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", contract.PersonId);
            ViewData["InsuranceServiceId"] = new SelectList(_context.InsuranceServices, "Id", "Name", contract.InsuranceServiceId);
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "FullName", contract.CreatedByUserId);
            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractNumber,ContractDate,StartDate,EndDate,Amount,Status,Notes,PersonId,InsuranceServiceId,CreatedByUserId,CreatedAt")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", contract.PersonId);
            ViewData["InsuranceServiceId"] = new SelectList(_context.InsuranceServices, "Id", "Name", contract.InsuranceServiceId);
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "FullName", contract.CreatedByUserId);
            return View(contract);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Person)
                .Include(c => c.InsuranceService)
                .Include(c => c.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract != null)
            {
                _context.Contracts.Remove(contract);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
