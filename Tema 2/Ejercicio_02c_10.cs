using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Introduce un numero:");
        int num = Convert.ToInt32(Console.ReadLine());
        
        if (num > 0)
        {
            for (int i = num; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
