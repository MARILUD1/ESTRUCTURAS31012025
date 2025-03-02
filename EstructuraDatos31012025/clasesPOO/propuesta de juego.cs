public static class Juego{
    public static void run(){
      Dictionary<string, int> jugadores = new Dictionary<string, int>();

        Console.WriteLine("\n ¡Bienvenidos al juego de los números del 1 al 100!\n ");
        Console.Write("\n Ingrese la cantidad de jugadores:\n");
        int cantidadJugadores = int.Parse(Console.ReadLine());

        for (int i = 0; i < cantidadJugadores; i++)
        {
            Console.Write($"\nIngrese el nombre del Jugador {i + 1}: ");
            string nombre = Console.ReadLine();

            int numero;
            do
            {
                Console.Write($"Jugador {nombre}, elige un número entre 1 y 100: ");
                numero = int.Parse(Console.ReadLine());

                if (numero < 1 || numero > 100)
                    Console.WriteLine(" Número no existente. Intenta de nuevo.");
            }
            while (numero < 1 || numero > 100);

            jugadores[nombre] = numero;
        }

        string ganador = "";
        int numeroMayor = 0;

        foreach (var jugador in jugadores)
        {
            if (jugador.Value > numeroMayor)
            {
                numeroMayor = jugador.Value;
                ganador = jugador.Key;
            }
        }

        Console.WriteLine($"\n ¡El ganador es {ganador} con el número {numeroMayor}!");
    

    }
}