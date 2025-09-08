using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public class Selector : Composite
    {
        public Selector(List<Node> children) : base(children) { }

        public virtual bool Check()
        {
            return true;
        }

        public override bool Execute()
        {
            if (Check() == false)
            {
                Console.WriteLine("--> Selector falló por la condición Check().");
                return false;
            }
            foreach (Node child in children)
            {
                if (child.Execute())
                {
                    Console.WriteLine("--> Selector exitoso.");
                    return true;
                }
            }
            Console.WriteLine("--> Selector falló.");
            return false;
        }
    }
}