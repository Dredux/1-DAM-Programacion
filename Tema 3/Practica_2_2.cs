// Practica que simula la nota final del trimestre
using System;
public class Ejercicio
{
    static void Main()
    {
        double notaPractica = 0, notaTotal = 0, totalPracticas = 0, Examen = 0;
        int numeroPracticas = 0;
        bool practicaSuspensa = false;
        Console.Write("Inserta el numero de practicas realizadas: ");
        try
        {
            numeroPracticas = Convert.ToInt32(Console.ReadLine());
        } catch(Exception e)
        {
            Console.WriteLine("Error: " + e.Message + "\n");
        }

        // Bloque que calcula la media de las practicas 
        for(int i = 1; i <= numeroPracticas; i++)
        {
            Console.Write("Inserta la nota de la practica nº{0}: ", i);
            try
            {
                notaPractica = Convert.ToDouble(Console.ReadLine());
            } catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message + "\n");
                i--;
            }

            if(notaPractica >= 0 && notaPractica <= 10)
            {
                // El programa almacena si ha existido alguna nota menor a 3
                if(notaPractica < 3)
                {
                    practicaSuspensa = true;
                }

                // Si la nota es valida se suma al total de practicas
                totalPracticas += notaPractica;
            }
            else
            {
                i--;
            }
        }
        totalPracticas = totalPracticas / numeroPracticas;


        // Bloque que calcula la nota final
        Console.Write("Inserta la nota del examen: ");
        try
        {
            Examen = Convert.ToDouble(Console.ReadLine());
        } catch(Exception e)
        {
            Console.WriteLine("Error: " + e.Message + "\n");
        }

        if(Examen >= 0 && Examen <= 10)
        {
            // Si la nota es valida se calcula la nota final con los porcentajes
            notaTotal = ((totalPracticas * 30) / 100) + ((Examen * 70) / 100);
            
            // Si no se cumple la condicion se selecciona el valor mas bajo
            if(Examen < 4 || practicaSuspensa == true || totalPracticas < 5)
            {
                notaTotal = Math.Min(notaTotal, 4);
            }
            
            // Redondeamos a 2 decimales y mostramos la nota final
            notaTotal = Math.Round(notaTotal, 2);
            Console.WriteLine("Tu nota final es " + notaTotal);
        }
        else
        {
            Console.WriteLine("Error: Nota de examen no valida.");
        }
    }
}
