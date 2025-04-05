public static class ArbolesBinarios{
    public static void run(){
       System.Console.WriteLine();
        System.Console.WriteLine("TAREA SEMANA 13");
        System.Console.WriteLine();
            }



    public class Nodo
    {
        public string Titulo;
        public Nodo Izquierdo, Derecho;

        public Nodo(string titulo)
        {
            Titulo = titulo;
            Izquierdo = null;
            Derecho = null;
        }
    

    public static Nodo raiz = null;

    public static Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Nodo(titulo);
        }

        int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);
        if (comparacion < 0)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        }
        else if (comparacion > 0)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
        }

        return nodo;
    }

    public static bool BuscarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }

        int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);
        if (comparacion == 0)
        {
            return true;
        }
        else if (comparacion < 0)
        {
            return BuscarRecursivo(nodo.Izquierdo, titulo);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecho, titulo);
        }
    }

    public static void Main(string[] args)
    {
        raiz = InsertarRecursivo(raiz, "VISTAZO");
        raiz = InsertarRecursivo(raiz, "GENERACION 21");
        raiz = InsertarRecursivo(raiz, "REVISTA ACELERANDO");
        raiz = InsertarRecursivo(raiz, "REVISTA AUTOIN");
        raiz = InsertarRecursivo(raiz, "REVISTA COSAS");
        raiz = InsertarRecursivo(raiz, "PREVISTA CUENCA");
        raiz = InsertarRecursivo(raiz, "REVISTA HOGAR");
        raiz = InsertarRecursivo(raiz, "ECUADOR INFINITO");
        raiz = InsertarRecursivo(raiz, "REVISTA TRAMA");
        raiz = InsertarRecursivo(raiz, "EL CONTADOR");

        while (true)
        {
            Console.WriteLine("\nMENÚ\n");
            Console.Write("Seleccione una opción del menú: ");
            System.Console.WriteLine("\n1 Buscar el titulo\n");
            System.Console.WriteLine("\n2 Salir\n");
            System.Console.WriteLine();
            
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string tituloBuscar = Console.ReadLine();
                bool encontrado = BuscarRecursivo(raiz, tituloBuscar);
                Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
            }
            else if (opcion == "2")
            {
                Console.WriteLine("Cerrando el programa.");
                break;
            }
            else
            {
                Console.WriteLine("Incorrecto intenta de nuevo.");
            }
        }

        Console.WriteLine("Salir presinando cualquier tecla");
        
    }
    }
    }
