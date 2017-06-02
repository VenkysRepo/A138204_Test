using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.View_Models
{
    public class SortedPetsListbyGender
    {
        public string Gender { get; set; }
        public List<string> petsList { get; set; }
    }
}
