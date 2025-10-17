using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Introduce un numero:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Introduce un segundo numero:");
        int num2 = Convert.ToInt32(Console.ReadLine());
                
        int mcd = (num1 < num2) ? num1:num2;
         
        for (int i = mcd; i >= 1; i--)
        {
            if (num1 % i == 0 && num2 % i == 0)
            {
                Console.WriteLine("El mcd es " + i);
                break;
            }
        }
    }
}
