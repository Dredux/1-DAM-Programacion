using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame un numero:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Dame un numero:");
        int num2 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Dame un numero:");
        int num3 = Convert.ToInt32(Console.ReadLine());
        
        if (num1 > num2 && num1 > num3)
        {
            Console.WriteLine(num1 + " es el mayor de los 3");
        }
        else if (num2 > num1 && num2 > num3)
        {
            Console.WriteLine(num2 + " es el mayor de los 3");
        }
        else
        {
            Console.WriteLine(num3 + " es el mayor de los 3");
        }
    }
}
