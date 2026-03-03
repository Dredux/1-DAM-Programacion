class Principal
{
    public static void Main(string[] args) 
    {
        GestionContactos contactos = new GestionContactos();
        Opciones opcion;
        string ciudadBuscada;
        int anyoBuscado;
        do
        {
            opcion = contactos.MostrarMenu();

            switch (opcion)
            {
                case Opciones.NUEVO:
                    contactos.NuevoContacto();
                    break;

                case Opciones.BORRAR:
                    contactos.BorrarContacto();
                    break;

                case Opciones.BUSCAR_CIUDAD:
                    Console.Write("Introduce el nombre de la ciudad: ");
                    ciudadBuscada = Console.ReadLine();
                    contactos.MostrarContactosCiudad(ciudadBuscada);
                    break;

                case Opciones.BUSCAR_ANYO:
                    Console.Write("Introduce el año de nacimiento: ");
                    anyoBuscado = Convert.ToInt32(Console.ReadLine());
                    contactos.MostrarContactosAnyo(anyoBuscado);
                    break;

                case Opciones.ORDENAR:
                    contactos.OrdenarContactos();
                    break;

                case Opciones.SALIR:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != Opciones.SALIR);
    }
}