using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.View
{
    public class Menu
    {
        public string BoasVindas()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("====== Olá, qual é o seu nome? ======");
            string nome = Console.ReadLine();             
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("Bem - vindo (a) ao Tamagotchi, " + nome + "!");
            Console.WriteLine("=====================================");
            return nome;
        }

        public string MenuInicial()
        {
            Console.WriteLine("\n");
            Console.WriteLine("1 - Adotar mascotes");
            Console.WriteLine("2 - Ver mascotes adotados");
            Console.WriteLine("3 - Sair do jogo");
            Console.WriteLine("=====================================");
            Console.WriteLine("\n");
            Console.WriteLine("Digite a opção desejada: ");
            string opcao = Console.ReadLine();
            return opcao;
            Console.Clear();

        }
    }
}
