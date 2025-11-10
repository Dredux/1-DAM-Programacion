using System;
public class Ejercicio
{
    static void Main()
    {
        int numero, n = 2;
        bool primo = true;
        
        Console.WriteLine("Escribe un número:");
        numero = Convert.ToInt32(Console.ReadLine());
        
        while(primo == true && n <= numero/2)
        {
            if(numero % n == 0)
            {
                primo = false;
            }
            n++;
        }
        
        if(primo && numero > 1)
        {
            Console.WriteLine("Es primo");
        }
        else
        {
            Console.WriteLine("No es primo");
        }

    }
}
