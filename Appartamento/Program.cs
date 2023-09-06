using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicode_U4_W2_D2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Appartamento.AppartamentiList.Add(new Appartamento(3, true, false, 1, 200, 1));
            Appartamento.AppartamentiList.Add(new Appartamento(3, false, false, 3, 10, 5));
            Appartamento.AppartamentiList.Add(new Appartamento(3, false, true, 2, 170, 3));


            while (true)
                Appartamento.Menu();

        }
    }
}
