using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame una letra:");
        char letra = Convert.ToChar(Console.ReadLine());
        
        if(letra.Equals('A') || 
           letra.Equals('E') || 
           letra.Equals('I') || 
           letra.Equals('O') || 
           letra.Equals('U'))
        {
            Console.WriteLine("Es una vocal");
        }
        else
        {
            Console.WriteLine("No es una vocal");
        }
    }
}
