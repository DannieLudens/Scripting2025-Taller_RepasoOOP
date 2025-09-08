# Scripting2025-Taller_RepasoOOP

## Diagrama UML de BT (Behaviour Tree o Árbol de comportamiento)

<img width="1819" height="1319" alt="image" src="https://github.com/user-attachments/assets/11bd166c-c7e2-4144-b9d4-1d36d5b4c2e1" />

<details>
  <summary>Anotaciones</summary>

![DiagramaUMLExplicado](https://github.com/user-attachments/assets/2d4e782e-99f0-40d1-9c5b-49e077439a8b)

Repaso

![DiagramaUMLnotas](https://github.com/user-attachments/assets/ed65d87f-dacb-43a0-a0cf-8443296e5233)

</details>

## Implementación del BT

<details>
  <summary>El "Esqueleto"</summary><br>

<details>
  <summary>Node.cs</summary><br> 

```cs
using System;
using System.Collections.Generic; // la necesitamos para 'list'
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Esta es nuestra clase base ABSTRACTA.
    // Sirve como el "contrato" que todos los nodos del árbol deben cumplir.
    // No se pueden crear objetos "Node" directamente.
    public abstract class Node
    {
        // --- NOTA DE DISEÑO ---
        // Atributo #children: Node[] del diagrama.
        // Es 'protected' para que solo las clases hijas puedan acceder a él (encapsulamiento).
        // Usamos una 'List<Node>' en lugar de un 'Node[]' porque es más flexible para añadir hijos.
        // Se inicializa para evitar errores de referencia nula.
        protected List<Node> children = new List<Node>();

        // --- NOTA DE DISEÑO ---
        // Método abstracto +Execute(): bool del diagrama.
        // 'public' para que pueda ser llamado desde fuera.
        // 'abstract' porque no tiene una implementación aquí.
        // Obliga a TODAS las clases hijas a escribir su propia versión de este método.
        public abstract bool Execute();
    }
}

```

1. `public abstract class Node`:

- `public`: Hace que la clase sea visible para otras partes del programa.

- `abstract`: Cumple con nuestra decisión de diseño. Le dice a C# que esta clase es un concepto y que no se puede crear un objeto con `new Node()`.

2. `protected List<Node> children = new List<Node>();`:

- `protected`: Es el `#` de nuestro diagrama. Solo esta clase y sus hijas (`Composite`, `Task`, etc.) pueden acceder a la lista `children`. Es nuestro "secreto de familia".

- `List<Node>`: Esta es la traducción de `Node[]`. En C#, una `List` es como un arreglo con superpoderes, es mucho más fácil y flexible para agregar o quitar elementos.

- `= new List<Node>()`: Inicializamos la lista de inmediato. Esto es una buena práctica para que nunca nos encontremos con que la lista `children` es nula.

3. `public abstract bool Execute();`:

- `public abstract`: Esto define el método como parte del contrato público, pero sin cuerpo.

- `bool`: Especifica que el método debe devolver un booleano.

- `;`: Nota que termina con un punto y coma, no con llaves `{}`. Esta es la sintaxis de C# para un método abstracto. Esto obliga a cualquier clase que herede de `Node` a sobrescribir este método con su propia lógica.

</details><br>

<details>
  <summary>Task.cs</summary><br>  

`Task` es una "hoja" del árbol; es la que realiza una acción concreta.

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Esta es una clase CONCRETA que hereda de Node.
    // Representa una acción final, una "hoja" del árbol.
    // Como no es abstracta, está OBLIGADA a implementar el método Execute().
    public class Task : Node
    {
        // --- NOTA DE DISEÑO ---
        // La palabra clave 'override' es OBLIGATORIA.
        // Con ella, cumplimos el "contrato" de la clase abstracta Node.
        // Esta es la implementación específica de Execute() para una Tarea.
        public override bool Execute()
        {
            // Por ahora, nuestra tarea genérica simplemente imprimirá un mensaje
            // y devolverá 'true' para indicar que la acción fue exitosa.
            // Más adelante crearemos tareas específicas que hereden de esta.
            Console.WriteLine("Ejecutando una Tarea...");
            return true;
        }
    }
}
```

1. `public class Task : Node`:

- `public class Task`: La definimos como una clase pública y **concreta** (no abstracta).

- `: Node`: La sintaxis de los dos puntos (`:`) en C# significa **herencia**. Estamos declarando que `Task` "es un" `Node`, cumpliendo con nuestro diagrama.

2. `public override bool Execute()`:

- `override`: Esta es la palabra clave más importante aquí. Le dice a C# "Sé que mi clase padre `Node` tiene un método abstracto `Execute()`, y aquí está la implementación concreta que voy a usar". Si no pusiéramos override, el programa daría un error porque no estaríamos cumpliendo el contrato de la clase `Node`.

- `Console.WriteLine(...)`: Como esta es una clase base para futuras tareas, por ahora solo vamos a hacer que imprima un mensaje en la consola para saber que se está ejecutando.

- `return true;`: Toda tarea, al finalizar, debe devolver si tuvo éxito (`true`) o si falló (`false`). Por ahora, asumiremos que nuestras tareas genéricas siempre tienen éxito.
</details><br>

<details>
  <summary>Composite.cs</summary><br> 

La otra clase abstracta principal en nuestro diseño, que servirá como base para Sequence y Selector
 
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Clase ABSTRACTA que hereda de Node.
    // Representa la idea de un nodo que tiene hijos y una lógica para ejecutarlos.
    // Es abstracta porque la lógica de ejecución es diferente para Sequence y Selector,
    // por lo que no puede tener una implementación de Execute() propia.
    public abstract class Composite : Node
    {
        // --- NOTA DE DISEÑO ---
        // Añadimos un constructor para facilitar la creación de nodos compuestos.
        // Esto nos permite pasar la lista de hijos directamente al crear el objeto,
        // haciendo que el código para construir el árbol sea más limpio.
        public Composite(List<Node> children)
        {
            // Asigna la lista de hijos que recibimos a la lista 'children' que heredamos de Node.
            this.children = children;
        }

        // --- NOTA DE DISEÑO IMPORTANTE ---
        // Nota que NO hay un método Execute() aquí.
        // Como la clase Composite es abstracta, no está obligada a implementar el método
        // abstracto Execute() de su padre (Node).
        // En su lugar, pasa esa obligación a sus propias clases hijas (Sequence y Selector).
    }
}

```

1. `public abstract class Composite : Node`: Como en nuestro diagrama, definimos `Composite` como una clase `abstracta` que hereda de `Node`. No se podrán crear objetos `new Composite()`.

2. **El** `Execute()` **Ausente**: Este es el punto más importante. A diferencia de `Task` (que era concreta), `Composite` es abstracta. Esto significa que **no tiene la obligación** de proporcionar una implementación para el método abstracto `Execute()` que hereda de `Node`. En su lugar, simplemente "pasa" esa obligación a las clases que hereden de ella (`Sequence` y `Selector`). Ellas serán las responsables de implementar la lógica final.

3. **El Constructor** `public Composite(List<Node> children)`:

- Esto no estaba explícitamente en el diagrama, pero es una práctica de programación orientada a objetos muy común y útil.

- Un constructor es un método especial que se llama al crear un nuevo objeto (`new Composite(...)`).

- Este constructor nos permite crear un nodo compuesto y asignarle sus hijos en una sola línea, lo cual hará que nuestro código final sea mucho más legible.

</details><br>

<details>
  <summary>Sequence.cs</summary><br> 

Para el taller, ejecuta a sus hijos en orden y falla tan pronto como uno de ellos falla.

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Clase CONCRETA que hereda de Composite.
    // Su lógica es ejecutar a todos sus hijos en orden. Falla si uno de ellos falla. 
    public class Sequence : Composite
    {
        // --- NOTA DE DISEÑO ---
        // Este es el constructor de la clase.
        // La sintaxis ': base(children)' es muy importante. Significa que estamos
        // pasando la lista de hijos que recibimos al constructor de la clase padre (Composite).
        public Sequence(List<Node> children) : base(children) { }

        // --- NOTA DE DISEÑO ---
        // Implementación OBLIGATORIA de Execute() heredada de Node.
        // Aquí está la lógica específica de una Secuencia, tal como la describe el taller.
        public override bool Execute()
        {
            // Recorre cada uno de los nodos hijos en la lista, de izquierda a derecha. 
            foreach (Node child in children)
            {
                // Ejecuta el hijo actual y guarda su resultado.
                bool result = child.Execute();

                // Comprueba si el hijo falló.
                if (result == false)
                {
                    // Si CUALQUIER hijo falla (devuelve false), la secuencia entera
                    // falla inmediatamente y detenemos la ejecución. 
                    // (Añadimos un mensaje para poder ver qué pasa en la consola).
                    Console.WriteLine("--> Secuencia falló.");
                    return false;
                }
            }

            // Si el bucle termina, significa que NINGÚN hijo falló.
            // Por lo tanto, la secuencia entera es un éxito.
            Console.WriteLine("--> Secuencia exitosa.");
            return true;
        }
    }
}
```
1. `public class Sequence : Composite`: Definimos Sequence como una clase concreta que hereda de `Composite`.

2. `public Sequence(List<Node> children) : base(children) { }`:

- Toda clase que hereda de otra que tiene un constructor definido (como nuestro `Composite`), debe llamar a ese constructor.

- La sintaxis ` : base(children)` hace exactamente eso: toma la lista de hijos que recibe `Sequence` y se la pasa al constructor de su clase `base` (`Composite`), que es quien sabe cómo almacenarla.

3. La lógica de `Execute()`:

- Usamos un bucle 

  `foreach` para recorrer cada `child` en la lista `children` en orden.

- Llamamos a `child.Execute()` y guardamos su resultado.

- La línea `if (result == false)` es el corazón de la `Sequence`. Si un hijo falla, la secuencia entera retorna 

</details><br>

 <details>
  <summary>Selector.cs</summary><br> 

La contraparte de Sequence. ejecuta a sus hijos en orden hasta que uno de ellos tenga éxito

```cs
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
            // Según el taller, primero debemos verificar la condición.
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
```

1. `public virtual bool Check()`:

- Implementamos el método `Check()` que es único del `Selector`.

- La palabra clave `virtual` significa que la clase base (`Selector`) proporciona una implementación por defecto, pero cualquier clase que herede de `Selector` puede **decidir si la sobrescribe o no**.

- Por defecto, devolvemos `true` para que un `Selector` normal (sin una condición especial) siempre pueda intentar ejecutar a sus hijos.

2. La lógica de `Execute()`:

- **Primero**, llamamos a `Check()`. Si devuelve 

  `false`, el `Selector` falla inmediatamente, tal como lo indican las reglas del taller. 

- **Segundo**, si `Check()` es `true`, recorremos los hijos.

- La línea `if (child.Execute())` es el corazón del `Selector`. Tan pronto como un hijo devuelve `true`, el `Selector` entero devuelve `true` y no necesita revisar a los demás. 

- Si el bucle `foreach` termina, es porque todos los hijos devolvieron `false`. Solo en ese caso, el `Selector` falla.


</details><br>

 <details>
  <summary>Root.cs</summary><br> 

La Raiz es el punto de entrada del árbol, solo puede tener un hijo y su única función es ejecutar a ese hijo

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_OOP
{
    // --- NOTA DE DISEÑO ---
    // Clase CONCRETA que hereda de Node.
    // Es el punto de entrada de todo el árbol de comportamiento.
    public class Root : Node
    {
        // --- NOTA DE DISEÑO ---
        // El constructor del Root es especial. No recibe una lista, sino
        // un único nodo hijo, para cumplir la regla del taller.
        public Root(Node child)
        {
            // Añadimos el único hijo permitido a la lista 'children' heredada de Node.
            children.Add(child);
        }

        // --- NOTA DE DISEÑO ---
        // La implementación de Execute() para el Root es muy simple,
        // tal como lo describe el taller.
        public override bool Execute()
        {
            // Verifica que el Root tenga exactamente un hijo.
            if (children.Count == 1)
            {
                // Su única función es invocar la ejecución de su único hijo 
                // y devolver el resultado que este le entregue.
                // Accedemos al hijo con children[0] (el primer elemento de la lista).
                return children[0].Execute();
            }

            // Si no tiene un hijo, el árbol no puede ejecutarse, por lo tanto falla.
            Console.WriteLine("Error: El nodo Root no tiene un hijo para ejecutar.");
            return false;
        }
    }
}
```

1. `public class Root : Node`: Como siempre, definimos la clase y su herencia desde `Node`.

2. `public Root(Node child)`: Este constructor es diferente al de `Composite`. En lugar de aceptar una `List<Node>`, acepta un único objeto `Node`, `child`. Esto ayuda a reforzar la regla de que la raíz solo puede tener un hijo. 

    Luego, simplemente añadimos ese hijo a la lista `children` que `Root` posee gracias a la herencia.

3. **La lógica de** `Execute()`:

- Primero hacemos una comprobación de seguridad para asegurarnos de que el nodo `Root` realmente tiene un hijo.

- La línea `return children[0].Execute();` es la implementación directa de la regla del taller. 

  `children[0]` es la forma de acceder al primer (y único) elemento en una lista. `Root` simplemente delega la ejecución y reporta el resultado que su hijo le devuelva.

</details><br>

 <details>
  <summary>Node.cs</summary><br> 

```cs

```
</details><br>
