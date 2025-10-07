using System;
public class Ejercicio
{
    static void Main()
    {
        int total = 0, num;
        do 
        {
            Console.WriteLine("Dame un numero:");
            num = Convert.ToInt32(Console.ReadLine());
            total = total + num;
        } while(num != 0);
        
        Console.WriteLine("Suma total: " + total);
    }
}
