using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testWebApp.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime FinalDate { get; set; }

        public Mission() {}
    }
}
