
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
System.Console.WriteLine("semana 16");
Console.WriteLine();
Console.WriteLine("PRACTICA 4 RECORRIDOS DFS EN GRAFOS");
Console.WriteLine();
// Encuentro de vuelos baratos a partir de una base de datos
//arbol binario


       
        if (!File.Exists("vuelos.txt"))
        {
            Console.WriteLine();
            
            return;
        }
        Vuelos vuelos = new Vuelos();
        vuelos.Run();
        
class Vuelos
{
    public void Run()
    {
        var grafo = new GraphMatrix("vuelos.txt");
        var arbol = new ArbolBinario();

        int opcion;
        do
        {
            Console.WriteLine("SELECCIONA UNA OPCION DEL MENÚ");
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine();
            Console.WriteLine("1. Buscar vuelo más barato.");
            Console.WriteLine("2. Mostrar costos ordenados.");
            Console.WriteLine("3. Salir.");
            ;

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        BuscarVuelo(grafo);
                        break;
                    case 2:
                        MostrarCostosOrdenados(grafo, arbol);
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
        } while (opcion != 3);
    }

    void BuscarVuelo(GraphMatrix grafo)
    {
        Console.Write("Ciudad de origen: ");
        string origen = Console.ReadLine();
        Console.Write("Ciudad de destino: ");
        string destino = Console.ReadLine();

        if (!grafo.cityToIndex.ContainsKey(origen) || !grafo.cityToIndex.ContainsKey(destino))
        {
            Console.WriteLine("Una ciudad o las dos no existen en los registros.");
            return;
        }

        var (costo, ruta) = grafo.Dijkstra(origen, destino);

        if (double.IsInfinity(costo))
        {
            Console.WriteLine("Ruta no disponible entre esas ciudades.");
        }
        else
        {
            Console.WriteLine($"\nRuta más barata de {origen} a {destino}:");
            Console.WriteLine(string.Join(" → ", ruta));
            Console.WriteLine($"Costo total: ${costo:F2}");
        }
    }
    void MostrarCostosOrdenados(GraphMatrix grafo, ArbolBinario arbol)
    {
        foreach (var costoVuelo in grafo.listaCostos)
        {
            arbol.Insertar(costoVuelo);
        }

        arbol.MostrarInorden();
    }
    }

    class Nodo
    {
    public double valor;
    public Nodo izquierdo;
    public Nodo derecho;

    public Nodo(double valor)
    {
        this.valor = valor;
        izquierdo = null;
        derecho = null;
    }
    }

    class ArbolBinario
    {
    public Nodo raiz;

    public void Insertar(double valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, double valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.valor)
            nodo.izquierdo = InsertarRec(nodo.izquierdo, valor);
        else
            nodo.derecho = InsertarRec(nodo.derecho, valor);

        return nodo;
    }

    public void MostrarInorden()
    {
        Console.WriteLine("COSTOS DE MENOR A MAYOR");
        Inorden(raiz);
        Console.WriteLine(); // salto de línea final
    }

    private void Inorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Inorden(nodo.izquierdo);
            Console.Write($"${nodo.valor:F2} ");
            Inorden(nodo.derecho);
        }
    }
    }

    class GraphMatrix
    {
    private double[,] adjMatrix;
    private int size;
    public Dictionary<string, int> cityToIndex = new();
    public Dictionary<int, string> indexToCity = new();
    public List<double> listaCostos = new();

    public GraphMatrix(string path)
    {
        LoadGraphFromFile(path);
    }

    private void LoadGraphFromFile(string path)
    {
    var lines = File.ReadAllLines(path);
        HashSet<string> cities = new();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            cities.Add(parts[0].Trim());
            cities.Add(parts[1].Trim());
        }

        int index = 0;
        foreach (var city in cities)
        {
            cityToIndex[city] = index; //cityToIndex mapea las rutas
            indexToCity[index] = city;
            index++;
        }

        size = cities.Count;// numero de nodos
        adjMatrix = new double[size, size];

        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                adjMatrix[i, j] = double.PositiveInfinity;

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            string origen = parts[0].Trim();
            string destino = parts[1].Trim();
            double costo = double.Parse(parts[3].Trim());

            int i = cityToIndex[origen];
            int j = cityToIndex[destino];

            adjMatrix[i, j] = Math.Min(adjMatrix[i, j], costo);
            listaCostos.Add(costo);
        }
    }

    public (double, List<string>) Dijkstra(string startCity, string endCity)
    {
        int start = cityToIndex[startCity];
        int end = cityToIndex[endCity];

        double[] dist = new double[size];
        int[] prev = new int[size];
        bool[] visited = new bool[size];

        for (int i = 0; i < size; i++)
        {
            dist[i] = double.PositiveInfinity;
            prev[i] = -1;
        }

        dist[start] = 0;

        for (int count = 0; count < size - 1; count++)
        {
            int u = MinDistance(dist, visited);
            if (u == -1) break;
            visited[u] = true;

            for (int v = 0; v < size; v++)
            {
                if (!visited[v] && adjMatrix[u, v] != double.PositiveInfinity &&
                    dist[u] + adjMatrix[u, v] < dist[v])
                {
                    dist[v] = dist[u] + adjMatrix[u, v];
                    prev[v] = u;
                }
            }
        }

        List<string> path = new();
        for (int at = end; at != -1; at = prev[at])
            path.Insert(0, indexToCity[at]);

        return (dist[end], path);
    }

    private int MinDistance(double[] dist, bool[] visited)
    {
        double min = double.PositiveInfinity;
        int minIndex = -1;

        for (int v = 0; v < size; v++)
        {
            if (!visited[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }
        return minIndex;
    }
}


