**PROGRAMACIÓN Y DISEÑO ORIENTADO A OBJETOS**  
**INGENIERÍA EN DISEÑO DE ENTRETENIMIENTO DIGITAL**  
**UNIVERSIDAD PONTIFICIA BOLIVARIANA**

**TALLER PROGRAMACIÓN ORIENTADA A OBJETOS**

**FECHA:** Agosto 25 de 2025		**PROFESOR:** Andrés Pérez Campillo

Un árbol es una estructura de datos jerárquica compuesta de *nodos*, que pueden almacenar datos de cierta naturaleza. Cada nodo puede tener otros nodos hijos, hasta llegar a un nodo sin hijos, que se denomina *hoja*. Cada nodo del árbol es, por definición, un árbol, por lo cual, hablamos de una estructura recursiva (un árbol está compuesto por subárboles). Al primer nodo del árbol lo llamamos *raíz*.

<img width="306" height="191" alt="Picture2" src="https://github.com/user-attachments/assets/4389b61c-12cf-4cf0-b12f-891a59dd085e" />

En Inteligencia Artificial (AI) se utiliza una técnica de composición de comportamiento basada en árboles, llamada *Árboles de Comportamiento (BT)*. A diferencia de la estructura de datos, los BT se encargan de definir la lógica que ha de seguir la AI de acuerdo al entorno en que se encuentre. Al poderse componer de múltiples subárboles, los BT se configuran en una alternativa muy versátil para componer comportamientos simples e irlos robusteciendo con tareas más complejas.

<img width="602" height="571" alt="Picture3" src="https://github.com/user-attachments/assets/e04b6931-0539-4955-af81-d80e27de307a" />

Los árboles de comportamiento tienen tres tipos de nodos:

* **Raíz:** El primer nodo del árbol. Puede tener **ÚNICAMENTE UN HIJO**, y su función de *Ejecutar()* invoca la función *Ejecutar()* de dicho hijo.  
* **Compuesto:** Es un nodo especial que puede tener **AL MENOS UN HIJO.** Su función *Ejecutar()* invoca la función *Ejecutar()* de todos sus hijos, y retorna un resultado booleano que indica si la ejecución de sus hijos fue o no exitosa. Hay principalmente dos tipos de nodos compuestos:  
  * **Secuencia:** Ejecuta, de izquierda a derecha, los hijos del nodo. Si cualquiera de ellos falla, el resultado de ejecutar este nodo falla.  
  * **Selector:** Ejecuta, de izquierda a derecha, los hijos del nodo. El primer nodo que retorne éxito en la ejecución resultará en una ejecución exitosa de este nodo. Adicionalmente, ejecuta una función *Evaluar()* que determina si se cumple una condición particular en el programa. Si esta condición se cumple, se puede llamar el método *Ejecutar()* y el resultado será como se describió anteriormente. En caso contrario, *Ejecutar()* no puede ser llamado y el resultado será fallido.  
* **Tarea:** La hoja del BT. Esta se encarga de ejecutar las acciones específicas del AI, como, por ejemplo, desplazarse de un punto a otro, atacar un enemigo, etc. Retornará el resultado de la acción invocada por su método *Ejecutar()* a su padre.

Con base a lo anterior presente una aplicación de consola que permita probar lo siguiente:

1. Se presenta un diagrama UML con el diseño básico de la implementación de un árbol de comportamiento. Sin embargo, está incompleto y tiene algunos errores. Complételo, de acuerdo a los datos suministrados **(2.0)**  
2. Implemente el diseño completo del árbol de comportamiento y utilícelo para crear una inteligencia artificial que ejecute lo siguiente. Se adjunta un diagrama sencillo del árbol de comportamiento a crear **(3.0)**  
   1. Evaluar por medio de un selector si un objeto *objetivo* está a una distancia igual o menor a una *distanciaVálida*.**(1.0)**  
   2. Usar una tarea para desplazarse hasta la posición del *objetivo*, en caso de que el selector haya evaluado exitosamente la condición. Dado que es una aplicación de consola, esto hará una impresión de consola periódica indicando cuánto se ha acercado al objetivo hasta llegar a la posición correcta **(1.0)**  
   3. Usar una secuencia para evaluar el selector previamente definido, y posterior a ello, espere un tiempo *tiempoEspera* para volver a ejecutar el próximo ciclo. Esta secuencia debe tener como hijos, y en su orden, un selector que no evalúe condiciones y su resultado dependa de la ejecución de su hijo, y la tarea de esperar mencionada en este inciso. **(1.0)**

<img width="653" height="273" alt="Picture4" src="https://github.com/user-attachments/assets/2a1a1a78-e067-442c-b2ca-0c6ae4b26ab4" />

<img width="572" height="510" alt="Picture5" src="https://github.com/user-attachments/assets/d54781e2-0789-434c-87ae-7fe8cea26d67" />


