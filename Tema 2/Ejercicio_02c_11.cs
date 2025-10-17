using System;
public class Ejercicio
{
    static void Main()
    {
        int numSec = 81, numUsr = 0;
        
        do
        {
            Console.WriteLine("Introduce un numero:");
            numUsr = Convert.ToInt32(Console.ReadLine());
            
            if (numUsr < numSec)
            {
                Console.WriteLine("Te has quedado corto");
            }
            else if (numUsr > numSec) 
            {
                Console.WriteLine("Te has pasado");
            }
        } while(numUsr != numSec);
        
        Console.WriteLine("Has acertado");
    }
}
