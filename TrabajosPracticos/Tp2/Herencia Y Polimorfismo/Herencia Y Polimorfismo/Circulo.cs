using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia_Y_Polimorfismo
{
    public class Circulo : Figura
    {
        public override void Dibujar()
        {
            Console.WriteLine("Dibuja Círculo");
        }
    }
}
