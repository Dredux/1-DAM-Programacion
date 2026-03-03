class Ejercicio_07b_01
{
    static void main(string[] args)
    {
        SortedList<string, double> alumnos = new SortedList<string, double>();

        for (int i = 0; i < 5; i++)
        {
            Console.Write("\nEscribe un nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Escribe una nota: ");
            double nota = Convert.ToDouble(Console.ReadLine());
            alumnos.Add(nombre,nota);             
        }

        for (int i = 0; i < alumnos.Count; i++)
        {
            Console.WriteLine(alumnos.Keys[i] + ", " + alumnos.Values[i]);
        }
    }
}