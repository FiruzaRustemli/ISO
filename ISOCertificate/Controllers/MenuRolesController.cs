using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISOCertificate.DAL;
using ISOCertificate.Models;

namespace ISOCertificate.Controllers
{
    public class MenuRolesController : Controller
    {
        private readonly CertificateDbContext _context;

        public MenuRolesController(CertificateDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var certificateDbContext = _context.MenuRole.Include(m => m.Menu).Include(m => m.Role);
            return View(await certificateDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuRole = await _context.MenuRole
                .Include(m => m.Menu)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuRole == null)
            {
                return NotFound();
            }

            return View(menuRole);
        }

        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuId,RoleId")] MenuRole menuRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name", menuRole.MenuId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", menuRole.RoleId);
            return View(menuRole);
        }

        // GET: MenuRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuRole = await _context.MenuRole.FindAsync(id);
            if (menuRole == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name", menuRole.MenuId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", menuRole.RoleId);
            return View(menuRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MenuId,RoleId")] MenuRole menuRole)
        {
            if (id != menuRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuRoleExists(menuRole.Id))
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
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name", menuRole.MenuId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", menuRole.RoleId);
            return View(menuRole);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuRole = await _context.MenuRole
                .Include(m => m.Menu)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuRole == null)
            {
                return NotFound();
            }

            return View(menuRole);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuRole = await _context.MenuRole.FindAsync(id);
            _context.MenuRole.Remove(menuRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuRoleExists(int id)
        {
            return _context.MenuRole.Any(e => e.Id == id);
        }
    }
}
