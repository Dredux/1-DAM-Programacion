class Puerta : ElementoDomotico
{
    bool abierta;

    public Puerta(string nombre) : base(nombre)
    {
        abierta = false;
    }

    public void abrirCerrar(string estado) 
    {
        if (estado == "abrir")
        {
            abierta = true;
        }
        else if (estado == "cerrar")
        {
            abierta = false;
        }
    }

    public override void Mostrar()
    {
        Console.WriteLine("Nombre: {0}, Estado: {1}", Nombre, abierta);
    }
}