using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Esta es una clase CONCRETA que hereda de Node.
    // Representa una acción final, una "hoja" del árbol.
    // Como no es abstracta, está OBLIGADA a implementar el método Execute().
    public class Task : Node
    {
        // --- NOTA DE DISEÑO ---
        // La palabra clave 'override' es OBLIGATORIA.
        // Con ella, cumplimos el "contrato" de la clase abstracta Node.
        // Esta es la implementación específica de Execute() para una Tarea.
        public override bool Execute()
        {
            // Por ahora, nuestra tarea genérica simplemente imprimirá un mensaje
            // y devolverá 'true' para indicar que la acción fue exitosa.
            // Más adelante crearemos tareas específicas que hereden de esta.
            Console.WriteLine("Ejecutando una Tarea...");
            return true;
        }
    }
}