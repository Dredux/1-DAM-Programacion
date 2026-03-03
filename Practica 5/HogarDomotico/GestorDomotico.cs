class GestorDomotico
{
    ElementoDomotico[] elementos;

    public GestorDomotico()
    {
        elementos = new ElementoDomotico[6];
        elementos[0] = new Puerta("Puerta principal");
        elementos[1] = new Puerta("Puerta garaje");
        elementos[2] = new Luz("Luz salon");
        elementos[3] = new Luz("Luz cocina");
        elementos[4] = new Horno("Horno cocina", false, 0);
        elementos[5] = new Calefaccion("Calefaccion central", false, 20);
    }

    public ElementoDomotico GetElemento(int posicion)
    {
        return elementos[posicion];
    }

    public void MostrarEstado()
    {
        foreach (ElementoDomotico elemento in elementos)
        {
            bool estado = false;
            if (elemento is Puerta puerta)
            {
                estado = puerta.Abierta;
            }
            else if (elemento is IEncendible encendible)
            {
                estado = encendible.Consultar();
            }

            if (estado)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
            }

            Console.ResetColor();
            elemento.Mostrar();
        }
    }

    public void ApagarTodo()
    {
        foreach (ElementoDomotico elemento in elementos)
        {
            if (elemento is IEncendible encendible)
            {
                encendible.Apagar();
            }
        }
    }
}