class Sector : EntidadGestable, IComparable<Sector>
{
    public string nombre;
    public SortedSet<Ciudadano> listaUsuarios;
    public SortedSet<Campaña> listaCampañas;
    public static Sector[] listaSectores = new Sector[10];
    public static int contadorSectores = 0;

    public Sector(string nombre)
    {
        Nombre = nombre;
        ListaUsuarios = new SortedSet<Ciudadano>();
        ListaCampañas = new SortedSet<Campaña>();
    }

    #region Gestor
    public override void GestionarElemento(Ciudadano ciudadano)
    {
        MostrarMenuGestion("Sector");
        int opcion = Convert.ToInt32(Console.ReadLine());
        EjecutarAccion(opcion, ciudadano);
    }

    public override void AgregarElemento(Ciudadano ciudadano)
    {
        Ciudadano Usuario;
        Campaña campaña;
        Sector sector;
        string nombre;
        int opcion = ObtenerTipoElemento(ciudadano), valor;
        switch (opcion)
        {
            case 1:
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Edad: ");
                valor = Convert.ToInt32(Console.ReadLine());

                Usuario = new Ciudadano(nombre, valor, ciudadano.sector);
                Usuario.ID = Principal.ActualizarIDGlobalCiudadano();

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
                if (Usuario != null)
                {
                    campaña = new Campaña(Usuario, this, fechaInicio, fechaFin);
                    campaña.Codigo = Principal.ActualizarIDGlobalCampaña();
                    listaCampañas.Add(campaña);

                    Console.WriteLine("Campaña agregada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Usuario supervisor no encontrado.");
                }
                break;

            case 3:
                Console.Write("Nombre del nuevo sector: ");
                nombre = Console.ReadLine();
                sector = new Sector(nombre);

                if (contadorSectores < listaSectores.Length)
                {
                    listaSectores[contadorSectores] = sector;
                    contadorSectores++;
                    Console.WriteLine("Sector agregado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Array de sectores lleno (máximo 10).");
                }
                break;

            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public override void ModificarElemento(Ciudadano ciudadano)
    {
        Ciudadano Usuario;
        Campaña campaña;
        Sector sector;
        string nombre;
        int opcion = ObtenerTipoElemento(ciudadano), valor;
        switch (opcion)
        {
            case 1:
                Console.Write("ID del usuario: ");
                valor = Convert.ToInt32(Console.ReadLine());
                Usuario = Principal.ObtenerUsuario(valor);
                
                if (Usuario != null)
                {
                    Usuario.GestionarElemento(ciudadano);
                    Console.WriteLine("Usuario modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Usuario no encontrado.");
                }
                break;

            case 2:
                Console.Write("Codigo de la campaña: ");
                valor = Convert.ToInt32(Console.ReadLine());
                campaña = Principal.ObtenerCampaña(valor);
                
                if (campaña != null)
                {
                    Console.Write("ID del nuevo supervisor: ");
                    valor = Convert.ToInt32(Console.ReadLine());
                    Usuario = Principal.ObtenerUsuario(valor);
                    
                    if (Usuario != null)
                    {
                        Console.Write("Fecha de inicio de la campaña: ");
                        DateTime fechaInicio = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Fecha fin de la campaña: ");
                        DateTime fechaFin = Convert.ToDateTime(Console.ReadLine());

                        campaña.Supervisor = Usuario;
                        campaña.FechaInicio = fechaInicio;
                        campaña.FechaFin = fechaFin;

                        Console.WriteLine("Campaña modificada exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Usuario supervisor no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Campaña no encontrada.");
                }
                break;

            case 3:
                Console.Write("Nombre del sector a modificar: ");
                nombre = Console.ReadLine();
                sector = Principal.ObtenerSector(nombre);
                
                if (sector != null)
                {
                    Console.Write("Nuevo nombre del sector: ");
                    string nuevoNombre = Console.ReadLine();
                    sector.Nombre = nuevoNombre;
                    Console.WriteLine("Sector modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Sector no encontrado.");
                }
                break;

            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public override void EliminarElemento(Ciudadano ciudadano)
    {
        Ciudadano Usuario;
        Campaña campaña;
        Sector sector;
        string nombre;
        int opcion = ObtenerTipoElemento(ciudadano), valor;
        switch (opcion)
        {
            case 1:
                Console.Write("ID del usuario: ");
                valor = Convert.ToInt32(Console.ReadLine());
                Usuario = Principal.ObtenerUsuario(valor);

                if (Usuario != null)
                {
                    Usuario.sector.listaUsuarios.Remove(Usuario);
                    Console.WriteLine("Usuario borrado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Usuario no encontrado.");
                }
                break;

            case 2:
                Console.Write("Codigo de la campaña: ");
                valor = Convert.ToInt32(Console.ReadLine());
                campaña = Principal.ObtenerCampaña(valor);

                if (campaña != null)
                {
                    campaña.Sector.listaCampañas.Remove(campaña);
                    Console.WriteLine("Campaña eliminada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Campaña no encontrada.");
                }
                break;

            case 3:
                Console.Write("Nombre del sector: ");
                nombre = Console.ReadLine();
                sector = Principal.ObtenerSector(nombre);

                if (sector != null)
                {
                    for (int i = 0; i < contadorSectores; i++)
                    {
                        if (listaSectores[i] == sector)
                        {
                            for (int j = i; j < contadorSectores - 1; j++)
                            {
                                listaSectores[j] = listaSectores[j + 1];
                            }
                            listaSectores[contadorSectores - 1] = null;
                            contadorSectores--;
                            Console.WriteLine("Sector eliminado exitosamente.");
                            return;
                        }
                    }
                }

                Console.WriteLine("Error: Sector no encontrado.");
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

    public Sector[] ListaSectores
    {
        get { return listaSectores; }
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
        return "\nDatos del sector " + Nombre + ":"
            + "\nCiudadanos registrados: " + ListaUsuarios.Count
            + "\nCampañas activas: " + ListaCampañas.Count;
    }
}