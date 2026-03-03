class Contacto
{
    string nombreApellidos;
    string direccion;
    string telefono;
    string ciudad;
    int dia;
    int mes;
    int anyo;
    string fechaNacimiento;

    public Contacto()
    {
        nombreApellidos = "";
        direccion = "";
        telefono = "";
        ciudad = "";
        dia = 0;
        mes = 0;
        anyo = 0;
        fechaNacimiento = "";
    }

    #region
    public string NombreApellidos
    {
        get { return nombreApellidos; } 
        set { nombreApellidos = value; }
    }

    public string Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }

    public string Telefono
    {
        get { return telefono; }
        set { telefono = value; }
    }

    public string Ciudad
    {
        get { return ciudad; }
        set { ciudad = value; }
    }

    public int Dia
    {
        get { return dia; }
        set { dia = value; }
    }

    public int Mes
    {
        get { return mes; }
        set { mes = value; }
    }

    public int Anyo
    {
        get { return anyo; }
        set { anyo = value; }
    }

    public string FechaNacimiento
    {
        get { return fechaNacimiento; }
        set { fechaNacimiento = value; }
    }
    #endregion

    public override string ToString()
    {
        return "Datos: " + nombreApellidos + ", " + direccion 
            + ", " + telefono + ", " + ciudad
            + ", FechaNacimiento: " + fechaNacimiento;
    }
}