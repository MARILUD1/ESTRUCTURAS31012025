
Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");
//Vectores.run();
//Colas.run();
//Pilas.run();
//Practico.run();
//Conjuntos.run();


        HashSet<string> ciudadanos = new HashSet<string>();
        HashSet<string> vacunados_pfizer = new HashSet<string>();
        HashSet<string> vacunados_astrazenica = new HashSet<string>();

        // Leer ciudadanos registrados en archivos .txt
         Console.WriteLine();
        Console.WriteLine("CIUDADANOS REGISTRADOS EN EL MINISTERIO DE SALUD");
        Console.WriteLine();
        LeerArchivo("ciudadanos.txt", ciudadanos);
        Console.WriteLine();

        Console.WriteLine("CIUDADANOS CON VACUNA PFIZER");
        Console.WriteLine();
        LeerArchivo("vacunados pfizer.txt", vacunados_pfizer);   
        ImprimirListaNumerada(vacunados_pfizer);    
        Console.WriteLine();

        Console.WriteLine("CIUDADANOS CON VACUNA ASTRAZENECA");
        Console.WriteLine();
        
        LeerArchivo("vacunados astrazeneca.txt", vacunados_astrazenica);
        ImprimirListaNumerada(vacunados_astrazenica);
        Console.WriteLine();
        String registro;

        // Intersección de vacunados con ambas vacunas
        Console.WriteLine("CIUDADANOS CON LAS DOS VACUNAS");
        Console.WriteLine();
        HashSet<string> dos_vacunas = Interseccion(vacunados_pfizer, vacunados_astrazenica);

        if (dos_vacunas.Count > 0)
        {
            ImprimirListaNumerada(dos_vacunas);
            Console.WriteLine("Ciudadanos con dos vacunas");
        }
        else
        {
            Console.WriteLine("No hay ciudadanos con ambas vacunas.");
        }

        // Ciudadanos sin vacunas
        Console.WriteLine();
        Console.WriteLine("CIUDADANOS SIN VACUNA");
        Console.WriteLine();
        HashSet<string> sin_vacuna = new HashSet<string>(ciudadanos);
        sin_vacuna.ExceptWith(vacunados_pfizer);
        sin_vacuna.ExceptWith(vacunados_astrazenica);

        // Mostrar ciudadanos sin vacuna al momento de imprimir
        if (sin_vacuna.Count > 0)
        {
            Console.WriteLine();
            ImprimirListaNumerada(sin_vacuna);
        }
        else
        {
            Console.WriteLine("Todos los ciudadanos han sido vacunados");
        }
    

    // Leer los registros
     void LeerArchivo(string archivo, HashSet<string> conjunto)
    {
        try
        {
            StreamReader lector = new StreamReader(archivo);
            string registro;
            while ((registro = lector.ReadLine()) != null)
            {
                conjunto.Add(registro);
                Console.WriteLine(registro);
            }
            lector.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer '" + archivo + "': " + ex.Message);
        }
    }

    // Imprimir los ciudadanos con su respectivo número
    void ImprimirListaNumerada(HashSet<string> conjunto)
    {
        int contador = 1;
        foreach (var item in conjunto)
        {
            Console.WriteLine($"{contador}. {item}");
            contador++;
        }
    }

    // Función para calcular la intersección de dos conjuntos
     HashSet<string> Interseccion(HashSet<string> conjunto1, HashSet<string> conjunto2)
    {
        HashSet<string> interseccion = new HashSet<string>(conjunto1);
        interseccion.IntersectWith(conjunto2);
        return interseccion;
    }


        