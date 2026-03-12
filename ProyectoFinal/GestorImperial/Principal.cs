class Principal
{
    static void Main(string[] args)
    {
        GenerarSectores();
        Pases pases = new Pases();
        Ciudadano? ciudadano = null;
        Rango paseAsignado;
        bool salir = false, valido = false;
        int id, opcion;

        Console.WriteLine("* SISTEMA GESTOR IMPERIAL *");
        do
        {
            Console.Write("Ingrese un numero de identificacion: ");
            id = Convert.ToInt32(Console.ReadLine());
            ciudadano = ObtenerUsuario(id);

            if (ciudadano != null && ciudadano.Rango >= Rango.TENIENTE)
            {
                valido = true;
                Console.WriteLine("Acceso concedido: Bienvenido " + ciudadano.Nombre.ToUpper());
            }
            else
            {
                Console.WriteLine("Error: Usuario " + id + " no valido.\n");
            }
        }
        while (!valido);

        do
        {
            Console.WriteLine("\nSeleccione una opcion:");
            Console.WriteLine("1- Acceder al gestor");
            Console.WriteLine("2- Salir");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                paseAsignado = ciudadano!.Rango;
                switch (paseAsignado)
                {
                    case Rango.TENIENTE:
                    case Rango.CAPITAN:
                        pases.PaseV1(ciudadano);
                        break;
                    case Rango.COMANDANTE:
                    case Rango.COMODORO:
                        pases.PaseV2(ciudadano);
                        break;
                    case Rango.VICE_ALMIRANTE:
                    case Rango.ALMIRANTE:
                        pases.PaseV3(ciudadano);
                        break;
                    case Rango.ALMIRANTE_DE_FLOTA:
                    case Rango.GRAN_ALMIRANTE:
                        pases.PaseV4(ciudadano);
                        break;
                }
            }
            else
            {
                salir = true;
            }
        }
        while (!salir);
    }

    public static void GenerarSectores()
    {
        Random rm = new Random();
        String caracteres = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        Ciudadano ciudadano;
        char[] listaCaracteres = caracteres.ToCharArray();

        for (int i = 0; i < 10; i++)
        {
            String nombre = "";
            for (int j = 0; j < 8; j++)
            {
                nombre += listaCaracteres[rm.Next(caracteres.Length)];
            }
            Sector sector = new Sector(nombre);

            for (int x = 0; x < 8; x++)
            {
                ciudadano = GenerarCiudadanos(sector);
                sector.ListaUsuarios.Add(ciudadano);
            }

            Sector.listaSectores.Add(sector);
        }
    }

    public static Ciudadano GenerarCiudadanos(Sector sector)
    {
        Random rm = new Random();
        String caracteres = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        char[] listaCaracteres = caracteres.ToCharArray();
        String nombre = "";
        int edad = rm.Next(18, 70), numRango = rm.Next(0, 10);

        for (int j = 0; j < 8; j++)
        {
            nombre += listaCaracteres[rm.Next(listaCaracteres.Length)];
        }

        Ciudadano ciudadano = new Ciudadano(nombre.ToLower(), edad, sector);
        ciudadano.ID = sector.ListaUsuarios.Count + 1;
        ciudadano.Rango = (Rango)numRango;
        return ciudadano;
    }

    public static Ciudadano? ObtenerUsuario(int id)
    {
        foreach (Sector sector in Sector.listaSectores)
        {
            foreach (Ciudadano ciudadano in sector.ListaUsuarios)
            {
                if (ciudadano.ID == id)
                {
                    return ciudadano;
                }
            }
        }
        return null;
    }

    public static Mision? ObtenerMision(int codigo)
    {
        foreach (Sector sector in Sector.listaSectores)
        {
            foreach (Campaña campaña in sector.listaCampañas)
            {
                foreach (Mision mision in campaña.ListaMisiones)
                {
                    if (mision.codigo == codigo)
                    {
                        return mision;
                    }
                }
            }
        }
        return null;
    }

    public static Campaña? ObtenerCampaña(int codigo)
    {
        foreach (Sector sector in Sector.listaSectores)
        {
            foreach (Campaña campaña in sector.listaCampañas)
            {
                if (campaña.Codigo == codigo)
                {
                    return campaña;
                }
            }
        }
        return null;
    }

    public static Sector? ObtenerSector(string nombre)
    {
        foreach (Sector sector in Sector.listaSectores)
        {
            if (sector.Nombre == nombre)
            {
                return sector;
            }
        }
        return null;
    }
}