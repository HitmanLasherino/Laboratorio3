using System;
using System.Threading;

public class Program
{
    public static void ejecutarHiloCincoSeg()
    {
        while (true)
        {
            Console.WriteLine("HILO EJECUTADO 5");
            Thread.Sleep(5000); // Pausa el hilo por 5 segundos
        }
    }

    public static void ejecutarHiloDiezSeg()
    {
        while (true)
        {
            Console.WriteLine("HILO EJECUTADO 10");
            Thread.Sleep(10000); // Pausa el hilo por 10 segundos
        }
    }

    public static void Main()
    {
        Thread hiloCincoSeg = new Thread(new ThreadStart(ejecutarHiloCincoSeg));
        Thread hiloDiezSeg = new Thread(new ThreadStart(ejecutarHiloDiezSeg));

        hiloCincoSeg.Start();
        hiloDiezSeg.Start();

        Console.ReadLine();
    }
}