namespace Cookies_Cookbook.Recipes.Ingredients;

public class Chocolate : Ingredient
{
    public override int Id => 4;

    public override string Name => "Chocolate";

    public override string Instruction => $"Melt on low heat. {base.Instruction}";

}

