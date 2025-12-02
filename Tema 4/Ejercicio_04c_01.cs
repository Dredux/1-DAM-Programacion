using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame una letra:");
        char letra = Convert.ToChar(Console.ReadLine());

        if (letra >= 'a' && letra <= 'z')
        {
            Console.WriteLine("Es una minuscula");
        }
        else
        {
            Console.WriteLine("Es una mayscula");
        }
        Console.WriteLine("Codigo numerico = {0}", (int)letra);
    }
}
