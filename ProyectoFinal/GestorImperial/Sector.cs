class Sector : IComparable<Sector>, IGestor
{
    public string Nombre { get; set; }
    public Ciudadano Encargado { get; set; }
    public SortedSet<Ciudadano> ListaUsuarios { get; set; }
    public SortedSet<Campaña> ListaCampañas { get; set; }

    public Sector(string nombre, Ciudadano encargado)
    {
        ListaUsuarios = new SortedSet<Ciudadano>();
        ListaCampañas = new SortedSet<Campaña>();
        Nombre = nombre;
        Encargado = encargado;
        ListaUsuarios.Add(Encargado);
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

    public int CompareTo(Sector? other)
    {
        if (other == null) { return 1; }
        return Nombre.CompareTo(other.Nombre);
    }

    public override string ToString() 
    {
        return "Nombre: "+Nombre+", Encargado: "+Encargado;
    }
}