class Campaña : IComparable<Campaña>, IGestor
{
    #region Propiedades
    public int Codigo { get; set; }
    public Ciudadano Supervisor { get; set; }
    public Sector Sector { get; set; }
    public SortedSet<Ciudadano> ListaMiembros { get; set; }
    public SortedSet<Mision> ListaMisiones { get; set; }
    public HashSet<Recursos> ListaRecursos { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public struct Recursos
    {
        public string tipo { get; set; }
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
        return "Codigo: "+Codigo+", Supervisor: "+Supervisor+", Sector: "+Sector;
    }
}