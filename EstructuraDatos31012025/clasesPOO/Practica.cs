public static class Practico{
    public static void run(){
        
// Asignación de 30 asientos en orden de llegada, una vez que todos los asientos son vendidos.
// o Descripción: Simula una línea de espera para una atracción en un parque de diversiones.
// o Objetivo: Asegurarse de que cada persona en la cola suba a la atracción en el orden correcto

      
        Console.WriteLine("PRÁCTICO EXPERIMENTAL");
        Console.WriteLine("Ejercicio de colas - Semana 8");
        
        Queue<string> asientos = new Queue<string>();
        string entrada;

        Console.WriteLine("Bienvenido a la diversión (o 'salir' para terminar):");

        // Registro de hasta 30 personas
        while (asientos.Count < 30)
        {
            Console.Write("Ingrese su nombre: ");
            entrada = Console.ReadLine();
            
            if (entrada.ToLower() == "salir")
                break;

            asientos.Enqueue(entrada);
            Console.WriteLine($"Hola {entrada}, estás en la cola en la posición: {asientos.Count}");
        }

        // Simulación de subir a la atracción
        Console.WriteLine("\n¡Entrar a la atracción! Las personas en orden son:");
        
        while (asientos.Count > 0)
        {
            Console.WriteLine(asientos.Dequeue());
        }
    
    }
}