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
    public class StaffNamesController(ApplicationDbContext context, IMapper mapper) : Controller
    {

        // GET: StaffNames
        public async Task<IActionResult> Index()
        {
            // Map StaffNames to view model
            var staffNamesVM = mapper.Map<IEnumerable<StaffNamesVM>>(await context.StaffNames.ToListAsync());

            return View(staffNamesVM);
        }

        // GET: StaffNames/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await context.StaffNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }

            // Map StaffNames to view model
            var staffNamesVM = mapper.Map<StaffNamesVM>(staffNames);

            return View(staffNamesVM);
        }

        // GET: StaffNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (ModelState.IsValid)
            {
                staffNames.Id = Guid.NewGuid();
                context.Add(staffNames);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Map StaffNames to view model
            var staffNamesVM = mapper.Map<StaffNamesVM>(staffNames);

            return View(staffNamesVM);
        }

        // GET: StaffNames/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await context.StaffNames.FindAsync(id);
            if (staffNames == null)
            {
                return NotFound();
            }

            // Map StaffNames to view model
            var staffNamesVM = mapper.Map<StaffNamesVM>(staffNames);

            return View(staffNamesVM);
        }

        // POST: StaffNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (id != staffNames.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(staffNames);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffNamesExists(staffNames.Id))
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

            // Map StaffNames to view model
            var staffNamesVM = mapper.Map<StaffNamesVM>(staffNames);

            return View(staffNamesVM);
        }

        // GET: StaffNames/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await context.StaffNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }

            // Map StaffNames to view model
            var staffNamesVM = mapper.Map<StaffNamesVM>(staffNames);

            return View(staffNamesVM);
        }

        // POST: StaffNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var staffNames = await context.StaffNames.FindAsync(id);
            if (staffNames != null)
            {
                context.StaffNames.Remove(staffNames);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffNamesExists(Guid id)
        {
            return context.StaffNames.Any(e => e.Id == id);
        }
    }
}
