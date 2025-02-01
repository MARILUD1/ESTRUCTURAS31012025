Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");
//vectores.run();
//colas.run();
//Pilas.run();


// Asignación de 30 asientos en orden de llegada, una vez que todos los asientos son vendidos.
    // o Descripción: Simula una línea de espera para una atracción en un parque de diversiones.
    // o Objetivo: Asegurarse de que cada persona en la cola suba a la atracción en el orden correcto
        Console.WriteLine("PRACTICO EZPERIMENTAL");

        Console.WriteLine("Ejercicio de colas - Semana 8");
        Queue<string> asientos = new Queue<string>();
        string entrada;

        Console.WriteLine("Bienvenido a la divercion (o 'salir' para terminar):");

        // Registro de hasta 30 personas
        while (asientos.Count < 30)
        {
            entrada = Console.ReadLine();
            if (entrada.ToLower() == "salir")
                break;

            asientos.Enqueue(entrada);
            Console.WriteLine($"Hola {entrada}, estas en la cola en la cola: {asientos.Count}");
        }

        // Simulación de subir a la atracción
        Console.WriteLine("¡entrar a la atraccion! Las personas en orden son:");
        Console.WriteLine()
        foreach (var estudiante in asientos)
        {
            Console.WriteLine(asientos);
        }
    

