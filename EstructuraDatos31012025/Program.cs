
using System.Runtime.CompilerServices;
using System.Xml;

Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");
//Vectores.run();
//Colas.run();
//Pilas.run();
//Practico.run();
//Conjuntos.run();
//Juego.run();
//Traductoringles_español.run();
//Practica3.run();
//ArbolesBinarios.run();


Arbol arbol = new Arbol();
int opcion, numero;
string nombre;
// MENÚ PARA INGRESAR POR CONSOLA
do
{
    Console.WriteLine("INGRESA UNA OPCION DEL MENÚ:");
    Console.WriteLine();
    Console.WriteLine(" MENÚ ÁRBOL DE ORDEN DE LLEGADA ");
    Console.WriteLine();
    Console.WriteLine("1. Coloca el nombre y puesto del concursante");
    Console.WriteLine("2. Mostrar recorrido Preorden");
    Console.WriteLine("3. Mostrar recorrido Inorden");
    Console.WriteLine("4. Mostrar recorrido Postorden");
    Console.WriteLine("5. Salir");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Opción incorrecta, ingrese un número válido.");
        continue;
    }

    switch (opcion)
    {
        case 1:
            Console.Write("Coloca el puesto de llegada del concursante: ");
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Coloca su nombre: ");
                nombre = Console.ReadLine();
                arbol.Insertar(numero, nombre);
                Console.WriteLine("Exito al agregar concursante.");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            break;

        case 2: // Desde case 2 al case3 se realiza los 3 tipos de recorrido
            Console.WriteLine("Recorrido Preorden (Raíz - Izquierda - Derecha):");
            arbol.PreOrden(arbol.Raiz); 
            Console.WriteLine();
            break;

        case 3:
            Console.WriteLine("Recorrido Inorden (Izquierda - Raíz - Derecha):");
            arbol.InOrden(arbol.Raiz); 
            Console.WriteLine();
            break;

        case 4:
            Console.WriteLine("Recorrido Postorden (Izquierda - Derecha - Raíz):");
            arbol.PostOrden(arbol.Raiz); 
            Console.WriteLine();
            break;

        case 5:
            Console.WriteLine("GRACIAS POR UTILIZAR NUESTROS SERVICIOS.");
            break;

        default:
            Console.WriteLine("Opción incorrecta. Intenta de nuevo.");
            break;
    }
} while (opcion != 5);

// Clase Nodo
class Nodo
{
    public int Valor; // Atributo para el valor del nodo
    public string Nombre; // Atributo para el nombre del concursante
    public Nodo Izquierdo; // Atributo para el hijo izquierdo
    public Nodo Derecho; // Atributo para el hijo derecho

    public Nodo(int valor, string nombre)
    {
        Valor = valor; // Asigna el valor al nodo (numero)
        Nombre = nombre; // Asigna el nombre al nodo (cadena)
        Izquierdo = null; // Inicializa el hijo izquierdo
        Derecho = null; // Inicializa el hijo derecho 
    }
}

// Clase Arbol
class Arbol
{
    public Nodo Raiz; // Atributo para la raíz del árbol

    // Método para insertar un nuevo nodo
    public void Insertar(int valor, string nombre)
    {
        Raiz = InsertarRecursivo(Raiz, valor, nombre);
    }

    // Método recursivo para insertar un nodo
    private Nodo InsertarRecursivo(Nodo raiz, int valor, string nombre)
    {
        if (raiz == null)
        {
            return new Nodo(valor, nombre); 
        }

        if (valor < raiz.Valor)
            raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, valor, nombre); // Inserta en el subárbol izquierdo
        else
            raiz.Derecho = InsertarRecursivo(raiz.Derecho, valor, nombre); // Inserta en el subárbol derecho

        return raiz; // Retorna la raíz del subárbol
    }

    // Recorrido Preorden Inorden y Posorden
    public void PreOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.WriteLine($"Número: {nodo.Valor}, Nombre: {nodo.Nombre}"); // Muestra el valor y el nombre del nodo
            PreOrden(nodo.Izquierdo); 
            PreOrden(nodo.Derecho);  
        }
    }

    public void InOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.Izquierdo); 
            Console.WriteLine($"Número: {nodo.Valor}, Nombre: {nodo.Nombre}"); 
            InOrden(nodo.Derecho);
        }
    }

        public void PostOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.Izquierdo); 
            PostOrden(nodo.Derecho); 
            Console.WriteLine($"Número: {nodo.Valor}, Nombre: {nodo.Nombre}"); 
        }
    }
}
