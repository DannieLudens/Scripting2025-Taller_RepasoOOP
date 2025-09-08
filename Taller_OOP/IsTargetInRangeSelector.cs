using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Esta es nuestra clase especializada que hereda de Selector.
    // Su única responsabilidad es verificar una condición de distancia.
    public class IsTargetInRangeSelector : Selector
    {
        // Atributos privados para guardar la información que necesita para su condición.
        private Vector2D _agentPosition;
        private Vector2D _targetPosition;
        private float _validDistance;

        // El constructor recibe no solo los hijos, sino también los datos para la condición.
        public IsTargetInRangeSelector(List<Node> children, Vector2D agentPos, Vector2D targetPos, float distance) : base(children)
        {
            _agentPosition = agentPos;
            _targetPosition = targetPos;
            _validDistance = distance;
        }

        // --- NOTA DE DISEÑO ---
        // Sobrescribimos el método 'Check()' que definimos como 'virtual' en la clase Selector.
        // Aquí es donde implementamos la lógica de distancia del taller.
        public override bool Check()
        {
            float currentDistance = Vector2D.Distance(_agentPosition, _targetPosition);
            Console.WriteLine($"\n--- Chequeando Condición de Distancia ---");
            Console.WriteLine($"Distancia actual: {currentDistance:F2} | Distancia de parada: {_validDistance:F2}");

            // El check tiene ÉXITO si estamos MÁS LEJOS que la distancia de parada.
            // Esto permite que la rama de movimiento se ejecute.
            if (currentDistance > _validDistance)
            {
                Console.WriteLine("Resultado: El objetivo NO ESTÁ en el rango de parada. Se debe mover. (Check = true)");
                return true; // Éxito, permite la ejecución
            }
            else
            {
                Console.WriteLine("Resultado: El objetivo YA ESTÁ en el rango de parada. No se debe mover. (Check = false)");
                return false; // Fallo, detiene la ejecución de esta rama
            }
        }
    }
}