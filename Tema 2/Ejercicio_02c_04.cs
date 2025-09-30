using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame un numero:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Dame otro numero:");
        int num2 = Convert.ToInt32(Console.ReadLine());
        
        if(num2 > 0)
        {
            Console.WriteLine(num1/num2);
        } else 
        {
            Console.WriteLine("No se puede dividir por 0 ");
        }
    }
}
