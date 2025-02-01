public class Persona{
    public int id { get; set; }
    public string nombre { get; set; }
    public decimal[] precios { get; set; }

    //constructor
    public Persona(int _id, string _Nombre, decimal[] _precios){
        id = _id;
        nombre= _Nombre;
        precios= _precios;
    }

}