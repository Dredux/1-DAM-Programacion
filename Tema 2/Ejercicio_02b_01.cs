using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Introduce la contraseña:");
        int pass = Convert.ToInt32(Console.ReadLine());
        
        while(pass != 1111)
        {
            Console.WriteLine("Contraseña incorrecta, vuelve a intentarlo:");
            pass = Convert.ToInt32(Console.ReadLine());
        }
        
        Console.WriteLine("Contraseña correcta");
    }
}
