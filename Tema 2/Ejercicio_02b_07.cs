using System;
public class Ejercicio
{
    static void Main()
    {
        for(int i = 100; i <= 200; i++)
        {
            if (i % 3 == 0 || i % 7 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
