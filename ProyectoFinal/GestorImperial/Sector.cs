class Sector : IComparable<Sector>, IGestor
{
    public string nombre;
    public SortedSet<Ciudadano> listaUsuarios;
    public SortedSet<Campaña> listaCampañas;
    public static SortedSet<Sector> listaSectores = new SortedSet<Sector>();

    public Sector(string nombre)
    {
        Nombre = nombre;
        ListaUsuarios = new SortedSet<Ciudadano>();
        ListaCampañas = new SortedSet<Campaña>();
    }

    #region Gestor
    public void GestionarElemento(Ciudadano ciudadano)
    {
        Console.WriteLine("\n* Administrador de Sector *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Añadir elemento.");
        Console.WriteLine("2- Modificar elementos.");
        Console.WriteLine("3- Eliminar elemento.");
        Console.WriteLine("4- Mostrar datos.");
        int opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                AgregarElemento(ciudadano);
                break;
            case 2:
                ModificarElemento(ciudadano);
                break;
            case 3:
                EliminarElemento(ciudadano);
                break;
            case 4:
                Console.WriteLine(ToString());
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void AgregarElemento(Ciudadano ciudadano)
    {
        Ciudadano Usuario;
        Campaña campaña;
        Sector sector;
        string? nombre;
        int opcion = ObtenerTipoElemento(ciudadano), valor;
        switch (opcion)
        {
            case 1:
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Edad: ");
                valor = Convert.ToInt32(Console.ReadLine());

                Usuario = new Ciudadano(nombre, valor, this);
                Usuario.ID = ListaUsuarios.Count + 1;
                listaUsuarios.Add(Usuario);

                Console.WriteLine("Usuario agregado exitosamente.");
                break;
            case 2:
                Console.Write("ID del nuevo supervisor: ");
                valor = Convert.ToInt32(Console.ReadLine());
                Console.Write("Fecha de inicio de la campaña: ");
                DateTime fechaInicio = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Fecha fin de la campaña: ");
                DateTime fechaFin = Convert.ToDateTime(Console.ReadLine());

                Usuario = Principal.ObtenerUsuario(valor);
                campaña = new Campaña(Usuario, this, fechaInicio, fechaFin);

                Console.WriteLine("Campaña agregada exitosamente.");

                break;
            case 3:
                Console.Write("Nombre del nuevo sector: ");
                nombre = Console.ReadLine();

                sector = new Sector(nombre);
                listaSectores.Add(sector);

                Console.WriteLine("Sector agregado exitosamente.");
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        Ciudadano? Usuario;
        Campaña? campaña;
        Sector? sector;
        string? nombre;
        int opcion = ObtenerTipoElemento(ciudadano), valor;
        switch (opcion)
        {
            case 1:
                Console.Write("ID del usuario: ");
                valor = Convert.ToInt32(Console.ReadLine());
                Usuario = Principal.ObtenerUsuario(valor);
                Console.Write("Nuevo nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Nueva edad: ");
                valor = Convert.ToInt32(Console.ReadLine());

                Usuario.Nombre = nombre;
                Usuario.Edad = valor;

                Console.WriteLine("Usuario modificado exitosamente.");
                break;
            case 2:
                Console.Write("Codigo de la campaña: ");
                valor = Convert.ToInt32(Console.ReadLine());
                campaña = Principal.ObtenerCampaña(valor);
                Console.Write("ID del nuevo supervisor: ");
                valor = Convert.ToInt32(Console.ReadLine());
                Usuario = Principal.ObtenerUsuario(valor);
                Console.Write("Fecha de inicio de la campaña: ");
                DateTime fechaInicio = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Fecha fin de la campaña: ");
                DateTime fechaFin = Convert.ToDateTime(Console.ReadLine());

                campaña.Supervisor = Usuario;
                campaña.FechaInicio = fechaInicio;
                campaña.FechaFin = fechaFin;

                Console.WriteLine("Campaña modificada exitosamente.");
                break;
            case 3:
                Console.Write("Nombre del sector: ");
                nombre = Console.ReadLine();
                sector = Principal.ObtenerSector(nombre);
                Console.Write("Nuevo nombre del sector: ");
                nombre = Console.ReadLine();

                sector.Nombre = nombre;

                Console.WriteLine("Sector modificado exitosamente.");
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void EliminarElemento(Ciudadano ciudadano) 
    {
        Ciudadano? Usuario;
        Campaña? campaña;
        Sector? sector;
        string? nombre;
        int opcion = ObtenerTipoElemento(ciudadano), valor;
        switch (opcion)
        {
            case 1:
                Console.Write("ID del usuario: ");
                valor = Convert.ToInt32(Console.ReadLine());
                Usuario = Principal.ObtenerUsuario(valor);

                Usuario.sector.listaUsuarios.Remove(Usuario);

                Console.WriteLine("Usuario borrado exitosamente.");
                break;
            case 2:
                Console.Write("Codigo de la campaña: ");
                valor = Convert.ToInt32(Console.ReadLine());
                campaña = Principal.ObtenerCampaña(valor);

                campaña.Sector.listaCampañas.Remove(campaña);

                Console.WriteLine("Campaña eliminada exitosamente.");
                break;
            case 3:
                Console.Write("Nombre del sector: ");
                nombre = Console.ReadLine();
                sector = Principal.ObtenerSector(nombre);

                listaSectores.Remove(sector);

                Console.WriteLine("Sector eliminado exitosamente.");
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }
    #endregion

    #region Getters y Setters
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public SortedSet<Ciudadano> ListaUsuarios
    {
        get { return listaUsuarios; }
        set { listaUsuarios = value; }
    }

    public SortedSet<Campaña> ListaCampañas
    {
        get { return listaCampañas; }
        set { listaCampañas = value; }
    }

    public SortedSet<Sector> ListaSectores
    {
        get { return listaSectores; }
        set { listaSectores = value; }
    }
    #endregion

    private int ObtenerTipoElemento(Ciudadano ciudadano)
    {
        if (ciudadano.Rango >= Rango.ALMIRANTE_DE_FLOTA)
        {
            Console.WriteLine("\nSeleccione el tipo de elemento:");
            Console.WriteLine("1- Usuario.");
            Console.WriteLine("2- Campaña.");
            Console.WriteLine("3- Sector.");
            return Convert.ToInt32(Console.ReadLine());
        }
        return 1;
    }

    public int CompareTo(Sector? other)
    {
        if (other == null) { return 1; }
        return Nombre.CompareTo(other.Nombre);
    }

    public override string ToString() 
    {
        string pantalla = "\nDatos del sector " + Nombre + ":"
            + "\nCiudadanos registrados: " + ListaUsuarios.Count
            + "\nCampañas activas: " + ListaCampañas.Count;
        foreach (Sector sector in listaSectores)
        {
            pantalla += sector.ToString();
        }

        return pantalla;
    }
}