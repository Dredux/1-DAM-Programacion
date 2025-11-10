using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Introduce el usuario:");
        string usr = Console.ReadLine();
        string pass, pass2;

        do 
        {
            Console.WriteLine("Introduce la contraseña:");
            pass = Console.ReadLine();
            
            Console.WriteLine("Introduce la contraseña nuevamente:");
            pass2 = Console.ReadLine();
        } while(!pass.Equals(pass2));
    }
}
