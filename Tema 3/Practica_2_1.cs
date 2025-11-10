// Practica que crea una piramide invertida entre simbolos de relleno
using System;
public class Ejercicio
{
    static void Main()
    {
        // Pedimos al usuario los datos y calculamos la longitud de la figura
        int altura = 0, j, x;
        char caracter = ' ';
        Console.WriteLine("Ingresa la altura de la figura:");
        try 
        {
            altura = Convert.ToInt32(Console.ReadLine());
        } catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        int longitud = altura * 2;
        
        
        Console.WriteLine("Ingresa el caracter con el que pintar:");
        try 
        {
            caracter = Convert.ToChar(Console.ReadLine());
        } catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        
        // Creamos 4 bucles, 1 para las filas y 3 anidados para las columnas
        for(int i = 0; i < altura; i++)
        {
            int pintados = 0;
            // Pintamos los caracteres de la izquierda
            for(j = 0; j <= i; j++)
            {
                Console.Write(caracter);
                pintados++;
            }
            
            // Pintamos los espacios en funcion de los caracteres restantes
            for(x = j; x < (longitud - i) - 1; x++)
            {
                Console.Write(" ");
                pintados++;
            }
            
            // Pintamos los caracteres a la derecha a partir de los ya pintados
            for(int y = 0; y < (longitud - pintados); y++)
            {
                Console.Write(caracter);
            }
            Console.WriteLine();
        }
    }
}
