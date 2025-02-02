﻿namespace Cookies_Cookbook.Recipes.Ingredients;

public interface IIngredientRegister
{
    IEnumerable<Ingredient> All { get; }
    Ingredient GetById(int Id);
}

