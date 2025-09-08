using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Taller_OOP
{
    public class WaitTask : Task
    {
        private int _millisecondsToWait;

        public WaitTask(int milliseconds)
        {
            _millisecondsToWait = milliseconds;
        }

        public override bool Execute()
        {
            Console.WriteLine($"\n--- Ejecutando Tarea de Espera ---");
            Console.WriteLine($"Esperando por {_millisecondsToWait} ms...");
            Thread.Sleep(_millisecondsToWait);
            Console.WriteLine("Espera terminada.");
            return true;
        }
    }
}