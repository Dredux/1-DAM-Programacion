class Calefaccion : Electrodomestico, IEncendible
{
    public Calefaccion(string nombre, bool encendido, float temperatura) : base(nombre, encendido, temperatura) { }

    public float Temperatura
    {
        get { return temperatura; }
        set
        {
            if (value < 15 && value > 30)
            {
                temperatura = value;
            }
            else
            {
                temperatura = 15;
            }
        }
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
        Console.WriteLine("Nombre: {0}, Estado: {1}, Temperatura: {2}", Nombre, encendido, temperatura);
    }
}