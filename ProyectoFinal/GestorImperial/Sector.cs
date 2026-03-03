class Sector : IComparable<Sector>, IGestor
{
    public string nombre;
    public Ciudadano encargado;
    public SortedSet<Ciudadano> listaUsuarios;
    public SortedSet<Campaña> listaCampañas;

    public Sector(string nombre, Ciudadano encargado)
    {
        Nombre = nombre;
        Encargado = encargado;
        ListaUsuarios = new SortedSet<Ciudadano>();
        ListaCampañas = new SortedSet<Campaña>();
    }

    #region Gestor
    public static void gestionarSector()
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

    #region Getters / Setters
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public Ciudadano Encargado
    {
        get { return encargado; }
        set { encargado = value; }
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
    #endregion

    public int CompareTo(Sector? other)
    {
        if (other == null) { return 1; }
        return nombre.CompareTo(other.nombre);
    }

    public override string ToString() 
    {
        return "Nombre: "+Nombre+", Encargado: "+Encargado;
    }
}