class Trabajador
{
    private string nuss;
    private string nombre;
    private int telefono;

    public Trabajador(string nuss, string nombre, int telefono)
    {
        this.nuss = nuss;
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public string Nuss 
    { 
        get { return nuss; }
        set { nuss = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int Telefono
    {
        get { return telefono; }
        set { telefono = value; }
    }

    public override string ToString()
    {
        return "Nuss: " + nuss + ", Nombre: " + nombre + "Telefono: " + telefono;
    }
}