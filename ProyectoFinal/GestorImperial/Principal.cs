// Clase principal: Controla el flujo principal de la aplicación
// y proporciona métodos para obtener datos dentro de la estructura del sistema.
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
        // Bucle para solicitar el ID de usuario hasta que se ingrese uno válido con el rango requerido.
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

        // Bucle para mostrar el menú de opciones hasta que el usuario decida salir.
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
            else if (opcion == 2)
            {
                salir = true;
            }
            else
            {
                Console.WriteLine("Error: Opcion no valida");
            }
        }
        while (!salir);
    }

    #region Generadores
    // Genera sectores con nombres aleatorios y asigna ciudadanos a cada sector.
    public static void GenerarSectores()
    {
        Random rm = new Random();
        String caracteres = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        Ciudadano ciudadano;
        char[] listaCaracteres = caracteres.ToCharArray();

        for (int i = 0; i < Sector.listaSectores.Length; i++)
        {
            String nombre = "";
            for (int j = 0; j < 8; j++)
            {
                nombre += listaCaracteres[rm.Next(caracteres.Length)];
            }

            Sector sector = new Sector(nombre);
            Sector.listaSectores[i] = sector;
            Sector.contadorSectores++;

            for (int x = 0; x < 8; x++)
            {
                ciudadano = GenerarCiudadanos(sector);
                sector.ListaUsuarios.Add(ciudadano);
            }
        }
    }

    // Genera ciudadanos con datos aleatorios, asignándolos a un sector específico.
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
        ciudadano.ID = ActualizarIDGlobalCiudadano();

        ciudadano.Rango = (Rango)numRango;
        return ciudadano;
    }
    #endregion

    #region Actualizar ID
    // Métodos para obtener el siguiente ID, evitando colisiones al buscar por ID.
    public static int ActualizarIDGlobalCiudadano()
    {
        // Recorre todos los sectores y ciudadanos para encontrar el ID máximo y retorna el siguiente.
        int max = 0;
        foreach (Sector? sector in Sector.listaSectores)
        {
            if (sector == null) { continue; }

            foreach (Ciudadano ciudadano in sector.ListaUsuarios)
            {
                if (ciudadano.ID > max)
                {
                    max = ciudadano.ID;
                }
            }
        }
        // Retorna el siguiente ID disponible.
        return max + 1;
    }

    public static int ActualizarIDGlobalCampaña()
    {
        int max = 0;
        foreach (Sector? sector in Sector.listaSectores)
        {
            if (sector == null) { continue; }

            foreach (Campaña campaña in sector.listaCampañas)
            {
                if (campaña.Codigo > max)
                {
                    max = campaña.Codigo;
                }
            }
        }
        return max + 1;
    }

    public static int ActualizarIDGlobalMision()
    {
        int max = 0;
        foreach (Sector? sector in Sector.listaSectores)
        {
            if (sector == null) { continue; }

            foreach (Campaña campaña in sector.listaCampañas)
            {
                foreach (Mision mision in campaña.ListaMisiones)
                {
                    if (mision.Codigo > max)
                    {
                        max = mision.Codigo;
                    }
                }
            }
        }
        return max + 1;
    }
    #endregion

    #region Obtener elemento
    // Métodos para obtener elementos, recorriendo la estructura completa de la aplicación.
    public static Ciudadano? ObtenerUsuario(int id)
    {
        foreach (Sector? sector in Sector.listaSectores)
        {
            if (sector == null) { continue; }

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
        foreach (Sector? sector in Sector.listaSectores)
        {
            if (sector == null) { continue; }

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
        foreach (Sector? sector in Sector.listaSectores)
        {
            if (sector == null) { continue; }

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
        foreach (Sector? sector in Sector.listaSectores)
        {
            if (sector == null) { continue; }

            if (sector.Nombre == nombre)
            {
                return sector;
            }
        }
        return null;
    }
    #endregion
}