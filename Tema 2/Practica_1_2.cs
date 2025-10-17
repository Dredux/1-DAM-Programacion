// Programa que pide tres numeros y obtiene todos sus comunes multiplos.
using System;
public class Ejercicio
{
    static void Main()
    {
        int x = 0, y = 0, z = 0, mcm = 0, check = 0;
        // Filtramos valores no deseados.
        do
        {
            Console.WriteLine("Ingresa el valor de X [1-365]:");
            x = Convert.ToInt32(Console.ReadLine());

            if (!(x >= 1 && x <= 365))
            {
                Console.WriteLine("Error: Valor fuera de rango");
                check = 0;
            }
            else
            {
                check = 1;
            }
        } while(check != 1);

        do
        {
            Console.WriteLine("Ingresa el valor de Y [1-365]:");
            y = Convert.ToInt32(Console.ReadLine());

            if (!(y >= 1 && y <= 365))
            {
                Console.WriteLine("Error: Valor fuera de rango");
                check = 0;
            }
            else
            {
                check = 1;
            }
        } while(check != 1);

        do
        {
            Console.WriteLine("Ingresa el valor de Z [1-365]:");
            z = Convert.ToInt32(Console.ReadLine());

            if (!(z >= 1 && z <= 365))
            {
                Console.WriteLine("Error: Valor fuera de rango");
                check = 0;
            }
            else
            {
                check = 1;
            }
        } while(check != 1);
        
        // Preguntamos cual numero es el mayor de los tres.
        mcm = x > y ? x : y;
        mcm = mcm > z ? mcm : z;
        
        for (int i = mcm; i <= 365; i++)
        {
            // Preguntamos si el valor de i es divisible por los tres numeros.
            if (!(i % x != 0 || i % y != 0 || i % z != 0))
            {
                Console.WriteLine("Coinciden el dia " + i);
            }
        }
    }
}
