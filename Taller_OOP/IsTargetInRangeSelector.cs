using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    public class IsTargetInRangeSelector : Selector
    {
        private Vector2D _agentPosition;
        private Vector2D _targetPosition;
        private float _validDistance;

        public IsTargetInRangeSelector(List<Node> children, Vector2D agentPos, Vector2D targetPos, float distance) : base(children)
        {
            _agentPosition = agentPos;
            _targetPosition = targetPos;
            _validDistance = distance;
        }

        public override bool Check()
        {
            float currentDistance = Vector2D.Distance(_agentPosition, _targetPosition);
            Console.WriteLine($"\n--- Chequeando Condición de Distancia ---");
            Console.WriteLine($"Distancia actual: {currentDistance:F2} | Distancia de parada: {_validDistance:F2}");
            if (currentDistance > _validDistance)
            {
                Console.WriteLine("Resultado: El objetivo NO ESTÁ en el rango de parada. Se debe mover. (Check = true)");
                return true;
            }
            else
            {
                Console.WriteLine("Resultado: El objetivo YA ESTÁ en el rango de parada. No se debe mover. (Check = false)");
                return false;
            }
        }
    }
}