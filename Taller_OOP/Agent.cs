using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public class Agent
    {
        public string Name { get; set; }
        public Vector2D Position { get; set; }

        public Agent(string name, Vector2D position)
        {
            Name = name;
            Position = position;
        }
    }
}