using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPrimerParcial.Data;
using ProyectoPrimerParcial.Models;
using ProyectoPrimerParcial.ViewModels;
using ProyectoPrimerParcial2.ViewModels;

namespace Test.Controllers
{
    public class HangarController : Controller
    {
        private readonly AeronaveContext _context;

        public HangarController(AeronaveContext context)
        {
            _context = context;
        }

        // GET: Hangar
        public async Task<IActionResult> Index(string nameFilterHan)
        {
            var query = from hangar in _context.Hangar select hangar;

            if (!string.IsNullOrEmpty(nameFilterHan))
            {
                query = query.Where(x => x.NombreHangar.Contains(nameFilterHan));
                // query = query.Where(x => x.NombreHangar.Contains(nameFilterHan) || x.Sector.Contains(nameFilterHan));
            }

            var model = new HangarIndexViewmodel();
            model.hangars =await query.ToListAsync();
            
            return _context.Aeronave != null ?
            View(model):
            Problem("Entity set 'AeronaveContex.Aeronave' is null.");
        }

        // GET: Hangar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hangar == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangar
                .FirstOrDefaultAsync(m => m.HangarId == id);
            if (hangar == null)
            {
                return NotFound();
            }

            var viewModel = new HangarDetailViewModel();
            viewModel.HangarId = hangar.HangarId;
            viewModel.NombreHangar = hangar.NombreHangar;
            viewModel.Sector = hangar.Sector;
            viewModel.AptoMantenimiento = hangar.AptoMantenimiento;
            viewModel.Aeronaves = hangar.Aeronaves;


            return View(viewModel);
        }

        // GET: Hangar/Create
        public IActionResult Create()
        {
            ViewData["Aeronaves"] = _context.Aeronave.ToList();
            return View();
        }

        // POST: Hangar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HangarId,NombreHangar,Sector,AptoMantenimiento,oficinas")] HangarCreateViewModel hangarView)
        {
            if (ModelState.IsValid)
            {
                var hangar = new Hangar{
                    NombreHangar = hangarView.NombreHangar,
                    Sector = hangarView.Sector,
                    AptoMantenimiento = hangarView.AptoMantenimiento,
                    oficinas = hangarView.oficinas,
                    Aeronaves = hangarView.Aeronaves
                };
                _context.Add(hangar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangarView);
        }

        // GET: Hangar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hangar == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangar.FindAsync(id);
            if (hangar == null)
            {
                return NotFound();
            }

            var viewModel = new HangarEditViewModel();
            viewModel.HangarId = hangar.HangarId;
            viewModel.NombreHangar = hangar.NombreHangar;
            viewModel.Sector = hangar.Sector;
            viewModel.AptoMantenimiento = hangar.AptoMantenimiento;
            viewModel.Aeronaves = hangar.Aeronaves;


            return View(viewModel);
            // ViewData["Aeronaves"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave",  "instructor.AeronaveId");
            // return View(hangar);
        }

        // POST: Hangar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HangarId,NombreHangar,Sector,AptoMantenimiento,oficinas,Aeronaves")] Hangar hangar)
        {
            if (id != hangar.HangarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangarExists(hangar.HangarId))
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
            return View(hangar);
        }

        // GET: Hangar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hangar == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangar
                .FirstOrDefaultAsync(m => m.HangarId == id);
            if (hangar == null)
            {
                return NotFound();
            }
            var viewModel = new HangarDeleteViewModel();
            // viewModel.HangarId = hangar.HangarId;
            viewModel.NombreHangar = hangar.NombreHangar;
            viewModel.Sector = hangar.Sector;
            viewModel.AptoMantenimiento = hangar.AptoMantenimiento;
            viewModel.Aeronaves = hangar.Aeronaves;

            return View(viewModel);
        }

        // POST: Hangar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hangar == null)
            {
                return Problem("Entity set 'AeronaveContext.Hangar'  is null.");
            }
            var hangar = await _context.Hangar.FindAsync(id);
            if (hangar != null)
            {
                _context.Hangar.Remove(hangar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangarExists(int id)
        {
          return (_context.Hangar?.Any(e => e.HangarId == id)).GetValueOrDefault();
        }
    }
}
