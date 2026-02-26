using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Clase CONCRETA que hereda de Composite.
    // Su lógica es ejecutar a todos sus hijos en orden. Falla si uno de ellos falla. 
    public class Sequence : Composite
    {
        // --- NOTA DE DISEÑO ---
        // Este es el constructor de la clase.
        // La sintaxis ': base(children)' es muy importante. Significa que estamos
        // pasando la lista de hijos que recibimos al constructor de la clase padre (Composite).
        public Sequence(List<Node> children) : base(children) { }

        // --- NOTA DE DISEÑO ---
        // Implementación OBLIGATORIA de Execute() heredada de Node.
        // Aquí está la lógica específica de una Secuencia, tal como la describe el taller.
        public override bool Execute()
        {
            // Recorre cada uno de los nodos hijos en la lista, de izquierda a derecha. 
            foreach (Node child in children)
            {
                // Ejecuta el hijo actual y guarda su resultado.
                bool result = child.Execute();

                // Comprueba si el hijo falló.
                if (result == false)
                {
                    // Si CUALQUIER hijo falla (devuelve false), la secuencia entera
                    // falla inmediatamente y detenemos la ejecución. 
                    // (Añadimos un mensaje para poder ver qué pasa en la consola).
                    Console.WriteLine("--> Secuencia falló.");
                    return false;
                }
            }

            // Si el bucle termina, significa que NINGÚN hijo falló.
            // Por lo tanto, la secuencia entera es un éxito.
            Console.WriteLine("--> Secuencia exitosa.");
            return true;
        }
    }
}