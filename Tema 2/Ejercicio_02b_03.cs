using System;
public class Ejercicio
{
    static void Main()
    {
        int pass;
        do 
        {
            Console.WriteLine("Introduce la contraseña:");
            pass = Convert.ToInt32(Console.ReadLine());
        } while(pass != 1111);
        
        Console.WriteLine("Contraseña correcta");
    }
}
