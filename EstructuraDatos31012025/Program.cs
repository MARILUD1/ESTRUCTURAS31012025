
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

    // Clase principal que contiene el menú de opciones

          var grafo = new GraphMatrix("vuelos.txt"); // Archivo .txt para crear el grafo
         int opcion;

        do
        {
            // Menú 
            Console.WriteLine("SELECCIONA UNA OPCIÓN DEL MENÚ");
            Console.WriteLine("1. Mostrar el vuelo más barato.");
            Console.WriteLine("2. Mostrar rutas y costos.");
            Console.WriteLine("3. Mostrar ruta más barata.");
            Console.WriteLine("4. Salir.");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        MostrarVueloMasBarato(grafo); 
                        break;
                    case 2:
                        grafo.MostrarTodasLasRutas(); // Mostrar todas las rutas con costos
                        break;
                    
                    case 3:
                        BuscarRutaMasBarataEntreCiudades(grafo); // Ruta más barata entre dos ciudades
                        break;
                        case 4:
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
        } while (opcion != 3); 

    

        // Función que muestra el vuelo más barato
        static void MostrarVueloMasBarato(GraphMatrix grafo)
    {
        // Encontrar el vuelo con el costo más bajo
        var vueloMasBarato = grafo.rutas.OrderBy(r => r.costo).FirstOrDefault();

        if (!vueloMasBarato.Equals(default((string origen, string destino, string aerolinea, double costo))))
        {
            // Mostrar el vuelo más barato con un costo redondeado a dos dígitos decimales
            Console.WriteLine($"Vuelo más barato: {vueloMasBarato.origen} → {vueloMasBarato.destino} | Aerolínea: {vueloMasBarato.aerolinea} | Costo: ${vueloMasBarato.costo:F2}");
        }
        else
        {
            Console.WriteLine("No hay rutas disponibles.");
        }
    }

        // Función para mostrar todas las rutas con sus costos redondeados
        static void MostrarCostosOrdenados(GraphMatrix grafo)
        {
        foreach (var costo in grafo.listaCostos)
        {
            Console.WriteLine($"{costo}"); // Mostrar los costos con un solo dígito decimal
        }
    }

        // Función que muestra la ruta más barata entre dos ciudades
        static void BuscarRutaMasBarataEntreCiudades(GraphMatrix grafo)
        {
        Console.Write("Ciudad de origen: ");
        string origen = Console.ReadLine().Trim();
        Console.Write("Ciudad de destino: ");
        string destino = Console.ReadLine().Trim();

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

        // Nodo para el árbol binario
        public class Nodo
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

        // Árbol binario de búsqueda
        public class ArbolBinario
        {
        public Nodo raiz;

        public void Insertar(double valor)
        {
            raiz = InsertarRecursividad(raiz, valor);
        }

        // Recursividad para insertar un nuevo nodo
        private Nodo InsertarRecursividad(Nodo nodo, double valor)
        {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.valor)
            nodo.izquierdo = InsertarRecursividad(nodo.izquierdo, valor);
        else
            nodo.derecho = InsertarRecursividad(nodo.derecho, valor);

            return nodo;
        }

        public void MostrarInorden()
        {
        Console.WriteLine();
        Console.WriteLine("COSTOS DE MENOR A MAYOR:");
        Inorden(raiz);
        Console.WriteLine();
        }

        // Recorrido Inorden: Izquierda - Raíz - Derecha
        private void Inorden(Nodo nodo)
        {
            if (nodo != null)
        {
            Inorden(nodo.izquierdo);
            Console.Write($"{nodo.valor:F2} "); // Mostrar con un solo dígito decimal
            Inorden(nodo.derecho);
        }
        }
    }

        // Matriz de adyacencia para representar el grafo
        public class GraphMatrix
        {
        public Dictionary<string, int> cityToIndex = new Dictionary<string, int>(); 
        public Dictionary<int, string> indexToCity = new Dictionary<int, string>(); 
        public double[,] matriz; // Matriz de adyacencia
        public List<double> listaCostos = new List<double>(); // Toma la lista de costos
        public List<(string origen, string destino, string aerolinea, double costo)> rutas = new(); // Información de las rutas

        public GraphMatrix(string rutaArchivo)
        {
            var lineas = File.ReadAllLines(rutaArchivo); // Lee todas las líneas del archivo
        var ciudadesSet = new HashSet<string>();

        // Busca las ciudades del archivo .txt
        foreach (var linea in lineas)
        {
            var partes = linea.Split(',');
            ciudadesSet.Add(partes[0]);
            ciudadesSet.Add(partes[1]);
        }

        int index = 0;
        foreach (var ciudad in ciudadesSet)
        {
            cityToIndex[ciudad] = index;
            indexToCity[index] = ciudad;
            index++;
        }

        int n = ciudadesSet.Count;
        matriz = new double[n, n];

        // Uso de infinito para empezar la matriz (sin conexión directa)
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                matriz[i, j] = double.PositiveInfinity;

        // Llenar la matriz
        foreach (var linea in lineas)
        {
            var partes = linea.Split(',');
            string origen = partes[0];
            string destino = partes[1];
            string aerolinea = partes[2];
            double costo = double.Parse(partes[3]);

            int i = cityToIndex[origen];
            int j = cityToIndex[destino];

            if (matriz[i, j] > costo)
                matriz[i, j] = costo;

            listaCostos.Add(costo);
            rutas.Add((origen, destino, aerolinea, costo));
        }
    }

        // Buscar el pasaje más barato con el algoritmo Dijkstra
        public (double, List<string>) Dijkstra(string origen, string destino)
        {
        int n = matriz.GetLength(0);
        var dist = new double[n];      // Distancia desde el origen
        var prev = new int[n];        
        var visitado = new bool[n];    // Nodos visitados

        for (int i = 0; i < n; i++)
        {
            dist[i] = double.PositiveInfinity;
            prev[i] = -1;
        }

        int inicio = cityToIndex[origen];
        dist[inicio] = 0;

        for (int count = 0; count < n - 1; count++)
        {
            int u = -1;
            double minDist = double.PositiveInfinity;
            for (int i = 0; i < n; i++)
            {
                if (!visitado[i] && dist[i] < minDist)
                {
                    minDist = dist[i];
                    u = i;
                }
            }

            if (u == -1) break;

            visitado[u] = true;

            for (int v = 0; v < n; v++)
            {
                if (!visitado[v] && matriz[u, v] != double.PositiveInfinity &&
                    dist[u] + matriz[u, v] < dist[v])
                {
                    dist[v] = dist[u] + matriz[u, v];
                    prev[v] = u;
                }
            }
        }

        var ruta = new List<string>();
        int actual = cityToIndex[destino];

        if (double.IsInfinity(dist[actual])) return (double.PositiveInfinity, ruta); // sin ruta

        while (actual != -1)
        {
            ruta.Insert(0, indexToCity[actual]);
            actual = prev[actual];
        }

        return (dist[cityToIndex[destino]], ruta);
        }

        // Rutas del archivo "Vuelos.txt"
        public void MostrarTodasLasRutas()
        {
            Console.WriteLine();
        Console.WriteLine("RUTAS DISPONIBLES:");
        Console.WriteLine();

        foreach (var ruta in rutas)
        {
             Console.WriteLine($"{ruta.origen} → {ruta.destino} | Aerolínea: {ruta.aerolinea} | Costo: ${ruta.costo:F2}"); 
        }
        }
    }