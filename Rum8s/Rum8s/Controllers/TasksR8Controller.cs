using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rum8s.Data;
using Rum8s.Models;

namespace Rum8s.Controllers
{
    public class TasksR8Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksR8Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TasksR8
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tasks.Include(t => t.Group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TasksR8/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasksR8 = await _context.tasks
                .Include(t => t.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasksR8 == null)
            {
                return NotFound();
            }

            return View(tasksR8);
        }

        // GET: TasksR8/Create
        public IActionResult Create()
        {
            ViewData["GroupR8Id"] = new SelectList(_context.groups, "Id", "Name");
            return View();
        }

        // POST: TasksR8/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,GroupR8Id")] TasksR8 tasksR8)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasksR8);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupR8Id"] = new SelectList(_context.groups, "Id", "Name", tasksR8.GroupR8Id);
            return View(tasksR8);
        }

        // GET: TasksR8/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasksR8 = await _context.tasks.FindAsync(id);
            if (tasksR8 == null)
            {
                return NotFound();
            }
            ViewData["GroupR8Id"] = new SelectList(_context.groups, "Id", "Name", tasksR8.GroupR8Id);
            return View(tasksR8);
        }

        // POST: TasksR8/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,GroupR8Id")] TasksR8 tasksR8)
        {
            if (id != tasksR8.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasksR8);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksR8Exists(tasksR8.Id))
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
            ViewData["GroupR8Id"] = new SelectList(_context.groups, "Id", "Name", tasksR8.GroupR8Id);
            return View(tasksR8);
        }

        // GET: TasksR8/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasksR8 = await _context.tasks
                .Include(t => t.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasksR8 == null)
            {
                return NotFound();
            }

            return View(tasksR8);
        }

        // POST: TasksR8/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasksR8 = await _context.tasks.FindAsync(id);
            _context.tasks.Remove(tasksR8);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksR8Exists(int id)
        {
            return _context.tasks.Any(e => e.Id == id);
        }
    }
}
