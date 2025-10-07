using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame un caracter:");
        char caracter = Convert.ToChar(Console.ReadLine());
        
        if (caracter >= 'A' && caracter <= 'Z')
        {
            Console.WriteLine("Grupo 1: Letras mayusculas");
        }
        else if(caracter >= '0' && caracter <= '9' )
        {
            Console.WriteLine("Grupo 2: Digitos del 0 al 9");
        }
        else
        {
            Console.WriteLine("El caracter no pertenece a ningun grupo");
        }
    }
}
