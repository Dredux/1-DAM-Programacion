abstract class Electrodomestico : ElementoDomotico
{
    protected bool encendido;
    protected float temperatura;

    protected Electrodomestico(string nombre, bool encendido, float temperatura) : base(nombre)
    {
        encendido = false;
        this.temperatura = temperatura;
    }

    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }
}