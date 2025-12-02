using System;
public class Ejercicio2
{
    static void Main()
    {
        Console.Write("Dame un numero: ");
        int num = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[100];
        int comparador = 0, contador = 0;
        
        for (int i = 1; i < num; i++)
        {
            if (num % i == 0)
            {
                array[contador] = i;
                contador++;
            }
        }
        
        for (int i = 0; i < contador; i++)
        {                                                                        
            comparador += array[i];
        }
        
        if (comparador == num)
        {
            Console.WriteLine("Es perfecto");
        }
        else
        {
            Console.WriteLine("No es perfecto");
        }
    }
}
