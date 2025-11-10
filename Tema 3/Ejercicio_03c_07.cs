using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Introduce un texto:");
        string texto = Console.ReadLine();
        bool check = false;
        
        foreach(char letra in texto)
        {
            if(letra == 'a')
            {
                check = true;
            }
        }
        
        if(check)
        {
            Console.WriteLine("El texto tiene \'a\' minuscula");
        }
        else 
        {
            Console.WriteLine("El texto no tiene \'a\' minuscula");
        }
    }
}
