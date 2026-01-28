class Persona
{
    protected string nombre;

    public Persona(string nombre)
    {
        this.nombre = nombre;
    }

    public virtual void Saludar() 
    {
        Console.WriteLine("Hola, soy " + nombre);
    }

    #region get/set
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    #endregion
}