using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data
{
    public class RecipesDbContext: DbContext
    {
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            : base (options)
        {

        }

        public DbSet<Recipe> Recipes {get; set;}
    }
}