class Luz : ElementoDomotico, IEncendible
{
    bool encendida;

    public Luz(string nombre) : base(nombre)
    {
        encendida = false;
    }

    public void Apagar()
    {
        throw new NotImplementedException();
    }

    public bool Consultar()
    {
        throw new NotImplementedException();
    }

    public void Encender()
    {
        throw new NotImplementedException();
    }

    public override void Mostrar()
    {
        Console.WriteLine("Nombre: {0}, Estado: {1}", Nombre, encendida);
    }
}