class Principal : IGestor
{
    public SortedSet<Sector> listaSectores { get; set; }

    public Principal()
    {
        listaSectores = new SortedSet<Sector>();
        generarSectores();
    }

    static void Main(string[] args, Principal app)
    {

    }

    #region Gestor
    public static void gestionarSectores()
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
        foreach (Sector sector in listaSectores)
        {
            sector.ToString();
        }
    }
    #endregion

    public void generarSectores()
    {
        Random rm = new Random();
        String caracteres = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        char[] listaCaracteres = caracteres.ToCharArray();

        for (int i = 0; i < 3; i++)
        {
            String nombre = "";
            for (int j = 0; j < 8; j++)
            {
                nombre += listaCaracteres[rm.Next(caracteres.Length)];
            }
            Ciudadano encargado = generarEncargado(rm, listaCaracteres);
            listaSectores.Add(new Sector(nombre, encargado));
        }
    }

    public Ciudadano generarEncargado(Random rm, char[] lista)
    {
        String nombre = "";
        int edad = rm.Next(18, 70), numRango = rm.Next(8, 10);
        for (int j = 0; j < 8; j++)
        {
            nombre += lista[rm.Next(lista.Length)];
        }

        Ciudadano encargado = new Ciudadano(nombre.ToLower(), edad);
        encargado.Rango = (Rango)numRango;
        return encargado;
    }
}