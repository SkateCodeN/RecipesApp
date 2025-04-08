using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data;
using NoteApp.Models;
using NoteApp.Services;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;

namespace NoteApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesDbContext _context;
        private readonly DataService _dataService;
        private readonly RecipeAIService _aiService;

        private readonly AiDbContext _aiContext;

        public RecipesController
        (
            RecipesDbContext context,
            DataService dataService,
            RecipeAIService aIService,
            AiDbContext aiDbContext
        )
        {
            _context = context;
            _dataService = dataService;
            _aiService = aIService;
            _aiContext = aiDbContext;

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
            if (recipe == null)
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
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
        }

        //Delete by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipeById(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Update By api/recipes/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Recipe>> UpdateRecipeById(int id, [FromBody] Recipe updatedRecipe)
        {

            if (id != updatedRecipe.Id)
            {
                return BadRequest("ID in URL does not match Id in body.");
            }
            var existingRecipe = await _context.Recipes.FindAsync(id);


            if (existingRecipe == null)
            {
                return NotFound();
            }
            _context.Entry(existingRecipe).CurrentValues.SetValues(updatedRecipe);
            await _context.SaveChangesAsync();

            // Rerurn a 201 created response with a locatio
            return NoContent();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //api/recipes/test
        [HttpGet("test")]
        public async Task<IActionResult> GetData()
        {
            var data = await _dataService.GetDataAsync();
            return Ok(data);
        }

        //api/recipes/randomList
        [HttpGet("randomList")]
        public async Task<IActionResult> GetRandomList()
        {
            var data = await _dataService.GetTastyData();
            return Ok(data);
        }

        //POST: /api/recipes/tastyApi/randomList
        [HttpPost("tastyApi/randomList")]
        public async Task<IActionResult> ProcessData([FromBody] TastyRequestParams request)
        {
            if (request == null)
            {
                return BadRequest("Invalid Data");
            }

            var result = await _dataService.ProcessTastyApiParams(request);
            return Ok(result);
        }

        //api/recipes/ai/randomList
        [HttpGet("ai/randomList")]
        public async Task<IActionResult> GetRandomListAI()
        {
            var data = await _aiService.GetAIData2();

            //send data to the DB
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var cleanedJson = cleanAiResponse(data.Result);

            Console.Write(data.Result);

            AiRecipeResponse? responseData = JsonSerializer.Deserialize<AiRecipeResponse>(cleanedJson, options);
            if (responseData == null || responseData.Recipes == null)
            {
                return BadRequest("Invalid JSON data");
            }


            // List<JsonRecipes>? recipesList = responseData?.Recipes;

            var recipesFromAiApi = new AiRecipe
            {
                Data = responseData.Recipes,
                Recipe_Count = 5
            };

            _aiContext.AiRecipes.Add(recipesFromAiApi);


            //await _aiContext.SaveChangesAsync();
            return Ok(data);
        }
        public string cleanAiResponse(string data)
        {
            var cleanedData = data.Trim('`');
            //remove everything before 4
            return cleanedData[4..];
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET: api/recipes/aidb
        [HttpGet("aidb")]
        public async Task<ActionResult<IEnumerable<AiRecipe>>> GetAiRecipes()
        {
            var recipes = await _aiContext.AiRecipes.ToListAsync();

            return Ok(recipes);

        }

    }
}