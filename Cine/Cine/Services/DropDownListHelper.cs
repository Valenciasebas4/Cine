﻿using Cine.DAL;
using Cine.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cine.Services
{
    public class DropDownListHelper : IDropDownListHelper
    {

        public readonly DataBaseContext _context;

        public DropDownListHelper(DataBaseContext context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<SelectListItem>> GetDDLRoomsAsync()
        {
            List<SelectListItem> listRooms = await _context.Rooms
                .Select(c => new SelectListItem
                {
                    Text = c.NumberRoom,
                    Value = c.Id.ToString(),
                })
                .OrderBy(c => c.Text)
                .ToListAsync();

            listRooms.Insert(0, new SelectListItem
            {
                Text = "Seleccione una Sala...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listRooms;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLSeatsAsync()
        {
            List<SelectListItem> listSeats = await _context.Seats
               .Select(c => new SelectListItem
               {
                   Text = c.NumberSeat,
                   Value = c.Id.ToString(),
               })
               .OrderBy(c => c.Text)
               .ToListAsync();

            listSeats.Insert(0, new SelectListItem
            {
                Text = "Seleccione una Silla...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listSeats;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLClassificationsAsync()
        {
            List<SelectListItem> listClassifications = await _context.Classifications
               .Select(c => new SelectListItem
               {
                   Text = c.ClassificationName,
                   Value = c.Id.ToString(),
               })
               .OrderBy(c => c.Text)
               .ToListAsync();

            listClassifications.Insert(0, new SelectListItem
            {
                Text = "Seleccione una Clasificación...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listClassifications;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLGendersAsync()
        {
            List<SelectListItem> listGenders = await _context.Genders
              .Select(c => new SelectListItem
              {
                  Text = c.GenderName,
                  Value = c.Id.ToString(),
              })
              .OrderBy(c => c.Text)
              .ToListAsync();

            listGenders.Insert(0, new SelectListItem
            {
                Text = "Seleccione un Genero...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listGenders;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLMoviesAsync()
        {
            List<SelectListItem> listMovies = await _context.Movies
              .Select(c => new SelectListItem
              {
                  Text = c.Title,
                  Value = c.Id.ToString(),
              })
              .OrderBy(c => c.Text)
              .ToListAsync();

            listMovies.Insert(0, new SelectListItem
            {
                Text = "Seleccione una Pelicula...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listMovies;
        }
    }
}
