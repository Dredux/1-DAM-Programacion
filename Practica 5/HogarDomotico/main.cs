class main
{
    static void Main()
    {
        GestorDomotico gestor = new GestorDomotico();
        ConsoleKeyInfo tecla;
        do
        {
            Puerta puertaPrincipal = (Puerta)gestor.GetElemento(0);
            Puerta puertaGaraje = (Puerta)gestor.GetElemento(1);
            IEncendible luzSalon = (IEncendible)gestor.GetElemento(2);
            IEncendible luzCocina = (IEncendible)gestor.GetElemento(3);
            Horno horno = (Horno)gestor.GetElemento(4);
            Calefaccion calefaccion = (Calefaccion)gestor.GetElemento(5);

            Console.WriteLine();
            gestor.MostrarEstado();
            Console.WriteLine("\nA/B Abrir/Cerrar " + puertaPrincipal.Nombre);
            Console.WriteLine("C/D Abrir/Cerrar " + puertaGaraje.Nombre);
            Console.WriteLine("E/F On/Off " + gestor.GetElemento(2).Nombre);
            Console.WriteLine("G/H On/Off " + gestor.GetElemento(3).Nombre);
            Console.WriteLine("I/J On/Off " + horno.Nombre);
            Console.WriteLine("K/L Subir/Bajar " + horno.Nombre);
            Console.WriteLine("M/N On/Off " + calefaccion.Nombre);
            Console.WriteLine("O/P Subir/Bajar " + calefaccion.Nombre);
            Console.WriteLine("Q. Apagar todo");
            Console.WriteLine("S. Salir");
            Console.Write("Seleccione una opción: ");
            tecla = Console.ReadKey();
            Console.WriteLine();

            switch (char.ToUpper(tecla.KeyChar))
            {
                case 'A':
                    puertaPrincipal.abrirCerrar();
                    break;
                case 'B':
                    puertaPrincipal.abrirCerrar();
                    break;
                case 'C':
                    puertaGaraje.abrirCerrar();
                    break;
                case 'D':
                    puertaGaraje.abrirCerrar();
                    break;
                case 'E':
                    luzSalon.Encender();
                    break;
                case 'F':
                    luzSalon.Apagar();
                    break;
                case 'G':
                    luzCocina.Encender();
                    break;
                case 'H':
                    luzCocina.Apagar();
                    break;
                case 'I':
                    horno.Encender();
                    break;
                case 'J':
                    horno.Apagar();
                    break;
                case 'K':
                    horno.Temperatura++;
                    break;
                case 'L':
                    horno.Temperatura--;
                    break;
                case 'M':
                    calefaccion.Encender();
                    break;
                case 'N':
                    calefaccion.Apagar();
                    break;
                case 'O':
                    calefaccion.Temperatura++;
                    break;
                case 'P':
                    calefaccion.Temperatura--;
                    break;
                case 'Q':
                    gestor.ApagarTodo();
                    break;
                case 'S':
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
        while (char.ToUpper(tecla.KeyChar) != 'S');
    }
}