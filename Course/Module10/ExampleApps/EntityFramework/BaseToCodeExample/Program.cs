using BaseToCodeExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseToCodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PizzaModel())
            {
                context.Ingredient.ToList().ForEach(e => Console.WriteLine($"{e.Name} - {e.Amount}"));
            }
        }
    }
}
