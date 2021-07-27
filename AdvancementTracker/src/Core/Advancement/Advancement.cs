using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AdvancementTracker.src.Core.Advancement
{
    public class Advancement
    {
        public List<AdvancementObject> Objects { get; set; } = new List<AdvancementObject>();
        
       
    }
}
