// Clase Pases: Gestiona los diferentes niveles de acceso para los ciudadanos
// permitiendo la interacción con el sistema según su rango y responsabilidades.
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

    // Método auxiliar para gestionar las opciones de acceso según el rango del ciudadano.
    public void GestionarOpcion(Ciudadano ciudadano, int opcion)
    {
        bool valido = false;
        int codigo;

        do
        {
            if (opcion == 1)
            {
                valido = true;
                ciudadano.Sector.GestionarElemento(ciudadano);
            }
            else if (opcion == 2 && ciudadano.Rango >= Rango.COMANDANTE)
            {
                Console.Write("Inserte el codigo de la mision: ");
                codigo = Convert.ToInt32(Console.ReadLine());
                Mision? mision = Principal.ObtenerMision(codigo);

                if (mision != null)
                {
                    valido = true;
                    mision.GestionarElemento(ciudadano);
                }
                else
                {
                    Console.WriteLine("Error: Mision no encontrada");
                }
            }
            else if (opcion == 3 && ciudadano.Rango >= Rango.VICE_ALMIRANTE)
            {
                Console.Write("Inserte el codigo de la campaña: ");
                codigo = Convert.ToInt32(Console.ReadLine());
                Campaña? campaña = Principal.ObtenerCampaña(codigo);

                if (campaña != null)
                {
                    valido = true;
                    campaña.GestionarElemento(ciudadano);
                }
                else
                {
                    Console.WriteLine("Error: Campaña no encontrada");
                }
            }
            else if (opcion == 4 && ciudadano.Rango >= Rango.ALMIRANTE_DE_FLOTA)
            {
                valido = true;
                ciudadano.Sector.GestionarElemento(ciudadano);
            }
            else
            {
                Console.WriteLine("Error: Opcion no valida\n");
            }

            if (!valido)
            {
                opcion = Convert.ToInt32(Console.ReadLine());
            }
        }
        while (!valido);
    }
}