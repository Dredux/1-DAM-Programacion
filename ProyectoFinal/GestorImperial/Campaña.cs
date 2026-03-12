class Campaña : IComparable<Campaña>, IGestor
{
    #region Propiedades
    public int codigo;
    public Ciudadano? supervisor;
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
        throw new NotImplementedException();
    }

    public void AgregarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void EliminarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
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