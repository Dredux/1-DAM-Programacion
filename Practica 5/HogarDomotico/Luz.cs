class Luz : ElementoDomotico, IEncendible
{
    bool encendido;

    public Luz(string nombre) : base(nombre)
    {
        encendido = false;
    }

    public void Apagar()
    {
        encendido = false;
    }

    public bool Consultar()
    {
        return encendido;
    }

    public void Encender()
    {
        encendido = true;
    }

    public override void Mostrar()
    {
        Console.WriteLine(" " + Nombre);
    }
}