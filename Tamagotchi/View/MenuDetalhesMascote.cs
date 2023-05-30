using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    public class MenuDetalhesMascote
    {
        public void DetalharMascote(Mascote mascote)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Nome Pokemon: " + mascote.name);
            Console.WriteLine("Altura: " + mascote.height);
            Console.WriteLine("Peso: " + mascote.weight);
            Console.WriteLine(mascote.StatusAlimentar());
            Console.WriteLine(mascote.StatusHumor());
            Console.WriteLine("Habilidades:");

            for (int j = 0; j < mascote.abilities.Count; j++)
            {
                Console.WriteLine(mascote.abilities[j].ability.name);
            }
            Console.WriteLine("--------------------------");
        }
    }
}
