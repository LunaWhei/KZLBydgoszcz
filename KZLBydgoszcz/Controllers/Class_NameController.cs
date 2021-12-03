using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KZLBydgoszcz.Models;

namespace KZLBydgoszcz.Controllers
{
    public class Class_NameController : Controller
    {
        private readonly StudentContext _context;

        public Class_NameController(StudentContext context)
        {
            _context = context;
        }

        // GET: Class_Name
        public async Task<IActionResult> Index()
        {
            return View(await _context.class_Names.ToListAsync());
        }

        // GET: Class_Name/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class_Name = await _context.class_Names
                .FirstOrDefaultAsync(m => m.Student_classID == id);
            if (class_Name == null)
            {
                return NotFound();
            }

            return View(class_Name);
        }

        // GET: Class_Name/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Class_Name/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Student_classID,Class_identificator")] Class_Name class_Name)
        {
            if (ModelState.IsValid)
            {
                _context.Add(class_Name);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(class_Name);
        }

        // GET: Class_Name/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class_Name = await _context.class_Names.FindAsync(id);
            if (class_Name == null)
            {
                return NotFound();
            }
            return View(class_Name);
        }

        // POST: Class_Name/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Student_classID,Class_identificator")] Class_Name class_Name)
        {
            if (id != class_Name.Student_classID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(class_Name);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Class_NameExists(class_Name.Student_classID))
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
            return View(class_Name);
        }

        // GET: Class_Name/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class_Name = await _context.class_Names
                .FirstOrDefaultAsync(m => m.Student_classID == id);
            if (class_Name == null)
            {
                return NotFound();
            }

            return View(class_Name);
        }

        // POST: Class_Name/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var class_Name = await _context.class_Names.FindAsync(id);
            _context.class_Names.Remove(class_Name);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Class_NameExists(int id)
        {
            return _context.class_Names.Any(e => e.Student_classID == id);
        }
    }
}
