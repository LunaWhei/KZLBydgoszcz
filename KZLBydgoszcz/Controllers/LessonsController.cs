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
    public class LessonsController : Controller
    {
        private readonly StudentContext _context;

        public LessonsController(StudentContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var studentContext = _context.Lessons.Include(l => l.Student_class).Include(l => l.Teachers);
            return View(await studentContext.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons
                .Include(l => l.Student_class)
                .Include(l => l.Teachers)
                .FirstOrDefaultAsync(m => m.LessonID == id);
            if (lessons == null)
            {
                return NotFound();
            }

            return View(lessons);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["Student_classID"] = new SelectList(_context.class_Names, "Student_classID", "Class_identificator");
            ViewData["TeachersId"] = new SelectList(_context.Teachers, "Id", "LastName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonID,LessonName,Student_classID,TeachersId")] Lessons lessons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Student_classID"] = new SelectList(_context.class_Names, "Student_classID", "Class_identificator", lessons.Student_classID);
            ViewData["TeachersId"] = new SelectList(_context.Teachers, "Id", "LastName", lessons.TeachersId);
            return View(lessons);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons.FindAsync(id);
            if (lessons == null)
            {
                return NotFound();
            }
            ViewData["Student_classID"] = new SelectList(_context.class_Names, "Student_classID", "Student_classID", lessons.Student_classID);
            ViewData["TeachersId"] = new SelectList(_context.Teachers, "Id", "Id", lessons.TeachersId);
            return View(lessons);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonID,LessonName,Student_classID,TeachersId")] Lessons lessons)
        {
            if (id != lessons.LessonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonsExists(lessons.LessonID))
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
            ViewData["Student_classID"] = new SelectList(_context.class_Names, "Student_classID", "Student_classID", lessons.Student_classID);
            ViewData["TeachersId"] = new SelectList(_context.Teachers, "Id", "Id", lessons.TeachersId);
            return View(lessons);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons
                .Include(l => l.Student_class)
                .Include(l => l.Teachers)
                .FirstOrDefaultAsync(m => m.LessonID == id);
            if (lessons == null)
            {
                return NotFound();
            }

            return View(lessons);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessons = await _context.Lessons.FindAsync(id);
            _context.Lessons.Remove(lessons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonsExists(int id)
        {
            return _context.Lessons.Any(e => e.LessonID == id);
        }
    }
}
