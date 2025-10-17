using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Dame un numero:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Dame otro numero:");
        int num2 = Convert.ToInt32(Console.ReadLine());
        
        if (num1 >= 0 || num2 >= 0)
        {
            Console.WriteLine("Uno de los numeros es positivo");
        }
        else if(num1 >= 0 && num2 >= 0)
        {
            Console.WriteLine("Los dos numeros son positivos");
        }
        else
        {
            Console.WriteLine("Ninguno de los numeros es positivo");
        }
    }
}
