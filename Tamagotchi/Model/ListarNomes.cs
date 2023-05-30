using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{
    public class ListarNomes
    {
        public string previous { get; set; }
        public string next { get; set; }
        public List<ListarNomesDetalhes> results { get; set; }
    }
}
