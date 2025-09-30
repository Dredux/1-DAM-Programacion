using System;
class Ejercicio 
{
	static void Main()
	{
		Console.WriteLine("Dame un primer numero: ");
        int n1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Dame un segundo numero: ");
        int n2 = Convert.ToInt32(Console.ReadLine());
        
        int div = n1/n2, rest = n1%n2;
        
        Console.WriteLine("{0} / {1} = {2}", n1,n2,div);
        Console.WriteLine("{0} % {1} = {2}", n1,n2,rest);
	}
}
