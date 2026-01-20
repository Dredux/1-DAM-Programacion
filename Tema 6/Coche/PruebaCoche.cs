class PruebaCoche
{
    static void Main(string[] args) 
    {
        Coche c1 = new Coche("Citroen", "UF-84", 270, 5.7);
        Console.WriteLine(c1.Marca + ", " + c1.Modelo + ", " + c1.Cilindrada + ", " + c1.Potencia);
    }
}