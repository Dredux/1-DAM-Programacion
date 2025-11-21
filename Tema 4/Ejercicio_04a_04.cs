using System;
public class Ejercicio
{
    static void Main()
    {
        Console.Write("Inserta la cantidad de numeros a introducir: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());
        float media = 0;
        float[] array = new float[cantidad];
        
        for(int i = 0; i < array.Length; i++)
        {
            Console.Write("Inserta el {0}ºnumero: ", i + 1);
            array[i] = Convert.ToSingle(Console.ReadLine());
            media += array[i];
        }
        
        media /= cantidad;
        Console.WriteLine("Numeros por encima de la media:");
        for(int i = 0; i < array.Length; i++)
        {
            if(array[i] >= media)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
