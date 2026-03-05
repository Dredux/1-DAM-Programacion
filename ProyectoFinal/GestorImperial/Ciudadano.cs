class Ciudadano : IComparable<Ciudadano>, IGestor
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public Rango Rango { get; set; }
    public Sector Sector { get; set; }
    public bool Supervisor { get; set; }
    public List<Mision> Expediente { get; set; }

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
        Console.WriteLine("\n* Administrador de Campañas *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Añadir * * *.");
        Console.WriteLine("2- Modificar * * *.");
        Console.WriteLine("3- Mostrar datos.");
        int opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                AgregarElemento();
                break;
            case 2:
                ModificarElemento(ciudadano);
                break;
            case 3:
                MostrarElemento();
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void AgregarElemento()
    {
        throw new NotImplementedException();
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void MostrarElemento()
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