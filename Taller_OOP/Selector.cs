using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Clase CONCRETA que hereda de Composite.
    // Su lógica es ejecutar a sus hijos en orden hasta que UNO de ellos tenga éxito.
    public class Selector : Composite
    {
        // Constructor que llama al constructor de la clase base (Composite).
        public Selector(List<Node> children) : base(children) { }

        // --- NOTA DE DISEÑO ---
        // Este es el método especial 'Check' (Evaluar) que se describe en el taller.
        // Lo definimos como 'virtual' para que las clases que hereden de este Selector
        // puedan sobreescribirlo si necesitan una condición específica.
        // Por defecto, un Selector simple no tiene condición, por lo que devuelve 'true'.
        public virtual bool Check()
        {
            return true;
        }

        // --- NOTA DE DISEÑO ---
        // Implementación OBLIGATORIA de Execute() heredada de Node.
        // La lógica del Selector, como se describe en el taller.
        public override bool Execute()
        {
            // Según el taller, primero debemos verificar la condición
            if (Check() == false)
            {
                // Si la condición no se cumple, el método no se puede ejecutar y falla. 
                Console.WriteLine("--> Selector falló por la condición Check().");
                return false;
            }

            // Recorre cada uno de los nodos hijos en la lista. 
            foreach (Node child in children)
            {
                // Ejecuta el hijo actual y verifica si tuvo éxito.
                if (child.Execute())
                {
                    // Si CUALQUIER hijo tiene éxito (devuelve true), el selector
                    // entero tiene éxito inmediatamente y detenemos la ejecución. 
                    Console.WriteLine("--> Selector exitoso.");
                    return true;
                }
            }

            // Si el bucle termina, significa que NINGÚN hijo tuvo éxito.
            // Por lo tanto, el selector entero falla.
            Console.WriteLine("--> Selector falló.");
            return false;
        }
    }
}