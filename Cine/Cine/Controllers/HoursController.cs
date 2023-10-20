using Cine.DAL;
using Cine.DAL.Entities;
using Cine.Helpers;
using Cine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cine.Controllers
{
    public class HoursController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly IDropDownListHelper _dropDownListHelper;

        public HoursController(DataBaseContext context, IDropDownListHelper dropDownListHelper)
        {
            _context= context;
            _dropDownListHelper = dropDownListHelper;
        }
        // GET: Genders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hours.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            AddHourViewModel addHourViewModel = new()
            {
                Movies = await _dropDownListHelper.GetDDLMoviesAsync(),
                
            };

            return View(addHourViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddHourViewModel addHourViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    Hour hour = new()
                    {
                        StarTime = addHourViewModel.StarTime,
                       
                        Date = addHourViewModel.Date,                      
                        CreatedDate = DateTime.Now,
                        Movie = await _context.Movies.FindAsync(addHourViewModel.MovieId),
    
                    };





                    _context.Add(hour);
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


            addHourViewModel.Movies = await _dropDownListHelper.GetDDLMoviesAsync();
            
            return View(addHourViewModel);
        }
    }
}
