using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // Clase auxiliar para representar una posición en un espacio 2D
    public class Vector2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        // Método estático para calcular la distancia entre dos puntos.
        // La fórmula es: raíz cuadrada de ((x2-x1)^2 + (y2-y1)^2)
        public static float Distance(Vector2D a, Vector2D b)
        {
            return (float)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
    }
}