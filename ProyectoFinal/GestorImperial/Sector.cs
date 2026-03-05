class Sector : IComparable<Sector>, IGestor
{
    public string Nombre { get; set; }
    public SortedSet<Ciudadano> ListaUsuarios { get; set; }
    public SortedSet<Campaña> ListaCampañas { get; set; }

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
        Console.WriteLine("1- Añadir Usuarios/Campañas.");
        Console.WriteLine("2- Modificar Usuarios/Campañas.");
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

    public int CompareTo(Sector? other)
    {
        if (other == null) { return 1; }
        return Nombre.CompareTo(other.Nombre);
    }

    public override string ToString() 
    {
        return "Nombre: " + Nombre 
            + "\nCiudadanos registrados: " + ListaUsuarios.Count 
            + "\nCampañas activas: " + ListaCampañas.Count;
    }
}