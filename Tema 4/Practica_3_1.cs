using System;
public class Ejercicio2
{
    struct fecha
	{
		public int dia;
		public int mes;
		public int anyo;
	}
    
    struct contacto
	{
		public string nombre;
		public string direccion;
		public string telefono;
		public string ciudad;
        public fecha nacimiento;
	}
    
    static void Main()
    {
        contacto[] agenda = new contacto[50];
        int opcion, contadorContactos = 0, contactosMostrados = 0;
        bool check = false;
        do
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Añadir contacto.");
            Console.WriteLine("2. Borrar contacto.");
            Console.WriteLine("3. Mostrar contactos de una ciudad.");
            Console.WriteLine("4. Mostrar contactos por año.");
            Console.WriteLine("5. Mostrar contactos por nombre.");
            Console.WriteLine("6. Salir.\n");
            Console.Write("Inserta una opcion: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            switch(opcion)
            {
                case 1:
                    contacto nuevo;
                    fecha birthday;
                    birthday.dia = 0; 
                    birthday.mes = 0; 
                    birthday.anyo = 0;
                    
                    Console.WriteLine("\n=== AÑADIR CONTACTO ===");
                    Console.Write("Nombre completo: ");
                    nuevo.nombre = Console.ReadLine();
                    Console.Write("Direccion: ");
                    nuevo.direccion = Console.ReadLine();
                    Console.Write("Numero de telefono: ");
                    nuevo.telefono = Console.ReadLine();
                    Console.Write("Ciudad:");
                    nuevo.ciudad = Console.ReadLine();
                    Console.Write("Dia de nacimiento: ");
                    birthday.dia = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Mes de nacimiento: ");
                    birthday.mes = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Año de nacimiento: ");
                    birthday.anyo = Convert.ToInt32(Console.ReadLine());
                    nuevo.nacimiento = birthday;
                                        
                    if(contadorContactos < agenda.Length)
                    {
                        agenda[contadorContactos] = nuevo;
                        contadorContactos++;
                        Console.WriteLine("\nContacto añadido con exito.");
                    } else 
                    {
                        Console.WriteLine("ERROR: Se ha alcanzado la " +
                        "capacidad maxima de la agenda.");
                    }
                    break;
                case 2:
                    if (contadorContactos > 0)
                    {
                        for(int i = 0; i < contadorContactos; i++)
                        {
                            Console.WriteLine(i+1 
                            + "º: Nombre: " + agenda[i].nombre 
                            + ", Direccion: " + agenda[i].direccion
                            + ", Telefono: " + agenda[i].telefono
                            + ", Ciudad: " + agenda[i].ciudad
                            + ", Fecha de nacimiento: {0}/{1}/{2}"
                            , agenda[i].nacimiento.dia
                            , agenda[i].nacimiento.mes
                            , agenda[i].nacimiento.anyo);
                        }
                        
                        Console.Write("\nSelecciona el contacto a borrar: ");
                        int num = 0;
                        num = Convert.ToInt32(Console.ReadLine());
                        
                        if (contadorContactos > 0 && (num-1) >= 0 && (num-1) < contadorContactos)
                        {
                            for (int i = num; i < contadorContactos - 1; i++)
                            {
                                agenda[i] = agenda[i+1];
                            }
                            contadorContactos--;
                            Console.WriteLine("Contacto eliminado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Agenda vacia");
                    }
                    break;
                case 3:
                    Console.Write("Ingresa la ciudad: ");
                    String nombreCiudad = Console.ReadLine();
                    for(int i = 0; i < contadorContactos; i++)
                    {
                        if (nombreCiudad.ToLower()
                        .Equals(agenda[i].ciudad.ToLower()))
                        {
                            Console.WriteLine(i+1 
                            + "º: Nombre: " + agenda[i].nombre 
                            + ", Direccion: " + agenda[i].direccion
                            + ", Telefono: " + agenda[i].telefono
                            + ", Ciudad: " + agenda[i].ciudad
                            + ", Fecha de nacimiento: {0}/{1}/{2}"
                            , agenda[i].nacimiento.dia
                            , agenda[i].nacimiento.mes
                            , agenda[i].nacimiento.anyo);
                            
                            contactosMostrados++;
                        }
                    }
                    
                    if (contactosMostrados == 0)
                    {
                        Console.WriteLine("No existen contactos en la ciudad.");
                    }
                    contactosMostrados = 0;
                    break;
                case 4:
                    Console.Write("Ingresa un año de nacimiento: ");
                    int anyoNacimiento = Convert.ToInt32(Console.ReadLine());
                    for(int i = 0; i < contadorContactos; i++)
                    {
                        if (anyoNacimiento == agenda[i].nacimiento.anyo)
                        {
                            Console.WriteLine(i+1 
                            + "º: Nombre: " + agenda[i].nombre 
                            + ", Direccion: " + agenda[i].direccion
                            + ", Telefono: " + agenda[i].telefono
                            + ", Ciudad: " + agenda[i].ciudad
                            + ", Fecha de nacimiento: {0}/{1}/{2}"
                            , agenda[i].nacimiento.dia
                            , agenda[i].nacimiento.mes
                            , agenda[i].nacimiento.anyo);
                            
                            contactosMostrados++;
                        }
                    }
                    
                    if (contactosMostrados == 0)
                    {
                        Console.WriteLine("No existen contactos en ese año.");
                    }
                    contactosMostrados = 0;
                    break;
                case 5:
                    for (int i = 0; i < contadorContactos - 1; i++)
                    {
                        for (int j = i + 1; j < contadorContactos; j++)
                        {
                            if (agenda[i].nombre.CompareTo(agenda[j].nombre) > 0)
                            {
                                contacto auxiliar = agenda[i];
                                agenda[i] = agenda[j];
                                agenda[j] = auxiliar;
                            }
                        }
                    }
                    
                    for(int i = 0; i < contadorContactos; i++)
                    {
                        Console.WriteLine((i+1) + "º: Nombre: " + agenda[i].nombre 
                        + ", Direccion: " + agenda[i].direccion
                        + ", Telefono: " + agenda[i].telefono
                        + ", Ciudad: " + agenda[i].ciudad
                        + ", Fecha de nacimiento: {0}/{1}/{2}"
                        , agenda[i].nacimiento.dia
                        , agenda[i].nacimiento.mes
                        , agenda[i].nacimiento.anyo);
                    }
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    check = true;
                    break;
                default:
                    Console.WriteLine("ERROR: Opcion no valida.");
                    break;
            }
        } while(!check);
    }
}
