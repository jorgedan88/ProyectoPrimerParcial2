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
    public class AeronaveController : Controller
    {
        private readonly AeronaveContext _context;

        public AeronaveController(AeronaveContext context)
        {
            _context = context;
        }

        // // GET: Aeronave
        // public async Task<IActionResult> Index(string nameFilter)
        public async Task<IActionResult> Index(string nameFilter ,[Bind("TipoAeronave,FechaFabricacion")] AeronaveCreateViewModel aeronaveView)


        {
            var query = from aeronave in _context.Aeronave select aeronave;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.TipoAeronave.Contains(nameFilter));
            }

            var model = new AeronaveIndexViewmodels();
            model.aeronaves =await query.ToListAsync();
            
            return _context.Aeronave != null ?
            View(model):
            Problem("Entity set 'AeronaveContex.Aeronave' is null.");

        }



        // GET: Aeronave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave
                .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            var viewModel = new AeronaveDetailViewModel();
            viewModel.FechaFabricacion = aeronave.FechaFabricacion;
            viewModel.TipoAeronave = aeronave.TipoAeronave;
            

            return View(viewModel);
        }

        // GET: Aeronave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aeronave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoAeronave,FechaFabricacion")] AeronaveCreateViewModel aeronaveView)
        {
            if (ModelState.IsValid)
            {
                var aeronave = new Aeronave{
                    FechaFabricacion = aeronaveView.FechaFabricacion,
                    TipoAeronave = aeronaveView.TipoAeronave,
                };
                _context.Add(aeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeronaveView);
        }

        // GET: Aeronave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }

            var viewModel = new AeronaveEditViewModel();
            viewModel.FechaFabricacion = aeronave.FechaFabricacion;
            viewModel.TipoAeronave = aeronave.TipoAeronave;
            

            return View(viewModel);

            // return View(aeronave);
        }

        // POST: Aeronave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("AeronaveId,TipoAeronave,FechaFabricacion")] AeronaveEditViewModel aeronaveView)
        {
            if (id != aeronaveView.AeronaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var aeronave = new Aeronave{
                    FechaFabricacion = aeronaveView.FechaFabricacion,
                    TipoAeronave = aeronaveView.TipoAeronave,
                };
                try
                {
                    _context.Update(aeronaveView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeronaveExists(aeronaveView.AeronaveId))
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
            return View(aeronaveView);
        }

        // GET: Aeronave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave
                .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }

        // POST: Aeronave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aeronave == null)
            {
                return Problem("Entity set 'AeronaveContext.Aeronave'  is null.");
            }
            var aeronave = await _context.Aeronave.FindAsync(id);
            if (aeronave != null)
            {
                _context.Aeronave.Remove(aeronave);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeronaveExists(int id)
        {
            return (_context.Aeronave?.Any(e => e.AeronaveId == id)).GetValueOrDefault();
        }
    }
}
