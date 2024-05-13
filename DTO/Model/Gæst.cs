using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Gæst
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Køn { get; set; }
        public int Alder { get; set; }
        public DateTime Fødselsdag { get; set; }

        public Gæst() { }

        public Gæst(string navn, string køn, int alder, DateTime fødselsdag)
        {
            this.Navn = navn;
            this.Køn = køn;
            this.Alder = alder;
            this.Fødselsdag = fødselsdag;
        }

        public Gæst(int id, string navn, string køn, int alder, DateTime fødselsdag)
        {
            this.ID = id;
            this.Navn = navn;
            this.Køn = køn;
            this.Alder = alder;
            this.Fødselsdag = fødselsdag;
        }
    }
}

