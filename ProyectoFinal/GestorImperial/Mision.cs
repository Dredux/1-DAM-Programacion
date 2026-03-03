class Mision : IComparable<Mision>, IGestor
{
    protected int codigo;
    protected Estado estado;
    protected Ciudadano responsable;

    public Mision(Estado estado, Ciudadano responsable)
    {
        Estado = estado;
        Responsable = responsable;
    }

    #region Gestor
    public static void gestionarMision()
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

    public Estado Estado 
    {
        get { return estado; }
        set { estado = value; }
    }

    public Ciudadano Responsable
    {
        get { return responsable; }
        set { responsable = value; }
    }
    #endregion

    public int CompareTo(Mision? other)
    {
        if (other == null) { return 1; }
        return codigo.CompareTo(other.codigo);
    }

    public override string ToString()
    {
        return "Codigo: "+Codigo+", Responsable: "+Responsable+", Sector: "+Estado;
    }
}