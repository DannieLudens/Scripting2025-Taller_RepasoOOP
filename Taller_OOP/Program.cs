using System;
using System.Collections.Generic;

namespace Taller_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // =================================================================
            // --- 1. CONFIGURACIÓN DE LA SIMULACIÓN ---
            // =================================================================
            Agent agent = new Agent("IA-01", new Vector2D(0, 0));
            Vector2D targetPosition = new Vector2D(50, 25);
            // La distancia a la que la IA debe dejar de moverse.
            float stoppingDistance = 5.0f;

            Console.WriteLine("Simulación de Árbol de Comportamiento iniciada.");
            Console.WriteLine($"Agente '{agent.Name}' empieza en ({agent.Position.X}, {agent.Position.Y})");
            Console.WriteLine($"Objetivo en ({targetPosition.X}, {targetPosition.Y})");
            Console.WriteLine("=================================================");


            // =================================================================
            // --- 2. CONSTRUCCIÓN DEL ÁRBOL DE COMPORTAMIENTO ---
            // Se construye de abajo hacia arriba (de las hojas a la raíz)
            // =================================================================

            // Nivel 3: Las Tareas (Hojas)
            Task moveToTarget = new MoveToTask(agent, targetPosition);
            Task wait = new WaitTask(1000); // Espera 1 segundo (1000 ms)

            // Nivel 2: El Selector de Movimiento
            // Si el Check() falla, esta rama no se ejecuta.
            // Si el Check() tiene éxito, ejecuta su único hijo: la tarea de moverse.
            Selector shouldMoveSelector = new IsTargetInRangeSelector(
                new List<Node> { moveToTarget }, // Hijos de este selector
                agent.Position,
                targetPosition,
                stoppingDistance
            );

            // Nivel 1: La Secuencia Principal
            // Ejecutará a sus hijos en orden: primero el selector, luego la espera.
            Sequence rootSequence = new Sequence(new List<Node> {
                shouldMoveSelector,
                wait
            });

            // Nivel 0: La Raíz del Árbol
            // El punto de entrada que inicia toda la ejecución.
            Root behaviorTree = new Root(rootSequence);


            // =================================================================
            // --- 3. BUCLE PRINCIPAL DE EJECUCIÓN ---
            // =================================================================
            int turn = 1;
            // El bucle se ejecuta mientras el agente no haya llegado al objetivo.
            while (Vector2D.Distance(agent.Position, targetPosition) > stoppingDistance)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n--- TURNO {turn} ---");
                Console.ResetColor();

                // ¡Aquí es donde se ejecuta todo el árbol!
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