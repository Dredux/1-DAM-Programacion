class Principal : IGestor
{
    public SortedSet<Sector> listaSectores { get; set; }

    public Principal()
    {
        listaSectores = new SortedSet<Sector>();
        generarSectores();
    }

    static void Main(string[] args)
    {
        Principal app = new Principal();
        Pases pases = new Pases();
        Ciudadano? ciudadano;
        Rango paseAsignado;
        bool salir = false, valido = false;
        int id, opcion;

        Console.WriteLine("* SISTEMA GESTOR IMPERIAL *");
        do
        {
            Console.Write("Ingrese un numero de identificacion: ");
            id = Convert.ToInt32(Console.ReadLine());
            ciudadano = app.obtenerUsuario(id);

            if (ciudadano != null && ciudadano.Rango >= Rango.TENIENTE)
            {
                valido = true;
                Console.WriteLine("\nAcceso concedido: Bienvenido " + ciudadano.Nombre.ToUpper());
            }
            else
            {
                Console.WriteLine("\nError: Usuario " + id + " no valido.");
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
                paseAsignado = ciudadano.Rango;
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

    #region Gestor
    public void GestionarElemento(Ciudadano ciudadano)
    {
        Console.WriteLine("\n* Administrador de Sectores *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Añadir sectores.");
        Console.WriteLine("2- Modificar sectores.");
        Console.WriteLine("3- Mostrar datos.");
        int opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                AgregarElemento();
                break;
            case 2:
                ModificarElemento(ciudadano);
                break;
            case 3:
                MostrarElemento();
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void AgregarElemento()
    {
        throw new NotImplementedException();
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void MostrarElemento()
    {
        throw new NotImplementedException();
    }
    #endregion

    public void generarSectores()
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
                ciudadano = generarCiudadanos(rm, listaCaracteres, sector);
                sector.ListaUsuarios.Add(ciudadano);
            }
        }
    }

    public Ciudadano generarCiudadanos(Random rm, char[] lista, Sector sector)
    {
        String nombre = "";
        int edad = rm.Next(18, 70), numRango = rm.Next(0, 10);
        for (int j = 0; j < 8; j++)
        {
            nombre += lista[rm.Next(lista.Length)];
        }

        Ciudadano encargado = new Ciudadano(nombre.ToLower(), edad, sector);
        encargado.Rango = (Rango)numRango;
        return encargado;
    }

    public Ciudadano? obtenerUsuario(int id) 
    {
        foreach (Sector sector in listaSectores)
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
}