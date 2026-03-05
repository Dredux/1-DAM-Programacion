class Mision : IComparable<Mision>, IGestor
{
    public int Codigo { get; set; }
    public Estado Estado { get; set; }
    public Ciudadano Responsable { get; set; }

    public Mision(Estado estado, Ciudadano responsable)
    {
        Estado = estado;
        Responsable = responsable;
        responsable.Supervisor = true;
    }

    #region Gestor
    public void GestionarElemento(Ciudadano ciudadano)
    {
        Console.WriteLine("\n* Administrador de Misiones *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Modificar responsable.");
        Console.WriteLine("2- Modificar estado.");
        Console.WriteLine("3- Mostrar datos.");
        int opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        { 
            case 1:
                AgregarElemento();
                break;
            case 2:
                ModificarElemento(ciudadano);
                break;
            case 3:
                MostrarElemento();
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }

    public void AgregarElemento()
    {
        throw new NotImplementedException();
    }

    public void ModificarElemento(Ciudadano ciudadano)
    {
        throw new NotImplementedException();
    }

    public void MostrarElemento()
    {
        ToString();
    }
    #endregion

    public int CompareTo(Mision? other)
    {
        if (other == null) { return 1; }
        return Codigo.CompareTo(other.Codigo);
    }

    public override string ToString()
    {
        return "Codigo: "+Codigo+", Responsable: "+Responsable.Nombre+", Sector: "+Estado;
    }
}