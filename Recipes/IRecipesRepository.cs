namespace Cookies_Cookbook.Recipes;

public interface IRecipesRepository
{
    void Write(string filePath, List<Recipe> recipe);
    List<Recipe> Read(string filePath);
}

