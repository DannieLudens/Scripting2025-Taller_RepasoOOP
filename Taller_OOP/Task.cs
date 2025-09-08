using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public class Task : Node
    {
        public override bool Execute()
        {
            Console.WriteLine("Ejecutando una Tarea...");
            return true;
        }
    }
}