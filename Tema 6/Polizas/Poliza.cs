class Poliza
{
    int id;
    float precioAnual;
    Usuario usuario;

    public Poliza(int id, float precioAnual)
    {
        this.id = id;
        this.precioAnual = precioAnual;
    }

    #region get/set
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public float PrecioAnual
    {
        get { return precioAnual; }
        set { precioAnual = value; }
    }

    public Usuario Usuario
    {
        get { return usuario; }
        set { usuario = value; }
    }
    #endregion
}