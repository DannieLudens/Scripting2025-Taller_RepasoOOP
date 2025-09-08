using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; // Necesitamos esto para Thread.Sleep

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Tarea especializada que pausa la ejecución del árbol.
    public class WaitTask : Task
    {
        private int _millisecondsToWait;

        // El constructor recibe el tiempo en milisegundos que debe esperar.
        public WaitTask(int milliseconds)
        {
            _millisecondsToWait = milliseconds;
        }

        public override bool Execute()
        {
            Console.WriteLine($"\n--- Ejecutando Tarea de Espera ---");
            Console.WriteLine($"Esperando por {_millisecondsToWait} ms...");

            // Pausa el hilo de ejecución del programa.
            Thread.Sleep(_millisecondsToWait);

            Console.WriteLine("Espera terminada.");
            // Una espera siempre se considera exitosa.
            return true;
        }
    }
}