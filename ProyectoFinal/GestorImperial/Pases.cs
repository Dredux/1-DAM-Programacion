class Pases
{
    // Registro
    public void PaseV1(Ciudadano ciudadano)
    {
        Console.WriteLine("* Nivel de acceso: 1 *");
        Console.WriteLine("Acceso al registro imperial...");
        ciudadano.Sector.GestionarElemento(ciudadano);
    }

    // Gestion de Misiones
    public void PaseV2(Ciudadano ciudadano)
    {
        Console.WriteLine("* Nivel de acceso: 2 *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Registro imperial.");
        Console.WriteLine("2- Administrador de misiones.");
        int opcion = Convert.ToInt32(Console.ReadLine());
        GestionarOpcion(ciudadano, opcion);
    }

    // Gestion de Campañas
    public void PaseV3(Ciudadano ciudadano) 
    {
        Console.WriteLine("* Nivel de acceso: 3 *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Registro imperial.");
        Console.WriteLine("2- Administrador de misiones.");
        Console.WriteLine("3- Administrador de campañas.");
        int opcion = Convert.ToInt32(Console.ReadLine());
        GestionarOpcion(ciudadano, opcion);
    }

    // Gestion de Sectores
    public void PaseV4(Ciudadano ciudadano) 
    {
        Console.WriteLine("* Nivel de acceso: 4 *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Registro imperial.");
        Console.WriteLine("2- Administrador de misiones.");
        Console.WriteLine("3- Administrador de campañas.");
        Console.WriteLine("4- Administrador de sectores");
        int opcion = Convert.ToInt32(Console.ReadLine());
        GestionarOpcion(ciudadano, opcion);
    }

    public void GestionarOpcion(Ciudadano ciudadano, int opcion)
    {
        bool valido = false;
        int codigo;
        do
        {
            if (opcion == 1 || opcion == 4)
            {
                valido = true;
                ciudadano.sector.GestionarElemento(ciudadano);
            }
            else if (opcion == 2 && ciudadano.Rango >= Rango.COMANDANTE)
            {
                valido = true;
                Console.Write("Inserte el codigo de la mision: ");
                codigo = Convert.ToInt32(Console.ReadLine());
                Mision mision = Principal.ObtenerMision(codigo);
                if (mision != null)
                {
                    mision.GestionarElemento(ciudadano);
                }
                else
                {
                    Console.WriteLine("Error: codigo " + codigo + " no valido");
                }
            }
            else if (opcion == 3 && ciudadano.Rango >= Rango.VICE_ALMIRANTE)
            {
                valido = true;
                Console.Write("Inserte el codigo de la campaña: ");
                codigo = Convert.ToInt32(Console.ReadLine());
                Campaña campaña = Principal.ObtenerCampaña(codigo);
                if (campaña != null)
                {
                    campaña.GestionarElemento(ciudadano);
                    break;
                }
                else
                {
                    Console.WriteLine("Error: codigo " + codigo + " no valido");
                }
            }
            else
            {
                Console.WriteLine("Error: Opcion no valida\n");
            }
        }
        while (!valido);
    }
}