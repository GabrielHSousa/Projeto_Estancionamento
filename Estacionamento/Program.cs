using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Gerente men = new Gerente();
            men.Execultar();
            Console.ReadLine();
        }
    }
}