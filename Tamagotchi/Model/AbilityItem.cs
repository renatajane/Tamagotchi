using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{
    public class AbilityItem
    {
        public Ability ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }
}
