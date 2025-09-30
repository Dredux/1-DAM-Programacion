// Convertidor de metros a millas
using System;
class Ejercicio 
{
	static void Main()
	{
        Console.WriteLine("Inserta una cantidad de metros:");
		int metros = Convert.ToInt32(Console.ReadLine());
        int millas;
		Console.WriteLine((millas=metros/1609));
	}
}
