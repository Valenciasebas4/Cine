using Cine.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Cine.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context)
        {
            _context = context;
            

        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateGenderAsync();
            await PopulateClassificationAsync();
            await PopulateRoomSeatAsync();
            await PopulateMoviesAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateGenderAsync()
        {
            if (!_context.Genders.Any())
            {
                _context.Genders.Add(new Gender { GenderName = "Acción", Description = "Películas llenas de emocionantes escenas de acción.", CreatedDate = DateTime.Now});
                _context.Genders.Add(new Gender { GenderName = "Comedia", Description = "Películas divertidas y humorísticas.", CreatedDate = DateTime.Now });
                _context.Genders.Add(new Gender { GenderName = "Drama", Description = "Películas con un enfoque en la narrativa y las emociones.", CreatedDate = DateTime.Now });
                _context.Genders.Add(new Gender { GenderName = "Ciencia Ficción", Description = "Películas que exploran mundos futuristas y tecnología avanzada.", CreatedDate = DateTime.Now });
                _context.Genders.Add(new Gender { GenderName = "Animación", Description = "Películas animadas para todas las edades.", CreatedDate = DateTime.Now });

            }

        }

        private async Task PopulateClassificationAsync()
        {
            if (!_context.Classifications.Any())
            {
                _context.Classifications.Add(new Classification { ClassificationName = "G", Description = "Apto para todos los públicos: Las películas con esta clasificación son adecuadas para todo tipo de audiencia, incluidos niños. No contienen contenido violento, sexual, lenguaje fuerte ni temáticas perturbadoras.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { ClassificationName = "PG", Description = "Supervisión de los padres recomendada: Las películas con esta clasificación pueden contener algún contenido que no sea apropiado para niños pequeños. Los padres pueden considerar adecuado ver estas películas con sus hijos más jóvenes.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { ClassificationName = "PG-13", Description = "Se recomienda la orientación de los padres para menores de 13 años: Las películas PG-13 pueden contener un material más fuerte que las películas PG, como violencia moderada, lenguaje fuerte, temáticas más intensas y situaciones sugerentes. No son apropiadas para niños menores de 13 años sin la orientación de los padres.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { ClassificationName = "R", Description = "Restringida: Las películas con clasificación R son apropiadas solo para adultos o para adolescentes con la orientación de un adulto. Pueden contener violencia intensa, contenido sexual explícito, lenguaje fuerte y/o consumo de drogas.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { ClassificationName = "NC-17 o X", Description = "Solo para adultos: Las películas con clasificación NC-17 (o X en algunos sistemas de clasificación) están destinadas exclusivamente para adultos. Pueden contener contenido sexual explícito, violencia extrema u otras temáticas adultas.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { ClassificationName = "NR o Sin clasificación", Description = "Algunas películas no reciben una clasificación oficial, lo que significa que no han sido evaluadas por una junta de clasificación. Esto puede deberse a razones varias, como películas independientes o lanzamientos en línea que no pasaron por el proceso de clasificación.", CreatedDate = DateTime.Now });


            }

        }

       /*private async Task PopulateRoomsAsync()
        {
            if (!_context.Rooms.Any())
            {
                _context.Rooms.Add(new Room { NumberRoom = "Uno", Capacity = 50, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { NumberRoom = "Dos", Capacity = 100, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { NumberRoom = "Tres", Capacity = 40, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { NumberRoom = "Cuatro", Capacity = 120, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { NumberRoom = "Cinco", Capacity = 60, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { NumberRoom = "Seis", Capacity = 80, CreatedDate = DateTime.Now });

            }

        }
        */
        private async Task PopulateMoviesAsync()
        {
            if (!_context.Movies.Any())
            {
                _context.Movies.Add(new Movie { Title="El Padrino",
                                                Description = "Una película de mafia dirigida por Francis Ford Coppola.",
                                                Director= "Francis Ford Coppola", 
                                                Duration=175,
                                                GenderId=1,
                                                ClassificationId=2,
                                                CreatedDate = DateTime.Now 
                                              }
                                    );
                _context.Movies.Add(new Movie { Title = "Cadena Perpetua",
                                                Description = "Una película carcelaria basada en una novela de Stephen King.",
                                                Director = "Frank Darabont",
                                                Duration = 142,
                                                GenderId = 3,
                                                ClassificationId = 3,
                                                CreatedDate = DateTime.Now
                                              }
                                   );

            }

        }


        private async Task PopulateRoomSeatAsync()
        {
            if (!_context.Rooms.Any())
            {
                _context.Rooms.Add(
                    new Room
                    {
                        NumberRoom = "UNO",
                        Capacity = 30,
                        CreatedDate = DateTime.Now,
                        Seats = new List<Seat>()
                        {
                            new Seat
                            {
                                NumberSeat = "UNO-A1",
                                Busy = false,
                                CreatedDate = DateTime.Now,                       
                            },

                            new Seat
                            {
                                NumberSeat = "UNO-A2",
                                Busy = false,
                                CreatedDate = DateTime.Now,
                        
                            },

                            new Seat
                            {
                                NumberSeat = "UNO-A3",
                                Busy = false,
                                CreatedDate = DateTime.Now,
                        
                            },
                            new Seat
                            {
                                NumberSeat = "UNO-A4",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "UNO-A5",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "UNO-A6",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "UNO-B1",
                                Busy = true,
                                CreatedDate = DateTime.Now,
                            },

                            new Seat
                            {
                                NumberSeat = "UNO-B2",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },

                            new Seat
                            {
                                NumberSeat = "UNO-B3",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "UNO-B4",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "UNO-B5",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "UNO-B6",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                        }
                    });
                _context.Rooms.Add(
               new Room
               {
                   NumberRoom = "DOS",
                   Capacity = 20,
                   CreatedDate = DateTime.Now,
                   Seats = new List<Seat>()
                        {
                            new Seat
                            {
                                NumberSeat = "DOS-A1",
                                Busy = false,
                                CreatedDate = DateTime.Now,
                            },

                            new Seat
                            {
                                NumberSeat = "DOS-A2",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },

                            new Seat
                            {
                                NumberSeat = "DOS-A3",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "DOS-A4",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "DOS-A5",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "DOS-A6",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                            NumberSeat = "DOS-B1",
                            Busy = false,
                            CreatedDate = DateTime.Now,
                            },

                            new Seat
                            {
                            NumberSeat = "DOS-B2",
                            Busy = false,
                            CreatedDate = DateTime.Now,

                            },

                            new Seat
                            {
                                NumberSeat = "DOS-B3",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "DOS-B4",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "DOS-B5",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                            new Seat
                            {
                                NumberSeat = "DOS-B6",
                                Busy = false,
                                CreatedDate = DateTime.Now,

                            },
                        }
               });
            }
        }

    }
}
