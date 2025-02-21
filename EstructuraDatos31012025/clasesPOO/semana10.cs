public static class Conjuntos{
    public static void run(){
        Console.WriteLine(" semana 10- HashSet");
Console.WriteLine();
// El Gobierno Nacional a través de su Ministerio de Salud requiere algunos datos sobre la campaña de vacunación para la mitigación del COVID, en tal sentido se necesitan los siguientes datos:

// Listado de ciudadanos que no se han vacunado
// Listado de ciudadanos que han recibido las dos vacunas
// Listado de ciudadanos que solamente han recibido la vacuna de pfizer
// Listado de ciudadanos que solamente han recibido la vacuna de Astrazeneca 
// Para resolver el ejercicio considere lo siguiente:

        HashSet<string> ciudadanos = new HashSet<string>();
        HashSet<string> vacunados_pfizer = new HashSet<string>();
        HashSet<string> vacunados_astrazenica = new HashSet<string>();
       
        // Leer ciudadanos registrados en archivos .txt
        Console.WriteLine("CIUDADANOS REGISTRADOS");
        Console.WriteLine();
        LeerArchivo("ciudadanos.txt", ciudadanos);
        Console.WriteLine();

        Console.WriteLine("CIUDADANOS CON VACUNA PFIZER");
        Console.WriteLine();
        LeerArchivo("vacunados pfizer.txt", vacunados_pfizer);
        Console.WriteLine();

        Console.WriteLine("CIUDADANOS CON VACUNA ASTRAZENECA");
        Console.WriteLine();
        
        LeerArchivo("vacunados astrazeneca.txt", vacunados_astrazenica);
        Console.WriteLine();

        // Intersección de vacunados con ambas vacunas
       
        Console.WriteLine("CIUDADANOS CON LAS DOS VACUNAS");
        Console.WriteLine();
        HashSet<string> dos_vacunas = Interseccion(vacunados_pfizer, vacunados_astrazenica);

        if (dos_vacunas.Count > 1)
        {
            foreach (var ciudadano in dos_vacunas)
            {
                Console.WriteLine(ciudadano);
            }
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

        // Mostrar ciudadanos sin vacuna en pantalla
        if (sin_vacuna.Count > 1)
        {
            Console.WriteLine("Lista de ciudadanos sin vacunas:");
            Console.WriteLine();
            foreach (var ciudadano in sin_vacuna)
            {
                Console.WriteLine(ciudadano);
            }
        }
        else
        {
            Console.WriteLine("Todos los ciudadanos han sido vacunados");
        }
    
        // metodo para leer los datos guardados
        static void LeerArchivo(string archivo, HashSet<string> conjunto)
         {
        try
        {
        StreamReader lector = new StreamReader(archivo);
            {
                string registro;
                while ((registro = lector.ReadLine()) != null)
                {
                    conjunto.Add(registro);
                    Console.WriteLine(registro);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer '" + archivo + "': " + ex.Message);
        }
        }

        // Función para calcular la intersección de dos conjuntos
        HashSet<string> Interseccion(HashSet<string> conjunto1, HashSet<string> conjunto2)
        {
            HashSet<string> interseccion = new HashSet<string>(conjunto1);
            interseccion.IntersectWith(conjunto2);
            return interseccion;
        }


    }
}