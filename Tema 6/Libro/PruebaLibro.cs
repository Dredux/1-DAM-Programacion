class PruebaLibro
{
    static void Main(String[] args) 
    {
        Libro l1 = new Libro("Juan", "Star Wars: Lior", "Alicante");
        Console.WriteLine(l1.Autor + ", " + l1.Titulo + ", " + l1.Ubicacion);
    }
}