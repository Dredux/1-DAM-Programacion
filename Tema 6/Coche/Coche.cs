class Coche
{
    string marca;
    string modelo;
    int cilindrada;
    double potencia;

    public Coche(string marca, string modelo, int cilindrada, double potencia)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.cilindrada = cilindrada;
        this.potencia = potencia;
    }

    #region get/set
    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public int Cilindrada
    {
        get { return cilindrada; }
        set { cilindrada = value; }
    }

    public double Potencia
    {
        get { return potencia; }
        set { potencia = value; }
    }
    #endregion
}