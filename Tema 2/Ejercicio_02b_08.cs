using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame un numero del 1 al 10:");
        int num = Convert.ToInt32(Console.ReadLine());
        
        if (num > 0 && num < 11)
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine("{0} x {1} = {2}", num, i, num * i);
            }
        }
    }
}
