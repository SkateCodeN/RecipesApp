using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data
{
    public class AiDbContext : DbContext
    {
        public AiDbContext(DbContextOptions<AiDbContext> options)
            : base(options)
        {

        }

        public DbSet<AiRecipe> AiRecipes { get; set; }

        //In order to map each key in the jsondata object this override
        //makes sure to match them 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            modelBuilder.Entity<AiRecipe>()
                .Property(r => r.Data)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, options),
                    v => JsonSerializer.Deserialize<List<JsonRecipes>>(v, options)
                )
                .HasColumnName("jsondata");

            base.OnModelCreating(modelBuilder);
        }
    }
}