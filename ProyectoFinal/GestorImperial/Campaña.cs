class Campaña : IComparable<Campaña>, IGestor
{
    #region Propiedades
    public int codigo;
    public Ciudadano supervisor;
    public Sector sector;
    public DateTime fechaInicio;
    public DateTime fechaFin;
    public SortedSet<Ciudadano> listaMiembros;
    public SortedSet<Mision> listaMisiones;
    public HashSet<Recursos> listaRecursos;

    public struct Recursos
    {
        public string tipo;
        public int cantidad;
    }
    #endregion

    public Campaña(Ciudadano supervisor, Sector sector, DateTime fechaInicio, DateTime fechaFin)
    {
        Supervisor = supervisor;
        Supervisor.Supervisor = true;
        Sector = sector;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        ListaMiembros = new SortedSet<Ciudadano>();
        ListaMisiones = new SortedSet<Mision>();
        ListaRecursos = new HashSet<Recursos>();
    }

    #region Gestor
    public void GestionarElemento(Ciudadano ciudadano)
    {
        Console.WriteLine("\n* Administrador de Campaña *");
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
        Ciudadano miembro;
        Mision mision;
        Recursos recurso;
        string tipo;
        int valor;
        Console.WriteLine("\nSeleccione el tipo de elemento:");
        Console.WriteLine("1- Miembro.");
        Console.WriteLine("2- Mision.");
        Console.WriteLine("3- Recurso.");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.Write("ID del miembro a agregar: ");
                valor = Convert.ToInt32(Console.ReadLine());
                miembro = Principal.ObtenerUsuario(valor);

                listaMiembros.Add(miembro);

                Console.WriteLine("Miembro agregado exitosamente.");
                break;

            case 2:
                Console.Write("ID del responsable de la mision: ");
                valor = Convert.ToInt32(Console.ReadLine());
                Ciudadano responsable = Principal.ObtenerUsuario(valor);

                Console.Write("Estado inicial (PLANIFICADA / EN_CURSO / FINALIZADA): ");
                string estadoTexto = Console.ReadLine();
                Estado estado = Estado.PLANIFICADA;

                if (estadoTexto.ToUpper() == "EN_CURSO") { estado = Estado.EN_CURSO; }
                else if (estadoTexto.ToUpper() == "FINALIZADA") { estado = Estado.FINALIZADA; }

                mision = new Mision(estado, responsable);
                mision.Codigo = Principal.ActualizarIDGlobalMision();
                listaMisiones.Add(mision);

                Console.WriteLine("Mision agregada exitosamente.");
                break;

            case 3:
                Console.Write("Tipo de recurso: ");
                tipo = Console.ReadLine();
                Console.Write("Cantidad: ");
                valor = Convert.ToInt32(Console.ReadLine());

                recurso = new Recursos { tipo = tipo, cantidad = valor };
                listaRecursos.Add(recurso);

                Console.WriteLine("Recurso agregado exitosamente.");
                break;

            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        Mision mision;
        Recursos recursoViejo;
        Recursos recursoNuevo;
        string tipo;
        int valor;

        Console.WriteLine("\nSeleccione el tipo de elemento:");
        Console.WriteLine("1- Mision.");
        Console.WriteLine("2- Recurso.");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.Write("Codigo de la mision: ");
                valor = Convert.ToInt32(Console.ReadLine());
                mision = Principal.ObtenerMision(valor);
                
                mision.GestionarElemento(ciudadano);
                
                Console.WriteLine("Mision modificada exitosamente.");
                break;
            case 2:
                Console.Write("Tipo de recurso a modificar: ");
                tipo = Console.ReadLine();

                // Consultar con Nacho
                recursoViejo = listaRecursos.FirstOrDefault(r => r.tipo == tipo);

                if (recursoViejo.tipo != null)
                {
                    Console.Write("Nueva cantidad: ");
                    valor = Convert.ToInt32(Console.ReadLine());
                    
                    listaRecursos.Remove(recursoViejo);
                    recursoNuevo = new Recursos { tipo = tipo, cantidad = valor };
                    listaRecursos.Add(recursoNuevo);
                    
                    Console.WriteLine("Recurso modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Recurso no encontrado.");
                }
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void EliminarElemento(Ciudadano ciudadano)
    {
        Ciudadano miembro;
        Mision mision;
        Recursos recurso;
        string tipo;
        int valor;

        Console.WriteLine("\nSeleccione el tipo de elemento:");
        Console.WriteLine("1- Miembro.");
        Console.WriteLine("2- Mision.");
        Console.WriteLine("3- Recurso.");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.Write("ID del miembro a eliminar: ");
                valor = Convert.ToInt32(Console.ReadLine());
                miembro = Principal.ObtenerUsuario(valor);
                
                listaMiembros.Remove(miembro);
                
                Console.WriteLine("Miembro eliminado exitosamente.");
                break;
            case 2:
                Console.Write("Codigo de la mision a eliminar: ");
                valor = Convert.ToInt32(Console.ReadLine());
                mision = Principal.ObtenerMision(valor);
                
                listaMisiones.Remove(mision);
                
                Console.WriteLine("Mision eliminada exitosamente.");
                break;
            case 3:
                Console.Write("Tipo de recurso a eliminar: ");
                tipo = Console.ReadLine();

                // Consultar con Nacho
                recurso = listaRecursos.FirstOrDefault(r => r.tipo == tipo);
                
                if (recurso.tipo != null)
                {
                    listaRecursos.Remove(recurso);
                    Console.WriteLine("Recurso eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Recurso no encontrado.");
                }
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    #endregion

    #region Getters y Setters
    public int Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public Ciudadano Supervisor
    {
        get { return supervisor; }
        set { supervisor = value; }
    }

    public Sector Sector
    {
        get { return sector; }
        set { sector = value; }
    }

    public DateTime FechaInicio
    {
        get { return fechaInicio; }
        set { fechaInicio = value; }
    }

    public DateTime FechaFin
    {
        get { return fechaFin; }
        set { fechaFin = value; }
    }

    public SortedSet<Ciudadano> ListaMiembros
    {
        get { return listaMiembros; }
        set { listaMiembros = value; }
    }

    public SortedSet<Mision> ListaMisiones
    {
        get { return listaMisiones; }
        set { listaMisiones = value; }
    }

    public HashSet<Recursos> ListaRecursos
    {
        get { return listaRecursos; }
        set { listaRecursos = value; }
    }
    #endregion

    public int CompareTo(Campaña? other)
    {
        // Si el otro sector es null, se indica este sector como mayor
        if (other == null) { return 1;}

        // Si los sectores son diferentes, retorna esa comparación
        int compararSector = Sector.CompareTo(other.Sector);
        if (compararSector != 0) { return compararSector; }

        // Si los sectores son iguales, compara por código
        return Codigo.CompareTo(other.Codigo);
    }

    public override string ToString()
    {
        return "\nCodigo: " + Codigo 
            + "\nSupervisor: " + Supervisor.Nombre
            + "\nSector: "+ Sector;
    }
}