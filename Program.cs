namespace recipeBookConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            RecipesList r = new RecipesList("..\\..\\..\\recipes.txt");
            foreach (var item in r.recipes)
            {
                Console.WriteLine($"{item}\n");
            }
            List<RecipeItem> sbi = r.SearchByIngredients(new List<string> { "зелень", "перець" });
            Console.WriteLine("Страви з часником:\n");
            foreach (var item in sbi)
            {
                Console.WriteLine($"{item}\n");
            }
            

            ingradient i1 = new ingradient("chiken", 250);
            ingradient i2 = new ingradient("salt", 5);
            List<ingradient> ing = new List<ingradient> { i1, i2 };
            RecipeItem r1 = new RecipeItem("смажена курка", "смажена курка без олії", "filename", "покладіть курку на розжарену сковорідку та посоліть, закрийте кришкою та готуйте до готовності", ing);
            Console.WriteLine(r1);
            foreach(var re in r.recipes)
            {
                Console.WriteLine(re.Name);
            }
            //RecipesList ingradientsSearch = new RecipesList(r.SearchByIngredients(ingList));
        }
    }
}