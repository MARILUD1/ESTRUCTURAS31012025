    public static class Traductoringles_español{
    public static void run(){
            System.Console.WriteLine("SEMANA 11-- DICCIONARIO");
    System.Console.WriteLine();
 
    Dictionary<string, string> traductor = new Dictionary<string, string>();

     LeerArchivo("diccionario.txt");
        ImprimirPalabras();

        while (true)
        {
            Console.WriteLine("\n== Traductor Inglés - Español =====\n");
            Console.WriteLine("1. Traducir una palabra");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("3. Traducir una frase");
            Console.WriteLine("4. Mostrar todas las palabras");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            if (opcion == "1") TraducirPalabra();
            else if (opcion == "2") AgregarPalabra();
            else if (opcion == "3") TraducirFrase();
            else if (opcion == "4") ImprimirPalabras();
            else if (opcion == "0") break;
            else Console.WriteLine("INCORRECTO, VUELVE A INTENTAR.");
        }
    

    void LeerArchivo(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("EL ARCHIVO NO EXISTE. SE CREARA UN ARCHIVO.");
            File.Create(rutaArchivo).Close();
            return;
        }

        try
        {
            StreamReader lector = new StreamReader(rutaArchivo);
            
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] aux = linea.Split('—');
                    if (aux.Length == 2)
                    {
                        string ingles = aux[0].Trim().ToLower();
                        string español = aux[1].Trim().ToLower();

                        if (!traductor.ContainsKey(ingles))
                        {
                            traductor.Add(ingles, español);
                        }
                    }
                }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR DE LECTURA: " + e.Message);
        }
    }

    void ImprimirPalabras()
    {
        Console.WriteLine("\n== DICCIONARIO TRADUCTOR == ");
        if (traductor.Count == 0)
        {
            Console.WriteLine("DICCIONARIO VACIO.");
        }
        else
        {
            foreach (var item in traductor)
            {
                Console.WriteLine($"{item.Key} → {item.Value}");
            }
        }
    }

    void TraducirPalabra()
    {
        Console.Write("INGRESA LA PALABRA EN INGLES: ");
        string palabra = Console.ReadLine().Trim().ToLower();

        if (traductor.ContainsKey(palabra))
        {
            Console.WriteLine($"TRADUCCION: {traductor[palabra]}");
        }
        else
        {
            Console.WriteLine("PALABRA NO CONSTA EN EL DICCIONARIO.");
            AgregarPalabra();
        }
    }

    void TraducirFrase()
    {
        Console.Write("INGRESA LA FRASE EN INGLES: ");
        string frase = Console.ReadLine().Trim().ToLower();
        string[] palabras = frase.Split(' ');
        List<string> fraseTraducida = new List<string>();

        foreach (string palabra in palabras)
        {
            if (traductor.ContainsKey(palabra))
            {
                fraseTraducida.Add(traductor[palabra]);
            }
            else
            {
                fraseTraducida.Add(palabra); // Mantiene la palabra original si no hay traducción
            }
        }

        Console.WriteLine("TRADUCCION: " + string.Join(" ", fraseTraducida));
    }

    void AgregarPalabra()
    {
        Console.Write("INGRESAR LA PALABRA EN INGLES: ");
        string ingles = Console.ReadLine().Trim().ToLower();

        if (traductor.ContainsKey(ingles))
        {
            Console.WriteLine("INGRESASTE UNA PALABRA QUE YA EXISTE EN EL DICCIONARIO.");
            return;
        }

        Console.Write("COLOCA SU TRADUCCION EN ESPAÑOL: ");
        string español = Console.ReadLine().Trim().ToLower();
        traductor[ingles] = español;

        try
        {
            StreamWriter escritor = new StreamWriter("diccionario.txt", true);
            {
                escritor.WriteLine(ingles + " — " + español);
            }
            Console.WriteLine("PALABRA AGREGADA CON EXITO.");
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR PALABRA NO GUARDADA: " + e.Message);
        }
    }
 }
}