   
   
public static class Lectura {
    public static void run(){
        System.Console.WriteLine("BIENVENIDOS A LA UNIVERSIDAD ESTATAL AMAZONICA");
        Console.WriteLine("PRÁCTICO EXPERIMENTAL 3");
        Console.WriteLine(""); } 
     
        class Libro
    {
       public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Año { get; set; }
    public string ISBN { get; set; }
    
    public Libro(string titulo, string autor, int año, string isbn)
    {
        Titulo = titulo;
        Autor = autor;
        Año = año;
        ISBN = isbn;
    }
    
    public override string ToString()
    {
        return $"Título: {Titulo}, Autor: {Autor}, Año: {Año}, ISBN: {ISBN}";
    }
    }

    class Biblioteca
{
    private List<Libro> libros = new List<Libro>();

    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
        Console.WriteLine("EL LIBRO INGRESADO ES CORRECTO.");
    }

    public void MostrarLibros()
    {
        if (libros.Count == 0)
        {
            Console.WriteLine("SIN REGISTRO DE LIBROS.");
            return;
        }
        Console.WriteLine("LIBROS DE LA BIBLIOTECA:");
        foreach (var libro in libros)
        {
            Console.WriteLine(libro);
        }
    }

    public void BuscarLibro(string titulo)
    {
        var encontrados = libros.FindAll(libro => libro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase));

        if (encontrados.Count > 0)
        {
            Console.WriteLine("LIBROS QUE SE ENCONTRARON:");
            foreach (var libro in encontrados)
                Console.WriteLine(libro);
        }
        else
        {
            Console.WriteLine("NO EXISTEN LIBROS CON ESTE TITULO.");
        }
    }
}
    
   public class Libros
{
     public void run()
    {
        Biblioteca biblioteca = new Biblioteca();
        int opcion;

        do
        {
            Console.WriteLine("\n1. AGREGAR LIBRO");
            Console.WriteLine("2. MOSTRAR LIBROS");
            Console.WriteLine("3. BUSCAR POR EL TITULO");
            Console.WriteLine("4. SALIR");
            Console.Write("SELECONA UNA OPCION: ");
            System.Console.WriteLine();
            
            // Validar la entrada del usuario
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("INGRESA NUMEROS DE MENÚ.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("INGRESA EL LIBRO: ");
                    string titulo = Console.ReadLine();
                    Console.Write("INGRESA EL AUTOR: ");
                    string autor = Console.ReadLine();
                    Console.Write("INGRESA EL AÑO: ");
                    
                    // Validar entrada de año
                    if (!int.TryParse(Console.ReadLine(), out int año))
                    {
                        
                        continue;
                    }

                    Console.Write("INGRESA ISBN: ");
                    string isbn = Console.ReadLine();

                    biblioteca.AgregarLibro(new Libro(titulo, autor, año, isbn));
                    break;
                case 2:
                    biblioteca.MostrarLibros();
                    break;
                case 3:
                    Console.Write("INGRESA EL TITULO QUE BUSCAS: ");
                    string busqueda = Console.ReadLine();
                    biblioteca.BuscarLibro(busqueda);
                    break;
                case 4:
                    Console.WriteLine("SALIR DEL PROGRAMA...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        } while (opcion != 4);
    }}}
    

