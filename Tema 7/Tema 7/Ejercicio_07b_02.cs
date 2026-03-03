class Ejercicio_07b_02
{
    static void main(string[] args)
    {
        Dictionary<string, Trabajador> trabajadores = new Dictionary<string, Trabajador>();
        string nuss, nombre;
        int telf;
        do
        {
            Console.Write("\nIntroduce un nuss: ");
            nuss = Console.ReadLine();
            if (nuss != "")
            {
                Console.Write("Introduce un nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Introduce un telefono: ");
                telf = Convert.ToInt32(Console.ReadLine());
                trabajadores.Add(nuss, new Trabajador(nuss, nombre, telf));
            }
        }
        while (nuss != "");

        foreach (KeyValuePair<string, Trabajador> dato in trabajadores)
        {
            Console.WriteLine("{0}: {1}", dato.Key, dato.Value);
        }
    }
}