using Cine.DAL.Entities;

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
            await PopulateRoomsAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateGenderAsync()
        {
            if (!_context.Genders.Any())
            {
                _context.Genders.Add(new Gender { Id = 1, GenderName = "Acción", Description = "Películas llenas de emocionantes escenas de acción.", CreatedDate = DateTime.Now});
                _context.Genders.Add(new Gender { Id = 2, GenderName = "Comedia", Description = "Películas divertidas y humorísticas.", CreatedDate = DateTime.Now });
                _context.Genders.Add(new Gender { Id = 3, GenderName = "Drama", Description = "Películas con un enfoque en la narrativa y las emociones.", CreatedDate = DateTime.Now });
                _context.Genders.Add(new Gender { Id = 4, GenderName = "Ciencia Ficción", Description = "Películas que exploran mundos futuristas y tecnología avanzada.", CreatedDate = DateTime.Now });
                _context.Genders.Add(new Gender { Id = 5, GenderName = "Animación", Description = "Películas animadas para todas las edades.", CreatedDate = DateTime.Now });

            }

        }

        private async Task PopulateClassificationAsync()
        {
            if (!_context.Classifications.Any())
            {
                _context.Classifications.Add(new Classification { Id = 1, ClassificationName = "G", Description = "Apto para todos los públicos: Las películas con esta clasificación son adecuadas para todo tipo de audiencia, incluidos niños. No contienen contenido violento, sexual, lenguaje fuerte ni temáticas perturbadoras.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { Id = 2, ClassificationName = "PG", Description = "Supervisión de los padres recomendada: Las películas con esta clasificación pueden contener algún contenido que no sea apropiado para niños pequeños. Los padres pueden considerar adecuado ver estas películas con sus hijos más jóvenes.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { Id = 3, ClassificationName = "PG-13", Description = "Se recomienda la orientación de los padres para menores de 13 años: Las películas PG-13 pueden contener un material más fuerte que las películas PG, como violencia moderada, lenguaje fuerte, temáticas más intensas y situaciones sugerentes. No son apropiadas para niños menores de 13 años sin la orientación de los padres.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { Id = 4, ClassificationName = "R", Description = "Restringida: Las películas con clasificación R son apropiadas solo para adultos o para adolescentes con la orientación de un adulto. Pueden contener violencia intensa, contenido sexual explícito, lenguaje fuerte y/o consumo de drogas.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { Id = 5, ClassificationName = "NC-17 o X", Description = "Solo para adultos: Las películas con clasificación NC-17 (o X en algunos sistemas de clasificación) están destinadas exclusivamente para adultos. Pueden contener contenido sexual explícito, violencia extrema u otras temáticas adultas.", CreatedDate = DateTime.Now });
                _context.Classifications.Add(new Classification { Id = 6, ClassificationName = "NR o Sin clasificación", Description = "Algunas películas no reciben una clasificación oficial, lo que significa que no han sido evaluadas por una junta de clasificación. Esto puede deberse a razones varias, como películas independientes o lanzamientos en línea que no pasaron por el proceso de clasificación.", CreatedDate = DateTime.Now });


            }

        }

        private async Task PopulateRoomsAsync()
        {
            if (!_context.Rooms.Any())
            {
                _context.Rooms.Add(new Room { Id = 1, NumberRoom = "Uno", Capacity = 50, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { Id = 1, NumberRoom = "Dos", Capacity = 100, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { Id = 1, NumberRoom = "Tres", Capacity = 40, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { Id = 1, NumberRoom = "Cuatro", Capacity = 120, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { Id = 1, NumberRoom = "Cinco", Capacity = 60, CreatedDate = DateTime.Now });
                _context.Rooms.Add(new Room { Id = 1, NumberRoom = "Seis", Capacity = 80, CreatedDate = DateTime.Now });

            }

        }

    }
}
