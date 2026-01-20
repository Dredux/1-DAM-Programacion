class Persona
{
    string nombre;

    public Persona(string nombre)
    {
        this.nombre = nombre;
    }

    public void Saludar() 
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