using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public abstract class Node
    {
        protected List<Node> children = new List<Node>();
        public abstract bool Execute();
    }
}
