using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPrimerParcial.Data;
using ProyectoPrimerParcial.Models;

namespace Test.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AeronaveContext _context;

        public InstructorController(AeronaveContext context)
        {
            _context = context;
        }

        // GET: Instructor
        public async Task<IActionResult> Index()
        {
            var aeronaveContext = _context.Instructor.Include(i => i.Aeronave);
            return View(await aeronaveContext.ToListAsync());
        }

        // GET: Instructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .Include(i => i.Aeronave)
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Instructor/Create
        public IActionResult Create()
        {
            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave");
            return View();
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,NombreInstructor,Apellido,DNI,LegajoVuelo,AeronaveId")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave", instructor.AeronaveId);
            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave", instructor.AeronaveId);
            return View(instructor);
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,NombreInstructor,Apellido,DNI,LegajoVuelo,AeronaveId")] Instructor instructor)
        {
            if (id != instructor.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.InstructorId))
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
            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave", instructor.AeronaveId);
            return View(instructor);
        }

        // GET: Instructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .Include(i => i.Aeronave)
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instructor == null)
            {
                return Problem("Entity set 'AeronaveContext.Instructor'  is null.");
            }
            var instructor = await _context.Instructor.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructor.Remove(instructor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
          return (_context.Instructor?.Any(e => e.InstructorId == id)).GetValueOrDefault();
        }
    }
}
