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
                ToString();
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void AgregarElemento(Ciudadano ciudadano)
    {
        if (ciudadano.Rango >= Rango.ALMIRANTE_DE_FLOTA)
        {
            Console.WriteLine("\nSeleccione el tipo de elemento:");
            Console.WriteLine("1- Usuario.");
            Console.WriteLine("2- Campaña.");
            Console.WriteLine("3- Sector.");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Edad: ");
                    int edad = Convert.ToInt32(Console.ReadLine());

                    Ciudadano nuevo = new Ciudadano(nombre, edad, this);
                    nuevo.ID = ListaUsuarios.Count + 1;
                    listaUsuarios.Add(nuevo);
                    break;
                case 2:
                    Console.Write("ID del nuevo supervisor: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Fecha de inicio de la campaña: ");
                    DateTime fechaInicio = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Fecha fin de la campaña: ");
                    DateTime fechaFin = Convert.ToDateTime(Console.ReadLine());

                    Campaña campaña = new Campaña(Principal.obtenerUsuario(id), this, fechaInicio, fechaFin);
                    break;
                case 3:
                    Console.Write("Nombre del nuevo sector: ");
                    string nuevoNombre = Console.ReadLine();

                    Sector sector = new Sector(nuevoNombre);
                    break;
                default:
                    Console.WriteLine("Error: Opcion no valida");
                    break;
            }
        }
        else
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Ciudadano nuevo = new Ciudadano(nombre, edad, this);
            nuevo.ID = ListaUsuarios.Count + 1;
            listaUsuarios.Add(nuevo);
        }
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        int id;
        string nuevoNombre;
        if (ciudadano.Rango >= Rango.ALMIRANTE_DE_FLOTA)
        {
            Console.Write("\nSeleccione el tipo de elemento:");
            Console.WriteLine("1- Usuario.");
            Console.WriteLine("2- Campaña.");
            Console.WriteLine("3- Sector.");
            int seleccion = Convert.ToInt32(Console.ReadLine());
            switch (seleccion)
            {
                case 1:
                    Console.Write("ID del usuario: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    
                    Console.Write("Nuevo nombre: ");
                    nuevoNombre = Console.ReadLine();

                    Console.Write("Nueva edad: ");
                    int nuevaEdad = Convert.ToInt32(Console.ReadLine());

                    Ciudadano antiguo = Principal.obtenerUsuario(id);
                    antiguo.Nombre = nuevoNombre;
                    antiguo.Edad = nuevaEdad;
                    break;
                case 2:
                    Console.Write("ID de la campaña: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Campaña campaña = Principal.ObtenerCampaña(codigo);

                    Console.Write("ID del nuevo supervisor: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Ciudadano supervisor = Principal.obtenerUsuario(id);

                    Console.Write("Fecha de inicio de la campaña: ");
                    DateTime fechaInicio = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Fecha fin de la campaña: ");
                    DateTime fechaFin = Convert.ToDateTime(Console.ReadLine());

                    campaña.Supervisor = supervisor;
                    campaña.FechaInicio = fechaInicio;
                    campaña.FechaFin = fechaFin;
                break;
                case 3:
                    Console.Write("Nombre del sector: ");
                    string nombreSector = Console.ReadLine();

                    Console.Write("Nuevo nombre del sector: ");
                    nuevoNombre = Console.ReadLine();

                    Principal.ObtenerSector(nombreSector).Nombre = nuevoNombre;
                    break;
                default:
                    Console.WriteLine("Error: Opcion no valida");
                    break;
            }
        }
        else
        {
            Console.Write("ID del usuario: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nuevo nombre: ");
            nuevoNombre = Console.ReadLine();

            Console.Write("Nueva edad: ");
            int nuevaEdad = Convert.ToInt32(Console.ReadLine());

            Ciudadano antiguo = Principal.obtenerUsuario(id);
            antiguo.Nombre = nuevoNombre;
            antiguo.Edad = nuevaEdad;
        }
    }

    public void EliminarElemento(Ciudadano ciudadano) 
    {
        int id;
        string nuevoNombre;
        if (ciudadano.Rango >= Rango.ALMIRANTE_DE_FLOTA)
        {
            Console.Write("\nSeleccione el tipo de elemento:");
            Console.WriteLine("1- Usuario.");
            Console.WriteLine("2- Campaña.");
            Console.WriteLine("3- Sector.");
            int seleccion = Convert.ToInt32(Console.ReadLine());
            switch (seleccion)
            {
                case 1:
                    Console.Write("ID del usuario: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Ciudadano antiguo = Principal.obtenerUsuario(id);

                    antiguo.sector.listaUsuarios.Remove(antiguo);
                    Console.WriteLine("Usuario borrado.");
                    break;
                case 2:
                    Console.Write("Codigo de la campaña: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Campaña campaña = Principal.ObtenerCampaña(id);

                    campaña.Sector.listaCampañas.Remove(campaña);
                    Console.WriteLine("Campaña eliminada.");
                    break;
                case 3:
                    Console.Write("Nombre del sector: ");
                    nuevoNombre = Console.ReadLine();

                    listaSectores.Remove(Principal.ObtenerSector(nombre));
                    Console.WriteLine("Sector eliminado.");
                    break;
                default:
                    Console.WriteLine("Error: Opcion no valida");
                    break;
            }
        }
        else
        {
            Console.Write("ID del usuario: ");
            id = Convert.ToInt32(Console.ReadLine());
            Ciudadano antiguo = Principal.obtenerUsuario(id);

            antiguo.sector.listaUsuarios.Remove(antiguo);
            Console.WriteLine("Usuario borrado.");
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