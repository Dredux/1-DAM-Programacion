class Principal
{
    static void Main()
    {
        string linea;
        List<Persona> personas = new List<Persona>();
        using (StreamReader fichero = new StreamReader("datos.txt"))
        {
            while ((linea = fichero.ReadLine()) != null)
            {
                string[] partes = linea.Split(';');
                personas.Add(new Persona(partes[0], int.Parse(partes[1])));
            }
        }

        foreach (Persona persona in personas)
        {
            Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
        }   
    }
}