using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Esta es nuestra clase base ABSTRACTA.
    // Sirve como el "contrato" que todos los nodos del árbol deben cumplir.
    // No se pueden crear objetos "Node" directamente.
    public abstract class Node
    {
        // --- NOTA DE DISEÑO ---
        // Atributo #children: Node[] del diagrama.
        // Es 'protected' para que solo las clases hijas puedan acceder a él (encapsulamiento).
        // Usamos una 'List<Node>' en lugar de un 'Node[]' porque es más flexible para añadir hijos.
        // Se inicializa para evitar errores de referencia nula.
        protected List<Node> children = new List<Node>();

        // --- NOTA DE DISEÑO ---
        // Método abstracto +Execute(): bool del diagrama.
        // 'public' para que pueda ser llamado desde fuera.
        // 'abstract' porque no tiene una implementación aquí.
        // Obliga a TODAS las clases hijas a escribir su propia versión de este método.
        public abstract bool Execute();
    }
}
