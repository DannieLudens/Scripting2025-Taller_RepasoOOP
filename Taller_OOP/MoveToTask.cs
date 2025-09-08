using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public class MoveToTask : Task
    {
        private Agent _agent;
        private Vector2D _targetPosition;
        private float _stepSpeed = 8.5f;

        public MoveToTask(Agent agent, Vector2D targetPosition)
        {
            _agent = agent;
            _targetPosition = targetPosition;
        }

        public override bool Execute()
        {
            Console.WriteLine($"\n--- Ejecutando Tarea de Movimiento ---");
            Vector2D direction = new Vector2D(
                _targetPosition.X - _agent.Position.X,
                _targetPosition.Y - _agent.Position.Y
            );
            float distance = Vector2D.Distance(_agent.Position, _targetPosition);
            Console.WriteLine($"Distancia restante: {distance:F2}");
            if (distance < _stepSpeed)
            {
                _agent.Position = _targetPosition;
                Console.WriteLine($"¡{_agent.Name} ha llegado al objetivo!");
            }
            else
            {
                direction.X /= distance;
                direction.Y /= distance;
                _agent.Position.X += direction.X * _stepSpeed;
                _agent.Position.Y += direction.Y * _stepSpeed;
                Console.WriteLine($"Nueva posición de {_agent.Name}: ({_agent.Position.X:F2}, {_agent.Position.Y:F2})");
            }
            return true;
        }
    }
}