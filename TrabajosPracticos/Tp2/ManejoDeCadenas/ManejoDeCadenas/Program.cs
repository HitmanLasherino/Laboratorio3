using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Ingrese la primera cadena de texto:");
        string primeraCadena = Console.ReadLine();

        Console.WriteLine("Ingrese la segunda cadena de texto:");
        string segundaCadena = Console.ReadLine();

        if (segundaCadena.Length > primeraCadena.Length)
        {
            Console.WriteLine("La segunda cadena no puede ser más larga que la primera cadena.");
        }
        else
        {
            if (primeraCadena.Contains(segundaCadena))
            {
                Console.WriteLine("ENCONTRADO");
            }
            else
            {
                Console.WriteLine("NO ENCONTRADO");
            }
        }
    }
}
