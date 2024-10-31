//Diseña e implementa una clase Fracción que permita crear fracciones (atributos numerador y denominador tipo enteros),
// con métodos para sumar, restar, multiplicar y dividir las fracciones. 
//Crea una clase tipo excepción FraccionException (declárala como una excepción explícita)
//que se lance siempre que el denominador o el numerador de la fracción sea cero. 
//Hacer que las operaciones lancen (throw) esta excepción si se da el caso, con un mensaje indicativo del tipo de error
//(Ejemplo “El numerador no puede ser cero”) 
//Construir un programa que pruebe el funcionamiento de la clase Fracción y sus operaciones.

namespace Tp2_Lab3
{
    public class Programa
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Ingrese la primera fracción (numerador y denominador separados por un espacio):");
                string[] input1 = Console.ReadLine().Split(' ');
                Fraccion fraccion1 = new Fraccion(int.Parse(input1[0]), int.Parse(input1[1]));

                Console.WriteLine("Ingrese la segunda fracción (numerador y denominador separados por un espacio):");
                string[] input2 = Console.ReadLine().Split(' ');
                Fraccion fraccion2 = new Fraccion(int.Parse(input2[0]), int.Parse(input2[1]));

                Fraccion suma = fraccion1.Sumar(fraccion2);
                Fraccion resta = fraccion1.Restar(fraccion2);
                Fraccion multiplicacion = fraccion1.Multiplicar(fraccion2);
                Fraccion division = fraccion1.Dividir(fraccion2);

                Console.WriteLine($"Suma: {suma}");
                Console.WriteLine($"Resta: {resta}");
                Console.WriteLine($"Multiplicación: {multiplicacion}");
                Console.WriteLine($"División: {division}");
            
            }
            catch (FraccionException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
