class Ciudadano : IComparable<Ciudadano>, IGestor
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public Rango Rango { get; set; }
    public bool Supervisor { get; set; }
    public List<Mision> Expediente { get; set; }

    public Ciudadano(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
        Rango = Rango.CIUDADANO;
        Supervisor = false;
        Expediente = new List<Mision>();
    }

    #region Gestor
    public static void gestionarCiudadano()
    {
        throw new NotImplementedException();
    }

    public void agregarElemento()
    {
        throw new NotImplementedException();
    }

    public void modificarElemento()
    {
        throw new NotImplementedException();
    }

    public void mostrarElementos()
    {
        throw new NotImplementedException();
    }
    #endregion

    public int CompareTo(Ciudadano? other)
    {
        if (other == null) { return 1; }
        return ID.CompareTo(other.ID);
    }

    public override string ToString()
    {
        string pantalla = "=================="
                          + "\nNumero de identificacion:" + ID
                          + "\nNombre: " + Nombre
                          + "\nEdad: " + Edad
                          + "\nRango: " + Rango;
        if (Expediente.Count > 0)
        {
            pantalla += "\nExpediente: ";
            foreach (Mision mision in Expediente)
            {
                pantalla += "\n  - " + mision;
            }
        }
        pantalla += "\n==================";
        return pantalla;
    }
}