using Cine.DAL;
using Cine.DAL.Entities;
using Cine.Helpers;
using Cine.Models;
using Cine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Cine.Controllers
{
    public class MoviesController : Controller
    {

        private readonly DataBaseContext _context;
        private readonly IDropDownListHelper _dropDownListHelper;

        public MoviesController(DataBaseContext context, IDropDownListHelper dropDownListHelper)
        {
            _context = context;
            _dropDownListHelper = dropDownListHelper;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            
            AddMovieViewModel addMovieViewModel = new()
            {
                Genders = await _dropDownListHelper.GetDDLGendersAsync(),
                Classifications = await _dropDownListHelper.GetDDLClassificationsAsync(),   
            };

            return View(addMovieViewModel);
        }

        //--------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMovieViewModel addMovieViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    Movie movie = new()
                    {
                        Title = addMovieViewModel.Title,
                        Description = addMovieViewModel.Description,
                        Director = addMovieViewModel.Director,
                        Duration = addMovieViewModel.Duration,
                        CreatedDate = DateTime.Now,
                        Gender = await _context.Genders.FindAsync(addMovieViewModel.GenderId),
                        Classification = await _context.Classifications.FindAsync(addMovieViewModel.ClassificationId),


                    };





                    _context.Add(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un producto con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }


            addMovieViewModel.Genders = await _dropDownListHelper.GetDDLGendersAsync();
            addMovieViewModel.Classifications = await _dropDownListHelper.GetDDLClassificationsAsync();
            return View(addMovieViewModel);
        }


        //-----------------------







        /*


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMovieViewModel addMovieViewModel)
        {
            if (ModelState.IsValid)
            {
                // Verificar si ya existe una pelicula con el mismo titulo
                bool Exists = await _context.Movies
                    .AnyAsync(v => v.Title == addMovieViewModel.Title);

                if (Exists)
                {
                    ModelState.AddModelError(string.Empty, "Ya se ha registrado una pelicula con el mismo titulo");
                    TempData["PeliculaNoIngresada"] = "No Se ingreso correctamente";
                    return View(addMovieViewModel);
                }
                else
                {
                    try 
                    {
                        Movie movie = new()
                        {
                            CreatedDate = DateTime.Now,
                            GenderId = addMovieViewModel.GenderId,
                            //Gender = await _context.Genders.FindAsync(addMovieViewModel.GenderId),
                            //Classification = await _context.Classifications.FindAsync(addMovieViewModel.ClassificationId),
                            ClassificationId = addMovieViewModel.ClassificationId,
                            Title = addMovieViewModel.Title,
                            Description = addMovieViewModel.Description,
                            Director = addMovieViewModel.Director,
                            Duration = addMovieViewModel.Duration,
                        };

                        TempData["PeliculaIngresada"] = "Se ingreso correctamente";
                        _context.Add(movie);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception exception)
                    {
                        ModelState.AddModelError(string.Empty, exception.Message);
                    }
                }
            }

            addMovieViewModel.Genders = await _dropDownListHelper.GetDDLGendersAsync();
            addMovieViewModel.Classifications = await _dropDownListHelper.GetDDLClassificationsAsync();
            return View(addMovieViewModel);
        }
        */


        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            
            if (Id == null) return NotFound();

            Movie movie = await _context.Movies.FindAsync(Id);
            if (movie == null) return NotFound();

            EditMovieViewModel editMovietViewModel = new()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,  
                Duration = movie.Duration,
                GenderId= movie.GenderId,
                ClassificationId= movie.ClassificationId,
                Genders = await _dropDownListHelper.GetDDLGendersAsync(),
                Classifications = await _dropDownListHelper.GetDDLClassificationsAsync(),
                
            };

            return View(editMovietViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id, EditMovieViewModel editMovietViewModel)
        {
            if (Id != editMovietViewModel.Id) return NotFound();

            try
            {
                Movie movie = await _context.Movies.FindAsync(editMovietViewModel.Id);

                //Aquí sobreescribo para luego guardar los cambios en BD
                movie.Title = editMovietViewModel.Title;
                movie.Description = editMovietViewModel.Description;
                movie.Director = editMovietViewModel.Director;
                movie.Duration = editMovietViewModel.Duration;
                movie.Gender = await _context.Genders.FindAsync(editMovietViewModel.GenderId);
                movie.Classification = await _context.Classifications.FindAsync(editMovietViewModel.ClassificationId);
                movie.ModifiedDate = DateTime.Now;

                _context.Update(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    ModelState.AddModelError(string.Empty, "Ya existe una pelicula con el mismo nombre.");
                else
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
            await FillDropDownListLocation(editMovietViewModel);
            return View(editMovietViewModel);
        }


        // DropDownListLocation es la lista desplegable de los paises, estados y ciudades
        private async Task FillDropDownListLocation(EditMovieViewModel addMovieViewModel)
        {
            addMovieViewModel.Genders = await _dropDownListHelper.GetDDLGendersAsync();
            addMovieViewModel.Classifications = await _dropDownListHelper.GetDDLClassificationsAsync();
        }

        private bool Exists(int id)
        {
            return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null) return NotFound();

            Movie movie = await _context.Movies.FirstOrDefaultAsync(p => p.Id == Id);

            if (movie == null) return NotFound();

            return View(movie);
        }
    }
}
