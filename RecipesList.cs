using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipeBookConsole
{
    public class RecipesList
    {
        public List<RecipeItem> recipes = new List<RecipeItem> { };
        public RecipesList(string filename)
        {
            string filePath = filename; // Шлях до файлу з рецептами

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] recipeData = line.Split(',');

                    string name = recipeData[0];
                    string description = recipeData[1];
                    string icon = recipeData[2];
                    string instruction = recipeData[3];
                    instruction = instruction.Replace("/n", "\n");
                    instruction = instruction.Replace(";", ",");
                    List<ingradient> ingredients = new List<ingradient>();

                    for (int i = 4; i < recipeData.Length; i += 2)
                    {
                        string ingredientName = recipeData[i];
                        int ingredientCount = Convert.ToInt32(recipeData[i + 1]);

                        ingradient ingredient = new ingradient(ingredientName, ingredientCount);
                        ingredients.Add(ingredient);
                    }

                    RecipeItem recipe = new RecipeItem(name, description, icon, instruction, ingredients);
                    recipes.Add(recipe);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filePath} не знайдено.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Виникла помилка при зчитуванні файлу: {e.Message}");
            }
        }
        public RecipeItem this[int index]
        {
            get { return recipes[index]; }
            set { recipes[index] = value; }
        }
        public void AddRecipe(RecipeItem r)
        {
            recipes.Add(r);
        }
        public void AddRecipe(string name, string description, string icon, string instruction, List<ingradient> ingredients)
        {
            recipes.Add(new RecipeItem(name, description, icon, instruction, ingredients));
        }
        public List<RecipeItem> SearchByIngredients(List<string> ingredients)
        {
            List<RecipeItem> matchingRecipes = new List<RecipeItem>();

            foreach (RecipeItem recipe in recipes)
            {
                bool containsAllIngredients = true;

                foreach (string ingredient in ingredients)
                {
                    bool containsIngredient = recipe.ingredients.Any(i => i.Name.Equals(ingredient, StringComparison.OrdinalIgnoreCase));

                    if (!containsIngredient)
                    {
                        containsAllIngredients = false;
                        break;
                    }
                }

                if (containsAllIngredients)
                {
                    matchingRecipes.Add(recipe);
                }
            }

            return matchingRecipes;
        }
    }
}
