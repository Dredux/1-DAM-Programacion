class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        string linea;
        using (StreamReader fichero = new StreamReader("datos.txt"))
        {
            while ((linea = fichero.ReadLine()) != null)
            {
                if (!linea.Contains(linea))
                {
                    list.Add(linea);
                }
            }
        }

        list.Sort();

        using (StreamWriter fichero1 = new StreamWriter("prueba.txt"))
        {
            foreach (string l in list)
            {
                fichero1.WriteLine(l);
            }
        }
    }
}