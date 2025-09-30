using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Escribe un numero:");
        int numero = Convert.ToInt32(Console.ReadLine());
        
        if(numero % 2 == 0)
        {
            Console.WriteLine("Es par");
        }
    }
}
