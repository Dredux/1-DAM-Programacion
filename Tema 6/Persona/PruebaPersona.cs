class PruebaPersona
{
    static void Main(string[] args)
    {
        Persona p1 = new Persona("Pablo");
        Persona p2 = new PersonaInglesa("Daniel");
        Persona p3 = new PersonaItaliana("Giovanni");

        p1.Saludar();
        p2.Saludar();
        ((PersonaInglesa)p2).TomarTe();
        p3.Saludar();
    }
}