using System;
public class Ejercicio
{
    static void Main()
    {
        Console.WriteLine("Ingresa una unidad de temperatura:");
        char unit = Convert.ToChar(Console.ReadLine());
        int grados = 0, valor = 0, check = 0;
        switch (unit)
        {
            case 'C':
                Console.WriteLine("Ingresa una unidad de temperatura:");
                grados = Convert.ToInt32(Console.ReadLine());
                check = 1;
                break;
            case 'F':
                Console.WriteLine("Ingresa una unidad de temperatura:");
                valor = Convert.ToInt32(Console.ReadLine());
                grados = (valor - 32) / 2;
                Console.WriteLine("{0} Fahrenheit son {1} Celsius",valor,grados);
                check = 1;
                break;
            case 'K':
                Console.WriteLine("Ingresa una unidad de temperatura:");
                valor = Convert.ToInt32(Console.ReadLine());
                grados = grados - 273;
                Console.WriteLine(valor + " Kelvin son " + grados + " Celsius");
                check = 1;
                break;
            default:
                Console.WriteLine("Error: Unidad Incorrecta");                
                break;
        }
        
        if (check == 1)
        {
            if (grados < 10)
            {
                Console.WriteLine("Hace frio");
            } 
            else if (grados >= 10 && grados <= 20)
            {   
                Console.WriteLine("Hace buen tiempo");
            }
            else
            {   
                Console.WriteLine("Hace calor");
            }
        }
    }
}
