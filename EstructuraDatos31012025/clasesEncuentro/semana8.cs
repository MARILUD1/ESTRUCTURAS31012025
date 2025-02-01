public static class Colas{
    public static void run(){
    
        System.Console.WriteLine("ejercicio de colas - semana8");
        Queue<string> estudiantes= new Queue<string>();
        estudiantes.Enqueue("Ana");
        estudiantes.Enqueue("Juan");
        foreach (var item in estudiantes)
        {
        System.Console.WriteLine(item); 
        }
    }
}