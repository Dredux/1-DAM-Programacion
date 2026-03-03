class Calefaccion : Electrodomestico, IEncendible
{
    public Calefaccion(string nombre, bool encendido, float temperatura) : base(nombre, encendido, temperatura) { }

    public float Temperatura
    {
        get { return temperatura; }
        set
        {
            if (value >= 15 && value <= 30)
            {
                temperatura = value;
            }
        }
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
        Console.WriteLine(" " + Nombre + " (" + temperatura + ")ºC");
    }
}