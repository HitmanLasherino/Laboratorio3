//Diseña e implementa una clase Fracción que permita crear fracciones (atributos numerador y denominador tipo enteros),
// con métodos para sumar, restar, multiplicar y dividir las fracciones. 
//Crea una clase tipo excepción FraccionException (declárala como una excepción explícita)
//que se lance siempre que el denominador o el numerador de la fracción sea cero. 
//Hacer que las operaciones lancen (throw) esta excepción si se da el caso, con un mensaje indicativo del tipo de error
//(Ejemplo “El numerador no puede ser cero”) 
//Construir un programa que pruebe el funcionamiento de la clase Fracción y sus operaciones.
public class FraccionException : Exception
{
    public FraccionException(string mensaje) : base(mensaje) { }
}