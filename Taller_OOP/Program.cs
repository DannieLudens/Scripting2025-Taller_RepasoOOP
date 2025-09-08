using System;
using System.Collections.Generic;

namespace Taller_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Agent agent = new Agent("IA-01", new Vector2D(0, 0));
            Vector2D targetPosition = new Vector2D(50, 25);
            float stoppingDistance = 5.0f;

            Console.WriteLine("Simulación de Árbol de Comportamiento iniciada.");
            Console.WriteLine($"Agente '{agent.Name}' empieza en ({agent.Position.X}, {agent.Position.Y})");
            Console.WriteLine($"Objetivo en ({targetPosition.X}, {targetPosition.Y})");
            Console.WriteLine("=================================================");


            Task moveToTarget = new MoveToTask(agent, targetPosition);
            Task wait = new WaitTask(1000);

            Selector shouldMoveSelector = new IsTargetInRangeSelector(
                new List<Node> { moveToTarget },
                agent.Position,
                targetPosition,
                stoppingDistance
            );

            Sequence rootSequence = new Sequence(new List<Node> {
                shouldMoveSelector,
                wait
            });

            Root behaviorTree = new Root(rootSequence);


            int turn = 1;
            while (Vector2D.Distance(agent.Position, targetPosition) > stoppingDistance)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n--- TURNO {turn} ---");
                Console.ResetColor();

                behaviorTree.Execute();
                turn++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=================================================");
            Console.WriteLine("¡SIMULACIÓN COMPLETA! El agente ha llegado a su destino.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}