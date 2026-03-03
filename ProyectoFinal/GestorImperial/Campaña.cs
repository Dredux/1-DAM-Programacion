class Campaña : IComparable<Campaña>, IGestor
{
    #region Atributos
    protected int codigo;
    protected Ciudadano supervisor;
    protected Sector sector;
    protected SortedSet<Ciudadano> listaMiembros;
    protected SortedSet<Mision> listaMisiones;
    protected HashSet<Recursos> listaRecursos;
    protected DateTime fechaInicio;
    protected DateTime fechaFin;

    public struct Recursos
    {
        public string tipo {  get; set; }
        public int cantidad { get; set; }
    }
    #endregion

    public Campaña(Ciudadano supervisor, Sector sector, DateTime fechaInicio, DateTime fechaFin)
    {
        Supervisor = supervisor;
        Sector = sector;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        ListaMiembros = new SortedSet<Ciudadano>();
        ListaMisiones = new SortedSet<Mision>();
        ListaRecursos = new HashSet<Recursos>();
    }

    #region Gestor
    public static void gestionarCampaña() 
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
    #endregion

    public int CompareTo(Campaña? other)
    {
        // Si el otro sector es null, se indica este sector como mayor
        if (other == null) { return 1;}

        // Si los sectores son diferentes, retorna esa comparación
        int compararSector = sector.CompareTo(other.sector);
        if (compararSector != 0) { return compararSector; }

        // Si los sectores son iguales, compara por código
        return codigo.CompareTo(other.codigo);
    }

    public override string ToString()
    {
        return "Codigo: "+Codigo+", Supervisor: "+Supervisor+", Sector: "+Sector;
    }
}