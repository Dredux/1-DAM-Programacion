using System;
public class Ejercicio
{
    static void Main()
    {
        int[] array = new int[6];
        for(int i = 0; i < array.Length; i++)
        {
            Console.Write("Dame un numero: ");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
        
        for(int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write(array[i] + ", ");
        }
    }
}
