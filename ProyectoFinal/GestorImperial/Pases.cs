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
        Console.WriteLine("* Nivel de acceso: 3 *");
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
            switch (opcion)
            {
                case 4:
                case 1:
                    valido = true;
                    ciudadano.Sector.GestionarElemento(ciudadano);
                    break;
                case 2:
                    valido = true;
                    Console.Write("Inserte el codigo de la mision: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Mision? mision = ObtenerMision(ciudadano, codigo);
                    if (mision != null)
                    {
                        mision.GestionarElemento(ciudadano);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: codigo " + codigo + " no valido");
                    }
                    break;
                case 3:
                    valido = true;
                    Console.Write("Inserte el codigo de la campaña: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Campaña? campaña = ObtenerCampaña(ciudadano, codigo);
                    if (campaña != null)
                    {
                        campaña.GestionarElemento(ciudadano);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: codigo " + codigo + " no valido");
                    }
                    break;
                default:
                    Console.WriteLine("Error: Opcion no valida\n");
                    break;
            }
        }
        while (!valido);
    }

    public Mision? ObtenerMision(Ciudadano ciudadano, int codigo) 
    {
        foreach (Campaña campaña in ciudadano.Sector.ListaCampañas)
        {
            foreach (Mision mision in campaña.ListaMisiones)
            {
                if (mision.Codigo == codigo)
                {
                    return mision;
                }
            }
        }
        return null;
    }

    public Campaña? ObtenerCampaña(Ciudadano ciudadano, int codigo) 
    {
        foreach (Campaña campaña in ciudadano.Sector.ListaCampañas)
        {
            if (campaña.Codigo == codigo)
            {
                return campaña;
            }
        }
        return null;
    }
}