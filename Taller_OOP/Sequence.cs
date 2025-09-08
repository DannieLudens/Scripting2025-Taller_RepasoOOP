using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public class Sequence : Composite
    {
        public Sequence(List<Node> children) : base(children) { }

        public override bool Execute()
        {
            foreach (Node child in children)
            {
                bool result = child.Execute();
                if (result == false)
                {
                    Console.WriteLine("--> Secuencia falló.");
                    return false;
                }
            }
            Console.WriteLine("--> Secuencia exitosa.");
            return true;
        }
    }
}