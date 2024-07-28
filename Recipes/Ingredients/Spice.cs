namespace Cookies_Cookbook.Recipes.Ingredients;

public abstract class Spice : Ingredient
{
    public override string Instruction => $"Take half a teaspoon. {base.Instruction}";
}

