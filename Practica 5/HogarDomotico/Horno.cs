class Horno : Electrodomestico, IEncendible
{
    public Horno(string nombre, bool encendido, float temperatura) : base(nombre, encendido, temperatura){}

    public float Temperatura
    {
        get { return temperatura; }
        set 
        {
            if (value >= 0 && value <= 250)
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