using Objetos;
using System;
public class Program
{
    public static void Main()
    {
        Deposito deposito = new Deposito
        {
            Nombre = "Deposito Central",
            Domicilio = "Calle Falsa 123",
            Articulos = new List<Articulo>
            {
                new Articulo { Codigo = "A1", StockTotal = 5, StockMinimo = 10 },
                new Articulo { Codigo = "A2", StockTotal = 15, StockMinimo = 10 },
                new Articulo { Codigo = "A3", StockTotal = 8, StockMinimo = 8 }
            }
        };

        List<Articulo> articulosBajoStock = deposito.ArticulosBajoStock();

        Console.WriteLine("Artículos bajo stock:");
        foreach (Articulo articulo in articulosBajoStock)
        {
            Console.WriteLine($"Código: {articulo.Codigo}, Stock Total: {articulo.StockTotal}, Stock Mínimo: {articulo.StockMinimo}");
        }
    }
}   