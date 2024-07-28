using Cookies_Cookbook.Recipes;
using Cookies_Cookbook.Recipes.Ingredients;
using Cookies_Cookbook.DataAccess;
using Cookies_Cookbook.FileAccess;
using Cookies_Cookbook.App;

const FileFormat Format = FileFormat.Json;
const string FileName = "recipe";
var fileMetadata = new FileMetadata(FileName, Format);

IStringRepository stringRepository = 
    Format == FileFormat.Json 
    ? new StringJSONRepository() 
    : new StringTextRepository();

var ingredientRegister = new IngredientRegister();

var cookiesRecipesApp = 
    new CookiesRecipesApp(
            new RecipesRepository(stringRepository, ingredientRegister), 
            new RecipesConsoleUserInteraction(ingredientRegister));

cookiesRecipesApp.Run(fileMetadata.ToPath());




