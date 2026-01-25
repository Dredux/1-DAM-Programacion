class Practica4
{
    public struct Fecha
    {
        public int dia;
        public int mes;
        public int anyo;
    }

    public struct Contacto
    {
        public string nombreApellidos;
        public string direccion;
        public string telefono;
        public string ciudad;
        public Fecha fechaNacimiento;
    }

    public enum opciones { NUEVO = 1, BORRAR, BUSCAR_CIUDAD, BUSCAR_ANYO, ORDENAR, SALIR }

    public static opciones MostrarMenu()
    {
        Console.WriteLine("\n1. Nuevo contacto");
        Console.WriteLine("2. Borrar contacto");
        Console.WriteLine("3. Buscar contactos por ciudad");
        Console.WriteLine("4. Buscar contactos por año de nacimiento");
        Console.WriteLine("5. Ordenar contactos por nombre");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
        opciones opcion = opciones.SALIR;
        try
        {
            opcion = (opciones)Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e.Message);
        }
        return opcion;
    }

    public static void NuevoContacto(Contacto[] agenda, ref int cantidad)
    {
        Contacto nuevo;
        bool fechaValida;
        do
        {
            Console.Write("Nombre y apellidos: ");
            nuevo.nombreApellidos = Console.ReadLine();
        } while (nuevo.nombreApellidos == "");

        do
        {
            Console.Write("Dirección: ");
            nuevo.direccion = Console.ReadLine();
        } while (nuevo.direccion == "");

        do
        {
            Console.Write("Teléfono: ");
            nuevo.telefono = Console.ReadLine();
        } while (nuevo.telefono == "");

        do
        {
            Console.Write("Ciudad: ");
            nuevo.ciudad = Console.ReadLine();
        } while (nuevo.ciudad == "");

        do
        {
            Console.Write("Fecha de nacimiento (dd/mm/aaaa): ");
            string fechaTexto = Console.ReadLine();
            string[] partes = fechaTexto.Split('/');

            // Asignamos unos valores iniciales a la fecha
            // para que no dé error de compilación
            nuevo.fechaNacimiento.dia = 0;
            nuevo.fechaNacimiento.mes = 0;
            nuevo.fechaNacimiento.anyo = 0;

            fechaValida = false;
            try
            {
                if (partes.Length == 3)
                {
                    int dia = Convert.ToInt32(partes[0]);
                    int mes = Convert.ToInt32(partes[1]);
                    int anyo = Convert.ToInt32(partes[2]);

                    if (dia >= 1 && dia <= 31 &&
                        mes >= 1 && mes <= 12 &&
                        anyo >= 1950 && anyo <= 2020)
                    {
                        nuevo.fechaNacimiento.dia = dia;
                        nuevo.fechaNacimiento.mes = mes;
                        nuevo.fechaNacimiento.anyo = anyo;
                        fechaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Fecha no válida");
                    }
                }
                else
                {
                    Console.WriteLine("Formato incorrecto");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Formato incorrecto");
            }
        } while (!fechaValida);

        agenda[cantidad] = nuevo;
        cantidad++;
        Console.WriteLine("Contacto añadido correctamente.");
    }

    public static void BorrarContacto(Contacto[] agenda, ref int cantidad)
    {
        int posicion;
        Console.WriteLine("\n== CONTACTOS ACTUALES ==");
        for (int i = 0; i < cantidad; i++)
        {
            MostrarContacto(agenda, i);
        }

        do
        {
            Console.Write("¿Qué contacto quieres borrar?");
            posicion = Convert.ToInt32(Console.ReadLine());
        } while (posicion < 1 || posicion > cantidad);

        posicion--;

        for (int i = posicion; i < cantidad - 1; i++)
        {
            agenda[i] = agenda[i + 1];
        }

        cantidad--;
        Console.WriteLine("Contacto borrado correctamente.");
    }

    public static void MostrarContactosCiudad(Contacto[] agenda, int cantidad, string ciudadBuscada)
    {
        bool encontrado = false;
        for (int i = 0; i < cantidad; i++)
        {
            if (agenda[i].ciudad.ToLower() == ciudadBuscada.ToLower())
            {
                MostrarContacto(agenda, i);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No existen contactos de esa ciudad");
        }
    }

    public static void MostrarContactosAnyo(Contacto[] agenda, int cantidad, int anyoBuscado)
    {
        bool encontrado = false;
        for (int i = 0; i < cantidad; i++)
        {
            if (agenda[i].fechaNacimiento.anyo == anyoBuscado)
            {
                MostrarContacto(agenda, i);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron " +
                "contactos de ese año");
        }
    }

    public static void OrdenarContactos(Contacto[] agenda, int cantidad)
    {
        for (int i = 0; i < cantidad - 1; i++)
        {
            for (int j = i + 1; j < cantidad; j++)
            {
                if (string.Compare(agenda[i].nombreApellidos,
                    agenda[j].nombreApellidos) > 0)
                {
                    Contacto temp = agenda[i];
                    agenda[i] = agenda[j];
                    agenda[j] = temp;
                }
            }
        }

        Console.WriteLine("\n== CONTACTOS ORDENADOS POR NOMBRE ==");
        for (int i = 0; i < cantidad; i++)
        {
            MostrarContacto(agenda, i);
        }
    }

    public static void MostrarContacto(Contacto[] agenda, int i)
    {
        Console.WriteLine("{0}, {1}, {2}, {3}, " +
            "{4}/{5}/{6}",
            agenda[i].nombreApellidos,
            agenda[i].direccion,
            agenda[i].telefono,
            agenda[i].ciudad,
            agenda[i].fechaNacimiento.dia.
                ToString("00"),
            agenda[i].fechaNacimiento.mes.
                ToString("00"),
            agenda[i].fechaNacimiento.anyo);
    }

    static void Main()
    {
        const int CAPACIDAD = 50;
        Contacto[] agenda = new Contacto[CAPACIDAD];
        int cantidad = 0;
        opciones opcion;
        do
        {
            opcion = MostrarMenu();
            switch (opcion)
            {
                case opciones.NUEVO:
                    if (cantidad < CAPACIDAD)
                    {
                        NuevoContacto(agenda, ref cantidad);
                    }
                    else
                    {
                        Console.WriteLine("La agenda está llena.");
                    }
                    break;
                case opciones.BORRAR:
                    if (cantidad > 0)
                    {
                        BorrarContacto(agenda, ref cantidad);
                    }
                    else
                    {
                        Console.WriteLine("No hay contactos para borrar.");
                    }
                    break;
                case opciones.BUSCAR_CIUDAD:
                    Console.WriteLine("Indica el nombre de la ciudad: ");
                    string ciudad = Console.ReadLine();
                    MostrarContactosCiudad(agenda, cantidad, ciudad);
                    break;
                case opciones.BUSCAR_ANYO:
                    Console.WriteLine("Indica un año: ");
                    int numeroAnyo = Convert.ToInt32(Console.ReadLine());
                    MostrarContactosAnyo(agenda, cantidad, numeroAnyo);
                    break;
                case opciones.ORDENAR:
                    OrdenarContactos(agenda, cantidad);
                    break;
                case opciones.SALIR:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        while (opcion != opciones.SALIR);
    }
}