using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cine.DAL;
using Cine.DAL.Entities;

namespace Cine.Controllers
{
    public class ClassificationsController : Controller
    {
        private readonly DataBaseContext _context;

        public ClassificationsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Classifications
        public async Task<IActionResult> Index()
        {
              return _context.Classifications != null ? 
                          View(await _context.Classifications.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Classifications'  is null.");
        }

        // GET: Classifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classifications == null)
            {
                return NotFound();
            }

            var classification = await _context.Classifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classification == null)
            {
                return NotFound();
            }

            return View(classification);
        }

        // GET: Classifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Classification classification)
        {
            if (ModelState.IsValid)
            {

                // Verificar si ya existe una Clasificacion con el mismo nombre
                bool Exists = await _context.Classifications
                    .AnyAsync(v => v.ClassificationName == classification.ClassificationName);

                if (Exists) // Se valida si el reultado de la variable es true o false
                {
                    // Si la variable es true se envia un mensaje 
                    ModelState.AddModelError(string.Empty, "Ya se ha registrado una clasificación con el mismo nombre");
                    TempData["ClasificacionIngresada"] = "No Se ingreso correctamente";
                }
                else
                { // Si la variable es false entonces se crea la clasificación
                    try 
                    {
                        TempData["ClasificacionIngresada"] = "Se ingreso correctamente";
                        classification.CreatedDate = DateTime.Now;
                        _context.Add(classification);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    } 
                    catch (Exception exception)
                    {
                        ModelState.AddModelError(string.Empty, exception.Message);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classification);
        }

        // GET: Classifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classifications == null)
            {
                return NotFound();
            }

            var classification = await _context.Classifications.FindAsync(id);
            if (classification == null)
            {
                return NotFound();
            }
            return View(classification);
        }

        // POST: Classifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Classification classification)
        {
            if (id != classification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["ClasificacionEditada"] = "Se modifico correctamente";
                    classification.ModifiedDate = DateTime.Now;
                    _context.Update(classification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificationExists(classification.Id))
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
            return View(classification);
        }

        // GET: Classifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classifications == null)
            {
                return NotFound();
            }

            var classification = await _context.Classifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classification == null)
            {
                return NotFound();
            }

            return View(classification);
        }

        // POST: Classifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classifications == null)
            {
                return Problem("Entity set 'DataBaseContext.Classifications'  is null.");
            }
            var classification = await _context.Classifications.FindAsync(id);
            if (classification != null)
            {
                _context.Classifications.Remove(classification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificationExists(int id)
        {
          return (_context.Classifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
