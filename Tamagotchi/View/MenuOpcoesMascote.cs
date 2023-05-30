using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    internal class MenuOpcoesMascote
    {
        public string EscolherAcao(Mascote mascote, String nome)
        {
            Console.WriteLine(nome + " ,você deseja:");
            Console.WriteLine("1 - Saber como " + mascote.name + " está");
            Console.WriteLine("2 - Alimentar " + mascote.name);
            Console.WriteLine("3 - Brincar com " + mascote.name);
            Console.WriteLine("4 - Colocar " + mascote.name + " para dormir");
            Console.WriteLine("5 - Voltar");
            var opcaoEscolhida = Console.ReadLine();
            return opcaoEscolhida;
            Console.Clear();
        }
    }
}
