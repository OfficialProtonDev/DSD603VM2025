using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSD603VM2025.Data;
using DSD603VM2025.Models;
using AutoMapper;
using DSD603VM2025.ViewModels;

namespace DSD603VM2025.Controllers
{
    public class VisitorsController(ApplicationDbContext context, IMapper mapper) : Controller
    {

        // GET: Visitors
        public async Task<IActionResult> Index()
        {

            // Map Visitors to view model
            var visitorsVM = mapper.Map<IEnumerable<VisitorsVM>>(await context.Visitors.Include(v => v.StaffName).ToListAsync());

            return View(visitorsVM);
        }

        // GET: Visitors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitors = await context.Visitors
                .Include(v => v.StaffName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitors == null)
            {
                return NotFound();
            }

            // Map Visitors to view model
            var visitorsVM = mapper.Map<VisitorsVM>(visitors);

            return View(visitorsVM);
        }

        // GET: Visitors/Create
        public IActionResult Create()
        {
            ViewData["StaffNameId"] = new SelectList(context.StaffNames, "Id", "Name");

            Visitors visitors = new Visitors();
            visitors.DateIn = DateTime.Now;

            // Map Visitors to view model
            var visitorsVM = mapper.Map<VisitorsVM>(visitors);

            return View(visitorsVM);
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Business,DateIn,DateOut,StaffNameId")] Visitors visitors)
        {
            if (ModelState.IsValid)
            {
                visitors.Id = Guid.NewGuid();
                context.Add(visitors);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffNameId"] = new SelectList(context.StaffNames, "Id", "Id", visitors.StaffNameId);

            // Map Visitors to view model
            var visitorsVM = mapper.Map<VisitorsVM>(visitors);

            return View(visitorsVM);
        }

        // GET: Visitors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitors = await context.Visitors.FindAsync(id);
            if (visitors == null)
            {
                return NotFound();
            }
            ViewData["StaffNameId"] = new SelectList(context.StaffNames, "Id", "Name", visitors.StaffNameId);

            // Map Visitors to view model
            var visitorsVM = mapper.Map<VisitorsVM>(visitors);

            return View(visitorsVM);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Business,DateIn,DateOut,StaffNameId")] Visitors visitors)
        {
            if (id != visitors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(visitors);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorsExists(visitors.Id))
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
            ViewData["StaffNameId"] = new SelectList(context.StaffNames, "Id", "Id", visitors.StaffNameId);

            // Map Visitors to view model
            var visitorsVM = mapper.Map<VisitorsVM>(visitors);

            return View(visitorsVM);
        }

        // GET: Visitors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitors = await context.Visitors
                .Include(v => v.StaffName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitors == null)
            {
                return NotFound();
            }

            // Map Visitors to view model
            var visitorsVM = mapper.Map<VisitorsVM>(visitors);

            return View(visitorsVM);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var visitors = await context.Visitors.FindAsync(id);
            if (visitors != null)
            {
                context.Visitors.Remove(visitors);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorsExists(Guid id)
        {
            return context.Visitors.Any(e => e.Id == id);
        }
    }
}
