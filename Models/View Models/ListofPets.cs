﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.View_Models
{
    public class ListofPets
    {
        public List<SortedPetsListbyGender> SortedList { get; set; }

        public string ErrorMessage { get; set; }
    }
}
