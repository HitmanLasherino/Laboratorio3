using System;

public class Cheque
{
    public string Banco { get; set; }
    public decimal Importe { get; set; }
    public int Numero { get; set; }
    public string Propietario { get; set; }
    private int NroInterno { get; set; }

    public void Guardar()
    {
        Console.WriteLine("Cheque guardado.");
    }

    public void Imprimir()
    {
        
        Console.WriteLine($"Cheque: {Numero}, Banco: {Banco}, Importe: {Importe}, Propietario: {Propietario}");
    }

    public bool ValidarNroInterno(int nro)
    {
        
        return NroInterno == nro;
    }
}