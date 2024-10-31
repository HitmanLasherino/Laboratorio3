using System;

public class Arreglo
{
    public static void Main()
    {
        Console.WriteLine("Ingrese el número de filas:");
        int filas = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el número de columnas:");
        int columnas = int.Parse(Console.ReadLine());

        int[,] matriz = new int[filas, columnas];

        Console.WriteLine("Ingrese el valor X:");
        int valorX = int.Parse(Console.ReadLine());

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                // Se considera la posición (i+1) y (j+1) en lugar del índice (i) y (j)
                if ((i + 1) + (j + 1) == valorX)
                {
                    matriz[i, j] = valorX;
                }
                else
                {
                    matriz[i, j] = 0;
                }
            }
        }

        Console.WriteLine("Matriz resultante:");
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
        //EJERCICIO 2 
        Console.WriteLine("Ingrese una cadena de números separados por coma:");
        string input = Console.ReadLine();

        // Separar la cadena en un arreglo de elementos
        string[] elementos = input.Split(',');

        // Convertir los elementos a enteros y calcular la suma total
        int sumaTotal = elementos.Select(int.Parse).Sum();

        // Mostrar el resultado por consola
        Console.WriteLine($"La suma total de los valores es: {sumaTotal}");
    }
}
