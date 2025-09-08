using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Clase ABSTRACTA que hereda de Node.
    // Representa la idea de un nodo que tiene hijos y una lógica para ejecutarlos.
    // Es abstracta porque la lógica de ejecución es diferente para Sequence y Selector,
    // por lo que no puede tener una implementación de Execute() propia.
    public abstract class Composite : Node
    {
        // --- NOTA DE DISEÑO ---
        // Añadimos un constructor para facilitar la creación de nodos compuestos.
        // Esto nos permite pasar la lista de hijos directamente al crear el objeto,
        // haciendo que el código para construir el árbol sea más limpio.
        public Composite(List<Node> children)
        {
            // Asigna la lista de hijos que recibimos a la lista 'children' que heredamos de Node.
            this.children = children;
        }

        // --- NOTA DE DISEÑO IMPORTANTE ---
        // Nota que NO hay un método Execute() aquí.
        // Como la clase Composite es abstracta, no está obligada a implementar el método
        // abstracto Execute() de su padre (Node).
        // En su lugar, pasa esa obligación a sus propias clases hijas (Sequence y Selector).
    }
}
