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
        public async Task<IActionResult> Index(string nameFilterIns)
        {
            var query = from instructor in _context.Instructor.Include(i => i.Aeronave) select instructor;

            if (!string.IsNullOrEmpty(nameFilterIns))
            {
                query = query.Where(x => x.NombreInstructor.Contains(nameFilterIns) || x.Apellido.Contains(nameFilterIns) || x.DNI.ToString() == nameFilterIns);
            }

            var model = new InstructorIndexViewmodels();
            model.instructors =await query.ToListAsync();
            
            return _context.Aeronave != null ?
            View(model):
            Problem("Entity set 'AeronaveContex.Aeronave' is null.");

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

            var viewModel  = new InstructorDetailViewModel();
                viewModel.NombreInstructor = instructor.NombreInstructor;
                viewModel.Apellido = instructor.Apellido;
                viewModel.DNI = instructor.DNI;
                viewModel.TipoLicencia = instructor.TipoLicencia;
                viewModel.NumeroLicencia = instructor.NumeroLicencia;
                viewModel.FechaExpedicion = instructor.FechaExpedicion;
                viewModel.EnActividad = instructor.EnActividad;
                viewModel.Aeronave = instructor.Aeronave;

            return View(viewModel);
        }
        // GET: Instructor/Create
        public IActionResult Create()
        {//esta linea esta en la version sin ViewModels
            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave");
            return View();
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,NombreInstructor,Apellido,DNI,TipoLicencia,NumeroLicencia,FechaExpedicion,EnActividad,AeronaveId")] InstructorCreateViewModel instructorView)
        {
            if (ModelState.IsValid)
            {
                var instructor = new Instructor{
                    NombreInstructor = instructorView.NombreInstructor,
                    Apellido = instructorView.Apellido,
                    DNI = instructorView.DNI,
                    TipoLicencia = instructorView.TipoLicencia,
                    NumeroLicencia = instructorView.NumeroLicencia,
                    FechaExpedicion = instructorView.FechaExpedicion,
                    EnActividad = instructorView.EnActividad,
                    Aeronave = instructorView.Aeronave
                    
                };
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AeronaveId"] = new SelectList("AeronaveId", "TipoAeronave");
            return View(instructorView);
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


            var viewModel  = new InstructorEditViewModel();
            viewModel.NombreInstructor = instructor.NombreInstructor;
            viewModel.Apellido = instructor.Apellido;
            viewModel.DNI = instructor.DNI;
            viewModel.TipoLicencia = instructor.TipoLicencia;
            viewModel.NumeroLicencia = instructor.NumeroLicencia;
            viewModel.FechaExpedicion = instructor.FechaExpedicion;
            viewModel.EnActividad = instructor.EnActividad;
            viewModel.AeronaveId = instructor.AeronaveId;

            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave");
            return View(viewModel);
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,NombreInstructor,Apellido,DNI,TipoLicencia,NumeroLicencia,FechaExpedicion,EnActividad")] Instructor instructor)
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
            var viewModel  = new InstructorEditViewModel();
            viewModel.NombreInstructor = instructor.NombreInstructor;
            viewModel.Apellido = instructor.Apellido;
            viewModel.DNI = instructor.DNI;
            viewModel.TipoLicencia = instructor.TipoLicencia;
            viewModel.NumeroLicencia = instructor.NumeroLicencia;
            viewModel.FechaExpedicion = instructor.FechaExpedicion;
            viewModel.EnActividad = instructor.EnActividad;
            viewModel.AeronaveId = instructor.AeronaveId;

            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave",  "instructor.AeronaveId");
            return View(viewModel);
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
            var viewModel  = new InstructorDeleteViewModel();
            viewModel.NombreInstructor = instructor.NombreInstructor;
            viewModel.Apellido = instructor.Apellido;
            viewModel.DNI = instructor.DNI;
            viewModel.TipoLicencia = instructor.TipoLicencia;
            viewModel.NumeroLicencia = instructor.NumeroLicencia;
            viewModel.FechaExpedicion = instructor.FechaExpedicion;
            viewModel.EnActividad = instructor.EnActividad;
            viewModel.Aeronave = instructor.Aeronave; 

            return View(viewModel);
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
