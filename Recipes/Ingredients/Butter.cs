namespace Cookies_Cookbook.Recipes.Ingredients;

public class Butter : Ingredient
{
    public override int Id => 3;

    public override string Name => "Butter";

    public override string Instruction => $"Melt on low heat. {base.Instruction}";
}

