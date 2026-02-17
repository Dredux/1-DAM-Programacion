class Horno : Electrodomestico, IEncendible
{
    public Horno(string nombre, bool encendido, float temperatura) : base(nombre, encendido, temperatura){}

    public float Temperatura
    {
        get { return temperatura; }
        set 
        {
            if (value < 0 && value > 250)
            {
                temperatura = value; 
            }
            else
            {
                temperatura = 0;
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