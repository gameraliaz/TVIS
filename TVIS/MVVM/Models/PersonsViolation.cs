using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVIS.MVVM.Models
{
    public class PersonsViolation
    {
        public string Pelak { get; }
        public int? CostSum { get; set; }
        public PersonsViolation(string pelak) { Pelak = pelak; }
    }
}
