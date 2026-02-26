using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Clase CONCRETA que hereda de Node.
    // Es el punto de entrada de todo el árbol de comportamiento.
    public class Root : Node
    {
        // --- NOTA DE DISEÑO ---
        // El constructor del Root es especial. No recibe una lista, sino
        // un único nodo hijo, para cumplir la regla del taller.
        public Root(Node child)
        {
            // Añadimos el único hijo permitido a la lista 'children' heredada de Node.
            children.Add(child);
        }

        // --- NOTA DE DISEÑO ---
        // La implementación de Execute() para el Root es muy simple,
        // tal como lo describe el taller.
        public override bool Execute()
        {
            // Verifica que el Root tenga exactamente un hijo.
            if (children.Count == 1)
            {
                // Su única función es invocar la ejecución de su único hijo 
                // y devolver el resultado que este le entregue.
                // Accedemos al hijo con children[0] (el primer elemento de la lista).
                return children[0].Execute();
            }

            // Si no tiene un hijo, el árbol no puede ejecutarse, por lo tanto falla.
            Console.WriteLine("Error: El nodo Root no tiene un hijo para ejecutar.");
            return false;
        }
    }
}