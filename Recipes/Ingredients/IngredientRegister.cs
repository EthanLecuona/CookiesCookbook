namespace Cookies_Cookbook.Recipes.Ingredients;

public class IngredientRegister : IIngredientRegister
{

    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
{
    new WheatFlour(),
    new CoconutFlour(),
    new Butter(),
    new Chocolate(),
    new Sugar(),
    new Cardamon(),
    new Cinnamon(),
    new CocoaPowder()
};

    public Ingredient GetById(int Id)
    {
        //Ingredient searched = All.First(x => x.Id == Id);
        //return searched ? searched : null;
        foreach (var ingredient in All)
        {
            if (ingredient.Id == Id)
            {
                return ingredient;
            }
        }
        return null;
    }
}

