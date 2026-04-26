class Ciudadano : EntidadGestable, IComparable<Ciudadano>
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
    public override void GestionarElemento(Ciudadano ciudadano)
    {
        MostrarMenuGestion("Ciudadano");
        int opcion = Convert.ToInt32(Console.ReadLine());
        EjecutarAccion(opcion, ciudadano);
    }

    public override void AgregarElemento(Ciudadano ciudadano)
    {
        Console.Write("Codigo de la mision a agregar: ");
        int codigo = Convert.ToInt32(Console.ReadLine());
        Mision? mision = Principal.ObtenerMision(codigo);

        if (mision != null)
        {
            expediente.Add(mision);
            Console.WriteLine("Mision agregada al expediente.");
        }
        else
        {
            Console.WriteLine("Error: Mision no encontrada.");
        }
    }

    public override void ModificarElemento(Ciudadano ciudadano)
    {
        Console.Write("Nuevo nombre: ");
        Nombre = Console.ReadLine();
        Console.Write("Nueva edad: ");
        Edad = Convert.ToInt32(Console.ReadLine());
        Console.Write("Seleccione el nuevo rango (numero): ");
        int nuevoRango = Convert.ToInt32(Console.ReadLine());

        if (nuevoRango >= 0 && nuevoRango <= 9)
        {
            Rango = (Rango)nuevoRango;
        }
        else
        {
            Console.WriteLine("Error: Rango no valido.");
            Rango = Rango.CIUDADANO;
        }

        Console.Write("Nombre del sector: ");
        string nombreSector = Console.ReadLine();
        Sector? nuevoSector = Principal.ObtenerSector(nombreSector);

        if (nuevoSector != null)
        {
            sector.listaUsuarios.Remove(this);
            Sector = nuevoSector;
            Sector.listaUsuarios.Add(this);
        }
        else
        {
            Console.WriteLine("Error: Sector no encontrado.");
            sector = ciudadano.Sector;
        }
    }

    public override void EliminarElemento(Ciudadano ciudadano)
    {
        Console.WriteLine("\nSeleccione el tipo de elemento:");
        Console.WriteLine("1- Mision del expediente.");
        Console.WriteLine("2- Vaciar expediente.");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.Write("Codigo de la mision: ");
                int codigo = Convert.ToInt32(Console.ReadLine());

                Mision? misionEliminar = null;
                foreach (Mision mision in expediente)
                {
                    if (mision.Codigo == codigo)
                    {
                        misionEliminar = mision;
                        break;
                    }
                }

                if (misionEliminar != null)
                {
                    expediente.Remove(misionEliminar);
                    Console.WriteLine("Mision eliminada del expediente.");
                }
                else
                {
                    Console.WriteLine("Error: Mision no encontrada en el expediente.");
                }
                break;

            case 2:
                expediente.Clear();
                Console.WriteLine("Expediente vaciado exitosamente.");
                break;

            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
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