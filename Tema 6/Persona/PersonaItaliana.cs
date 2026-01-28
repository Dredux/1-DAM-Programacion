class PersonaItaliana : Persona
{
    public PersonaItaliana(string nombre) : base(nombre)
    {
    }

    public override void Saludar()
    {
        Console.WriteLine("Ciao");
    }
}
