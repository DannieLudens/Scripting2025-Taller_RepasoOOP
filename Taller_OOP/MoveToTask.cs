using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Tarea especializada que mueve un Agente hacia un objetivo.
    public class MoveToTask : Task
    {
        // Guardamos las referencias al agente y al objetivo
        private Agent _agent;
        private Vector2D _targetPosition;
        private float _stepSpeed = 8.5f; // Cuánto se mueve el agente en cada ejecución

        public MoveToTask(Agent agent, Vector2D targetPosition)
        {
            _agent = agent;
            _targetPosition = targetPosition;
        }

        public override bool Execute()
        {
            Console.WriteLine($"\n--- Ejecutando Tarea de Movimiento ---");

            // 1. Calcular el vector de dirección (hacia dónde moverse)
            Vector2D direction = new Vector2D(
                _targetPosition.X - _agent.Position.X,
                _targetPosition.Y - _agent.Position.Y
            );

            // 2. Calcular la distancia restante
            float distance = Vector2D.Distance(_agent.Position, _targetPosition);
            Console.WriteLine($"Distancia restante: {distance:F2}");

            // 3. Si ya estamos muy cerca, mover directamente al punto final y terminar.
            if (distance < _stepSpeed)
            {
                _agent.Position = _targetPosition;
                Console.WriteLine($"¡{_agent.Name} ha llegado al objetivo!");
            }
            else
            {
                // 4. Mover al agente un pequeño paso en la dirección correcta
                // Normalizamos el vector de dirección (para que su longitud sea 1)
                direction.X /= distance;
                direction.Y /= distance;

                // Y lo multiplicamos por la velocidad de paso para mover al agente
                _agent.Position.X += direction.X * _stepSpeed;
                _agent.Position.Y += direction.Y * _stepSpeed;

                Console.WriteLine($"Nueva posición de {_agent.Name}: ({_agent.Position.X:F2}, {_agent.Position.Y:F2})");
            }

            // Esta tarea siempre se considera exitosa si puede dar un paso.
            return true;
        }
    }
}