class Mision : IComparable<Mision>, IGestor
{
    public int Codigo { get; set; }
    public Estado Estado { get; set; }
    public Ciudadano Responsable { get; set; }

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

    public int CompareTo(Mision? other)
    {
        if (other == null) { return 1; }
        return Codigo.CompareTo(other.Codigo);
    }

    public override string ToString()
    {
        return "Codigo: "+Codigo+", Responsable: "+Responsable+", Sector: "+Estado;
    }
}