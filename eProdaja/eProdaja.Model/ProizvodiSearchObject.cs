using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public class ProizvodiSearchObject
    {
        public string Naziv { get; set; }
        public int? VrstaID { get; set; }//nullable int, ako ne poslajemo objekat on je null
        public int? JedinicaMjereID { get; set; }
        public bool? IncludeJedinicaMjere { get; set; }

    }
}
    