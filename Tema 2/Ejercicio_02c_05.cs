using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame un numero:");
        int num = Convert.ToInt32(Console.ReadLine());
        
        if(num % 2 == 0 || num % 3 == 0)
        {
            Console.WriteLine(num + " es multiplo de 2 o de 3");
        } else
        {
            Console.WriteLine(num + " no es multiplo de 2 ni de 3");
        }
    }
}
