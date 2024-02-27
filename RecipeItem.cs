using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipeBookConsole
{

    public class RecipeItem
    {
        private string name;
        private string description;
        private string icon = "..\\..\\..\\photos\\";
        private string instruction;
        public List<ingradient> ingredients;
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Icon { get { return icon; } set { icon = value; } }
        public string Instruction { get { return instruction; } set { instruction = value; } }
        public override string ToString()
        {
            string result = $"Назва:{name}\r/n\nОпис:{description}\nІнструкція приготування:{instruction}\nІнградієнти:";
            foreach (var ingredient in ingredients)
            {
                result += ingredient.ToString() + "; ";
            }
            return result;
        }
        public RecipeItem(string name, string description, string icon, string instruction, List<ingradient> ingredients)
        {
            Name = name;
            Description = description;
            Icon += icon;
            Instruction = instruction;
            this.ingredients = ingredients;
        }
        public string showIngradients()
        {
            string res = "";
            foreach (ingradient i in ingredients)
            {
                res += i.ToString() + " ";
            }
            return res;
        }

    }
}
