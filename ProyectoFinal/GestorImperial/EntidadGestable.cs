//Clase base abstracta para todas las entidades gestables del sistema.
//Define el comportamiento común de gestión de elementos.
abstract class EntidadGestable : IGestor
{
    // Métodos abstractos que las clases derivadas deben implementar
    // para gestionar elementos específicos.
    public abstract void GestionarElemento(Ciudadano ciudadano);

    public abstract void AgregarElemento(Ciudadano ciudadano);

    public abstract void ModificarElemento(Ciudadano ciudadano);

    public abstract void EliminarElemento(Ciudadano ciudadano);

    protected void MostrarMenuGestion(string nombreEntidad)
    {
        Console.WriteLine($"\n* Administrador de {nombreEntidad} *");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1- Añadir elemento.");
        Console.WriteLine("2- Modificar elemento.");
        Console.WriteLine("3- Eliminar elemento.");
        Console.WriteLine("4- Mostrar datos.");
    }

    protected void EjecutarAccion(int opcion, Ciudadano ciudadano)
    {
        switch (opcion)
        {
            case 1:
                AgregarElemento(ciudadano);
                break;
            case 2:
                ModificarElemento(ciudadano);
                break;
            case 3:
                EliminarElemento(ciudadano);
                break;
            case 4:
                Console.WriteLine(ToString());
                break;
            default:
                Console.WriteLine("Error: Opcion no valida");
                break;
        }
    }
}