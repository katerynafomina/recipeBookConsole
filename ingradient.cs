using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipeBookConsole
{
    public class ingradient
    {
        private string name;
        private int count;
        public ingradient(string name, int count)
        {
            this.name = name;
            this.count = count;
        }
        public string Name { get { return name; } }
        public int Count { get { return count; } }
        public override string ToString()
        {
            return $"{name}, {count}gr";
        }

    }
}
