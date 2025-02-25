using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesDbContext _context;

        public RecipesController(RecipesDbContext context)
        {
            _context = context;
        }

        // Get: api/recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _context.Recipes.ToListAsync();
            return Ok(recipes);

        }

        // Get specific recipe
        // api/recipes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if(recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // POST: api/recipes
        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipe)
        {
            //add the new recipe to context
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            // Rerurn a 201 created response with a location header for the new recipe
            return CreatedAtAction(nameof(GetRecipeById), new {id = recipe.Id}, recipe);
        }

        //Delete by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipeById(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if(recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        // Update By id
        [HttpPut("{id}")]
        public async Task<ActionResult<Recipe>> UpdateRecipeById(int id,[FromBody] Recipe updatedRecipe)
        {
            
            if(id != updatedRecipe.Id)
            {
                return BadRequest("ID in URL does not match Id in body.");
            }
            var existingRecipe = await _context.Recipes.FindAsync(id);
            

            if(existingRecipe == null)
            {
                return NotFound();
            }
            _context.Entry(existingRecipe).CurrentValues.SetValues(updatedRecipe);
            await _context.SaveChangesAsync();
            
            // Rerurn a 201 created response with a locatio
            return NoContent();
        }
    }
}