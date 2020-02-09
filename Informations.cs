using System;
using System.Collections.Generic;

namespace CompanyMailingList
{
    public partial class Informations
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Profile { get; set; }
        public bool Dynamic { get; set; }
        public string Email { get; set; }
        public string TypeInformation { get; set; }
    }
}
