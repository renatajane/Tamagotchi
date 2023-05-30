using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{
    public class Mascote
    {
        public int id { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string name { get; set; }
        public List<AbilityItem> abilities { get; set; }
        private int alimento { get; set; }
        private int energia { get; set; }
        private int humor { get; set; }

        public string StatusAlimentar()
        {
            var resposta = "";
            if (alimento <= 3)
            {
                resposta = ("Seu mascote está com muita fome, precisa de mais um pouco de alimento.");
            }
            else if (alimento > 3 && alimento < 5)
            {
                resposta = ("Seu mascote ainda está com fome, precisa de mais alimento.");
            }
            else if (alimento >= 5 && alimento < 7)
            {
                resposta = ("Seu mascote está saciado.");
            }
            else if (alimento > 7)
            {
                resposta = ("Seu mascote está bem alimentado.");
            }
            return resposta;
        }

        public void Alimentar()
        {
            alimento++;
            Console.WriteLine("=^w^=");
            Console.WriteLine("MASCOTE ALIMENTADO");
            Console.WriteLine("\n");

            Console.WriteLine(StatusAlimentar());
        }

        public void Dormir()
        {
            energia ++;
            if (energia >= 5)
            {
                Console.WriteLine("\\O/");
                Console.WriteLine("Energia abastecida. Agora seu mascote pode brincar!!");
            }
            else if (energia < 5)
            {
                Console.WriteLine("zzz");
                Console.WriteLine("Seu mascote precisa dormir um pouco mais.");
            }
        }

        public string StatusHumor()
        {
            var resposta = "";

            if (energia < 5)
            {
                resposta = (":'(");
                resposta = ("Seu mascote está triste, é preciso dormir para ter energia para brincar.");
            }
            if (energia >= 5)
            {
                resposta = ("^_^");
                resposta = ("Seu mascote está muito alegre.");
            }
            return resposta;
        }

        public void Brincar()
        {
            if (energia >= 5)
            {
                humor ++;
                alimento --;
                energia --;
            }
            Console.WriteLine(StatusHumor());
        }
    }
}
