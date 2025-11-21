using System;
public class Ejercicio
{
    static void Main()
    {
        String[] titulos = new String[100];
        int cantidad = 0;
        titulos[0] = "ejemplo1";
        titulos[1] = "ejemplo2";
        titulos[2] = "ejemplo3";
        titulos[3] = "ejemplo4";
        cantidad = 4;
        
        Console.Write("Titulo del nuevo videojuego: ");
        titulos[cantidad] = Console.ReadLine();
        cantidad++;
        
        
    }
}
