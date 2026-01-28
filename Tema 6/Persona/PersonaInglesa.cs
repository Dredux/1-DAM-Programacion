class PersonaInglesa : Persona
{
    public PersonaInglesa(string nombre) : base(nombre)
    {
    }

    public void TomarTe() 
    {
        Console.WriteLine("Estoy tomando te");
    }

    public override void Saludar() 
    {
        Console.WriteLine("Hi, I am " + nombre);
    }
}