using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Introduce el tamaño del triangulo:");
        int num = Convert.ToInt32(Console.ReadLine());
        
        for (int i = 1; i <= num; i++)
        {
            for (int j = 0; j < num - i; j++)
            {
                Console.Write(" ");
            }

            for (int k = 0; k < i; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
