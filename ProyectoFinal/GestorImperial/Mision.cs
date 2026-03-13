class Mision : IComparable<Mision>, IGestor
{
    public int codigo;
    public Estado estado;
    public Ciudadano responsable;

    public Mision(Estado estado, Ciudadano responsable)
    {
        Estado = estado;
        Responsable = responsable;
        responsable.Supervisor = true;
    }

    #region Gestor
    public void GestionarElemento(Ciudadano ciudadano)
    {
        Console.WriteLine("\n* Administrador de Misiones *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Añadir elemento.");
        Console.WriteLine("2- Modificar elemento.");
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
        Console.Write("Inserta el ID del nuevo responsable: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Ciudadano responsable = Principal.ObtenerUsuario(id);
        Responsable = responsable;
        responsable.Supervisor = true;
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        Console.Write("\nSeleccione el tipo de elemento:");
        Console.WriteLine("1- Estado de la mision.");
        Console.WriteLine("2- Responsable.");
        int seleccion = Convert.ToInt32(Console.ReadLine());
        switch (seleccion)
        {
            case 1:
                Console.Write("Indique el nuevo estado de la mision (PLANIFICADA / EN_CURSO / FINALIZADA): ");
                string nuevoEstado = Console.ReadLine();

                if (nuevoEstado.ToUpper() == "PLANIFICADA")
                {
                    estado = Estado.PLANIFICADA;
                }
                else if (nuevoEstado.ToUpper() == "EN_CURSO")
                {
                    estado = Estado.EN_CURSO;
                }
                else if (nuevoEstado.ToUpper() == "FINALIZADA")
                {
                    estado = Estado.FINALIZADA;
                }
                break;
            case 2:
                AgregarElemento(ciudadano);
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void EliminarElemento(Ciudadano ciudadano)
    {
        // CAMBIO COHERENCIA:
        // Se desmarca supervisor del responsable real, no del operador actual.
        // (Antes se desmarcaba el supervisor del ciudadano pasado como argumento)
        if (Responsable != null)
        {
            Responsable.Supervisor = false;
        }

        Responsable = null;
        Console.WriteLine("Responsable eliminado.");
    }
    #endregion

    #region Getters y Setters
    public int Codigo 
    { 
        get { return codigo; }
        set { codigo = value; }
    }

    public Estado Estado 
    { 
        get { return estado; }
        set { estado = value; }
    }

    public Ciudadano? Responsable 
    { 
        get { return responsable; }
        set { responsable = value; }
    }
    #endregion

    public int CompareTo(Mision? other)
    {
        if (other == null) { return 1; }
        return Codigo.CompareTo(other.Codigo);
    }

    public override string ToString()
    {
        return "\nCodigo: " + Codigo
            + "\nResponsable: " + Responsable.Nombre
            + "\nEstado: " + Estado;
    }
}