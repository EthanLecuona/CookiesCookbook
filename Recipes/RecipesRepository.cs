using Cookies_Cookbook.DataAccess;
using Cookies_Cookbook.Recipes.Ingredients;

namespace Cookies_Cookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringRepository _stringRepository;
    private const string _seperator = ",";
    private readonly IIngredientRegister _ingredientRegister;

    public RecipesRepository(IStringRepository stringRepository, IngredientRegister ingredientRegister)
    {
        _stringRepository = stringRepository;
        _ingredientRegister = ingredientRegister;
    }

    public void Write(string filePath, List<Recipe> recipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in recipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(_seperator, allIds));
        }
        _stringRepository.Write(filePath, recipesAsStrings);
    }
    public List<Recipe> Read(string filePath)
    {

        List<string> recipesFromFile = _stringRepository.Read(filePath);
        var recipes = new List<Recipe>();
        foreach (var fileItem in recipesFromFile)
        {
            var recipe = RecipeFromString(fileItem);
            recipes.Add(recipe);
        }
        return recipes;

    }

    private Recipe RecipeFromString(string recipe)
    {
        var textIds = recipe.Split(_seperator);
        var ingredients = new List<Ingredient>();
        foreach (var textId in textIds)
        {
            var id = int.Parse(textId);
            var ingredient = _ingredientRegister.GetById(id);
            ingredients.Add(ingredient);
        }
        return new Recipe(ingredients);
    }
}

