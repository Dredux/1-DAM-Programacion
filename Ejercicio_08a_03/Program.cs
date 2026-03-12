class Program
{
    static void Main(string[] args)
    {
        string linea;
        int numeroLinea = 0;
        using (StreamReader fichero = new StreamReader("datos.txt"))
        {
            while ((linea = fichero.ReadLine()) != null)
            {
                numeroLinea++;
                if (linea.Contains("programa"))
                {
                    Console.WriteLine("Leído: {0} en la línea {1}", linea, numeroLinea);
                }
            }
        }
    }
}