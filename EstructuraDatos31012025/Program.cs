
Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");
//Vectores.run();
//Colas.run();
//Pilas.run();
//Practico.run();
//Conjuntos.run();
//Juego.run();
//Traductoringles_español.run();

System.Console.WriteLine("PRACTICA 3 MAPAS Y CONJUNTOS");
System.Console.WriteLine();

  
    {
        HashSet<string> libros = new HashSet<string>(); // Conjunto para almacenar los títulos de los libros
        Dictionary<string, string> autorLibros = new Dictionary<string, string>(); // Diccionario para almacenar detalles de los libros

        // Libros iniciales
        libros.Add("Cien años de soledad");
        autorLibros["Cien años de soledad"] = "Gabriel García Márquez";

        libros.Add("Mi pluma lo mató");
        autorLibros["Mi pluma lo mató"] = "Juan Montalvo";

        libros.Add("Cumandá");
        autorLibros["Cumandá"] = "Juan León Mera";

        int opcion;

        do
        {
            // MENÚ
            Console.WriteLine(" MENÚ");
            Console.Write("SELECCIONA UNA OPCION DEL MENÚ: ");
            Console.WriteLine();  
            Console.WriteLine("1. AGREGAR UN LIREO CON SU RESPECTIVO AUTOR");
            Console.WriteLine("2. MOSTRAR LIBROS DE LA BIBLIOTECA");
            Console.WriteLine("3. SALIR");
           

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción incorrecta, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
               

                case 1: // Agregar un libro y su autor
                    Console.Write("Ingrese el título del nuevo libro: ");
                    string nuevoLibro = Console.ReadLine();

                    if (libros.Contains(nuevoLibro))
                    {
                        Console.WriteLine("Este libro ya está registrado en la biblioteca.");
                    }
                    else
                    {
                        Console.Write("Ingrese el autor del libro: ");
                        string nuevoAutor = Console.ReadLine();

                        libros.Add(nuevoLibro);
                        autorLibros[nuevoLibro] = nuevoAutor;

                        Console.WriteLine("Libro agregado correctamente.");
                    }
                    break;

                case 2: // Mostrar todos los libros
                    if (libros.Count == 0)
                    {
                        Console.WriteLine("Aun no hay libros registrados en la biblioteca.");
                    }
                    else
                    {
                        Console.WriteLine("Lista de libros en la biblioteca:");
                        foreach (var libro in libros)
                        {
                            Console.WriteLine($"- {libro} (Autor: {autorLibros[libro]})");
                        }
                    }
                    break;

                case 3: // Salir
                    Console.WriteLine("Gracias por usar la aplicación");
                    break;

                default:
                    Console.WriteLine("Incorrecto. Intenta de nuevo.");
                    break;
            }

        } while (opcion != 4);
    }


 