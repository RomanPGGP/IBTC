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
    public class GroupR8Controller : Controller
    {
        public List<string> selectedUsers;
        private readonly ApplicationDbContext _context;

        public GroupR8Controller(ApplicationDbContext context)
        {
            _context = context;
            selectedUsers = new List<string>();
        }

        // GET: GroupR8
        public async Task<IActionResult> Index()
        {
            return View(await _context.groups.ToListAsync());
        }

        // GET: GroupR8/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupR8 = await _context.groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupR8 == null)
            {
                return NotFound();
            }

            return View(groupR8);
        }

        // GET: GroupR8/Create
        public IActionResult Create()
        {

            ViewData["Users"] = _context.Users.ToList();
            return View();
        }

        // POST: GroupR8/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] GroupR8 groupR8)
        {

            if (ModelState.IsValid)
            {
                _context.Add(groupR8);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupR8);
        }

        [HttpPost]
        public IActionResult updateSelectedUsers(string name)
        {
            selectedUsers.Add(name);
            Console.WriteLine(name);
            ViewData["selectedUsers"] = selectedUsers;
            return View("Create");
        }
        // GET: GroupR8/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupR8 = await _context.groups.FindAsync(id);
            if (groupR8 == null)
            {
                return NotFound();
            }
            return View(groupR8);
        }

        // POST: GroupR8/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] GroupR8 groupR8)
        {
            if (id != groupR8.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupR8);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupR8Exists(groupR8.Id))
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
            return View(groupR8);
        }

        // GET: GroupR8/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupR8 = await _context.groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupR8 == null)
            {
                return NotFound();
            }

            return View(groupR8);
        }



        // POST: GroupR8/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupR8 = await _context.groups.FindAsync(id);
            _context.groups.Remove(groupR8);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupR8Exists(int id)
        {
            return _context.groups.Any(e => e.Id == id);
        }
    }
}
