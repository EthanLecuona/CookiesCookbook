using Cookies_Cookbook.Recipes.Ingredients;
using Cookies_Cookbook.Recipes;

namespace Cookies_Cookbook.App;


public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintRecipe(allRecipes);
        _recipesUserInteraction.Prompt();
        var ingredients = _recipesUserInteraction.Read();
        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);
            _recipesUserInteraction.ShowMessage("Recipe has been added!");
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No ingredient have been selected. Recipe will not be saved.");
        }
        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesUserInteraction
{
    void Prompt();
    IEnumerable<Ingredient> Read();
    void PrintRecipe(IEnumerable<Recipe> recipes);
    void ShowMessage(string message);
    void Exit();
}
public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    public RecipesConsoleUserInteraction(IIngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    private readonly IIngredientRegister _ingredientRegister;
    public void Prompt()
    {
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }
    public void PrintRecipe(IEnumerable<Recipe> recipes)
    {
        if (recipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);
            var count = 1;
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"**** {count} ****");
                Console.WriteLine(recipe);

                Console.WriteLine();
                ++count;
            }
        }
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public IEnumerable<Ingredient> Read()
    {
        bool stop = false;
        var ingredients = new List<Ingredient>();
        while (!stop)
        {
            Console.WriteLine("Add an ingredient by its ID, or type anything else if finished.");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                stop = true;
            }
        }
        return ingredients;
    }
}
