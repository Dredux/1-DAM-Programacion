abstract class ElementoDomotico
{
    string nombre;

    public ElementoDomotico(string nombre)
    {
        this.nombre = nombre;
    }

    public string Nombre 
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public abstract void Mostrar();
}