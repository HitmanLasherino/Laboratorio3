namespace Tp2_Lab3
{
    public class Fraccion
    {
        public int Numerador { get; set; }
        public int Denominador { get; set; }

        public Fraccion(int numerador, int denominador)
        {
            if (numerador == 0)
            {
                throw new FraccionException("El numerador no puede ser cero.");
            }
            if (denominador == 0)
            {
                throw new FraccionException("El denominador no puede ser cero.");
            }
            Numerador = numerador;
            Denominador = denominador;
        }
        public Fraccion Sumar(Fraccion otra)
        {
            int nuevoNumerador = Numerador * otra.Denominador + otra.Numerador * Denominador;
            int nuevoDenominador = Denominador * otra.Denominador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        public Fraccion Restar(Fraccion otra)
        {
            int nuevoNumerador = Numerador * otra.Denominador - otra.Numerador * Denominador;
            int nuevoDenominador = Denominador * otra.Denominador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        public Fraccion Multiplicar(Fraccion otra)
        {
            int nuevoNumerador = Numerador * otra.Numerador;
            int nuevoDenominador = Denominador * otra.Denominador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        public Fraccion Dividir(Fraccion otra)
        {
            if (otra.Numerador == 0)
            {
                throw new FraccionException("No se puede dividir por una fracción con numerador cero.");
            }
            int nuevoNumerador = Numerador * otra.Denominador;
            int nuevoDenominador = Denominador * otra.Numerador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }
    }

}
