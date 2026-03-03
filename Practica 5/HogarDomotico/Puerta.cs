class Puerta : ElementoDomotico
{
    bool abierta;

    public Puerta(string nombre) : base(nombre)
    {
        abierta = false;
    }

    public void abrirCerrar() 
    {
        if (abierta)
        {
            abierta = false;
        }
        else
        {
            abierta = true;
        }
    }

    public bool Abierta 
    {
        get { return abierta; }
        set { abierta = value; }
    }

    public override void Mostrar()
    {
        Console.WriteLine(" " + Nombre);
    }
}