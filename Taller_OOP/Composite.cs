using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public abstract class Composite : Node
    {
        public Composite(List<Node> children)
        {
            this.children = children;
        }
    }
}
