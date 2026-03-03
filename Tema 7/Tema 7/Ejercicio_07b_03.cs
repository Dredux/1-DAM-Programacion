class Ejercicio_07b_03
{
    static void Main(string[] args) 
    {
        HashSet<string> ganadores = new HashSet<string>();
        string nombre;
        for (int i = 0; i < 10; i++)
        {
            Console.Write("\nIntroduce un ganador de Wimbledon: ");
            nombre = Console.ReadLine();
            ganadores.Add(nombre);
        }

        foreach (string ganador in ganadores)
        {
            Console.WriteLine(ganador);
        }
    }
}