using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame 10 nombres:");
        String[] nombres = new String[10];
        bool check = false;
        int casilla = 0;
        
        for(int i = 0; i < nombres.Length; i++)
        {
            nombres[i] = Console.ReadLine();
        }
        
        Console.Write("Dame un nombre a buscar:");
        String buscar = Console.ReadLine();
        
        for(int i = 0; i < nombres.Length; i++)
        {
            if(nombres[i].Equals(buscar))
            {
                check = true;
                casilla = i;
            }
        }
        
        if(check)
        {
            Console.WriteLine("Nombre \'{0}\' encontrado en la posicion {1}", buscar, casilla + 1);
        }
        else 
        {
            Console.WriteLine("Nombre no encontrado");
        }
    }
}
