using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Gæst
    {
        private int id;
        private string navn;
        private string køn;
        private int alder;
        private DateTime fødselsdag;

        public int ID { get { return id; } set { } }
        public string Navn;
        public string Køn;
        public int Alder;
        public DateTime Fødselsdag;

        public Gæst() { }

        public Gæst(string navn, string køn, int alder, DateTime fødselsdag)
        {
            this.navn = navn;
            this.køn = køn;
            this.alder = alder;
            this.fødselsdag = fødselsdag;
        }
    }
}
