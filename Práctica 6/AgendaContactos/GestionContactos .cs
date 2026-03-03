class GestionContactos
{
    List<Contacto> agenda;

    public GestionContactos()
    {
        agenda = new List<Contacto>();
    }

    public Opciones MostrarMenu()
    {
        Opciones opcion;

        Console.WriteLine("\n== MENÚ ==");
        Console.WriteLine("1. Añadir contacto");
        Console.WriteLine("2. Borrar contacto");
        Console.WriteLine("3. Mostrar contactos de una ciudad");
        Console.WriteLine("4. Mostrar contactos por año");
        Console.WriteLine("5. Ordenar array por nombre");
        Console.WriteLine("6. Salir del programa");
        Console.Write("\nElige una opción: ");
        opcion = (Opciones)Convert.ToInt32(Console.ReadLine());

        return opcion;
    }

    public void NuevoContacto() 
    {
        Contacto nuevo = new Contacto();
        bool fechaValida;
        do
        {
            Console.Write("Nombre y apellidos: ");
            nuevo.NombreApellidos = Console.ReadLine();
        } while (nuevo.NombreApellidos == "");

        do
        {
            Console.Write("Dirección: ");
            nuevo.Direccion = Console.ReadLine();
        } while (nuevo.Direccion == "");

        do
        {
            Console.Write("Teléfono: ");
            nuevo.Telefono = Console.ReadLine();
        } while (nuevo.Telefono == "");

        do
        {
            Console.Write("Ciudad: ");
            nuevo.Ciudad = Console.ReadLine();
        } while (nuevo.Ciudad == "");

        do
        {
            Console.Write("Fecha de nacimiento (dd/mm/aaaa): ");
            string fechaTexto = Console.ReadLine();
            string[] partes = fechaTexto.Split('/');
            fechaValida = false;

            if (partes.Length == 3
                && Int32.TryParse(partes[0], out int dia)
                && Int32.TryParse(partes[1], out int mes)
                && Int32.TryParse(partes[2], out int anyo))
            {
                if (dia >= 1 && dia <= 31 &&
                    mes >= 1 && mes <= 12 &&
                    anyo >= 1950 && anyo <= 2020)
                {
                    nuevo.Dia = dia;
                    nuevo.Mes = mes;
                    nuevo.Anyo = anyo;
                    nuevo.FechaNacimiento = fechaTexto;
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

        } while (!fechaValida);

        agenda.Add(nuevo);
        Console.WriteLine("Contacto añadido correctamente.");
    }

    public void BorrarContacto()
    {
        foreach (Contacto contacto in agenda)
        {
            contacto.ToString();
        }

        int posicion;
        if (agenda.Count > 0)
        {
            do
            {
                Console.Write("¿Qué contacto quieres borrar?");
                posicion = Convert.ToInt32(Console.ReadLine());
            } while (posicion < 1 || posicion > agenda.Count);

            posicion--;

            for (int i = posicion; i < agenda.Count - 1; i++)
            {
                agenda[i] = agenda[i + 1];
            }
            Console.WriteLine("Contacto borrado correctamente.");
        }
        else
        {
            Console.WriteLine("No hay contactos para borrar.");
        }
    }

    public void MostrarContactosCiudad(string ciudad) 
    {
        bool encontrado = false;
        if (agenda.Count > 0)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Ciudad.ToLower() == ciudad.ToLower())
                {
                    agenda[i].ToString();
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No existen contactos de esa ciudad");
            }
        }
        else
        {
            Console.WriteLine("No hay contactos almacenados.");
        }
    }

    public void MostrarContactosAnyo(int anyo) 
    {
        bool encontrado = false;

        for (int i = 0; i < agenda.Count; i++)
        {
            if (agenda[i].Anyo == anyo)
            {
                agenda[i].ToString();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron contactos de ese año");
        }
    }

    public void OrdenarContactos()
    {
        if (agenda.Count > 0)
        {
            for (int i = 0; i < agenda.Count - 1; i++)
            {
                for (int j = i + 1; j < agenda.Count; j++)
                {
                    if (string.Compare(agenda[i].NombreApellidos,
                        agenda[j].NombreApellidos) > 0)
                    {
                        Contacto temp = agenda[i];
                        agenda[i] = agenda[j];
                        agenda[j] = temp;
                    }
                }
            }

            Console.WriteLine("\n== CONTACTOS ORDENADOS POR NOMBRE ==");
            foreach (Contacto contacto in agenda)
            {
                contacto.ToString();
            }
        }
        else
        {
            Console.WriteLine("No hay contactos almacenados.");
        }
    }
}