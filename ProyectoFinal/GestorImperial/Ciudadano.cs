class Ciudadano : IComparable<Ciudadano>, IGestor
{
    public int id;
    public string nombre;
    public int edad;
    public Rango rango;
    public Sector sector;
    public bool supervisor;
    public List<Mision> expediente;

    public Ciudadano(string nombre, int edad, Sector sector)
    {
        Nombre = nombre;
        Edad = edad;
        Rango = Rango.CIUDADANO;
        Sector = sector;
        Supervisor = false;
        Expediente = new List<Mision>();
    }

    #region Gestor
    public void GestionarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void AgregarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void EliminarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Getters y Setters
    public int ID 
    { 
        get { return id; }
        set { id = value; }
    }

    public string Nombre 
    { 
        get { return nombre; }
        set { nombre = value; }
    }

    public int Edad 
    { 
        get { return edad; }
        set { edad = value; }
    }

    public Rango Rango 
    { 
        get { return rango; }
        set { rango = value; }
    }

    public Sector Sector 
    { 
        get { return sector; }
        set { sector = value; }
    }

    public bool Supervisor 
    { 
        get { return supervisor; }
        set { supervisor = value; }
    }

    public List<Mision> Expediente 
    { 
        get { return expediente; }
        set { expediente = value; }
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