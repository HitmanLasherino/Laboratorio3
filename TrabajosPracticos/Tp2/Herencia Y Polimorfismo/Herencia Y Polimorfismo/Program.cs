using Herencia_Y_Polimorfismo;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Figura> figuras = new List<Figura>
        {
            new Rectangulo(),
            new Figura(),
            new Circulo(),
            new Figura(),
            new Triangulo(),
            new Figura()
        };

        foreach (Figura figura in figuras)
        {
            figura.Dibujar();
        }
    }
}

