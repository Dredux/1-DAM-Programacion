class Usuario
{
    int dni;
    string nombre;
    Poliza poliza;

    public Usuario(int dni, string nombre, Poliza poliza)
    {
        this.dni = dni;
        this.nombre = nombre;
        this.poliza = poliza;
        poliza.Usuario = this;
    }

    public void Mostrar() 
    {
        Console.WriteLine("Dni: " + dni + ", Nombre: " + nombre + ", Poliza: " + poliza.PrecioAnual);
    }

    static void Main(string[] args)
    {
        Poliza poliza1 = new Poliza(1, 1200.50f);
        Usuario usuario1 = new Usuario(12345678, "Juan Perez", poliza1);
        usuario1.Mostrar();
    }
}