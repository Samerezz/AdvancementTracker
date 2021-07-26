using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancementTracker.src.Core.Advancement
{
    public class Advancements
    {
        public Advancement MonstersHunted { get; set; } = new Advancement();
        public Advancement AdventuringTime { get; set; } = new Advancement();
        public Advancement TwoByTwo { get; set; } = new Advancement();
        public Advancement ABlanacedDiet { get; set; } = new Advancement();
    }
}
