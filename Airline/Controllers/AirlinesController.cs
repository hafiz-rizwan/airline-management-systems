using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirlineManagement.Models; // Updated namespace

namespace AirlineManagement.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly NeondbContext _context;

        public AirlinesController(NeondbContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airlines.ToListAsync());
        }

        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines
                .FirstOrDefaultAsync(m => m.AirlineId == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // GET: Airlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirlineId,AirlineName,Country,ContactNumber")] AirlineManagement.Models.Airline airline) // Fully qualified
        {
            if (ModelState.IsValid)
            {
                _context.Add(airline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airline);
        }

        // GET: Airlines/Edit/5
        public IActionResult Edit(int id)
        {
            var airline = _context.Airlines.Find(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AirlineManagement.Models.Airline airline) // Fully qualified
        {
            if (ModelState.IsValid)
            {
                _context.Update(airline);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(airline);
        }

        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines
                .FirstOrDefaultAsync(m => m.AirlineId == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airline = await _context.Airlines.FindAsync(id);
            if (airline != null)
            {
                _context.Airlines.Remove(airline);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
            return _context.Airlines.Any(e => e.AirlineId == id);
        }
    }
}
