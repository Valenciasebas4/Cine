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
                            Gender = await _context.Genders.FindAsync(addMovieViewModel.GenderId),
                            Classification = await _context.Classifications.FindAsync(addMovieViewModel.ClassificationId),
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

    }
}
