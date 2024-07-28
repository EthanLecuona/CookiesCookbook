namespace Cookies_Cookbook.Recipes.Ingredients;

public abstract class Flour : Ingredient
{
    public override string Instruction => $"Sieve. {base.Instruction}";
}