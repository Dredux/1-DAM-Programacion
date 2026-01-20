class Libro
{
    string autor;
    string titulo;
    string ubicacion;

    public Libro(string autor, string titulo, string ubicacion)
    {
        this.autor = autor;
        this.titulo = titulo;
        this.ubicacion = ubicacion;
    }

    #region get/set
    public string Autor
    {
        get { return autor; }
        set { autor = value; }
    }

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Ubicacion
    {
        get { return ubicacion; }
        set { ubicacion = value; }
    }
    #endregion
}