using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data
{
    public class AiDbContext: DbContext
    {
        public AiDbContext(DbContextOptions<AiDbContext> options)
            : base (options)
        {

        }

        public DbSet<AiRecipe> AiRecipes {get; set;}
    }
}