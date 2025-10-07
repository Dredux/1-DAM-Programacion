using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame un numero:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Dame otro numero:");
        int num2 = Convert.ToInt32(Console.ReadLine());
        
        int menor = (num1 > num2) ? num2 : num1; 
        Console.WriteLine(menor);
    }
}
