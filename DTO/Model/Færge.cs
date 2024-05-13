using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Færge
    {
        private List<Gæst> gæster;
        public int ID { get; set; }
        public string Navn { get; set; }
        public int Længde { get; set; }
        public int MaxAntalGæster { get; set; }
        public int MaxAntalBiler { get; set; }
        public List<Gæst> Gæster { get { return gæster; } set { } }

        public Færge() { }

        public Færge(string navn, int længde, int maxAntalGæster, int maxAntalBiler, List<Gæst> gæster)
        {
            this.Navn = navn;
            this.Længde = længde;
            this.MaxAntalGæster = maxAntalGæster;
            this.MaxAntalBiler = maxAntalBiler;

            this.gæster = gæster;
        }

        public Færge(int id, string navn, int længde, int maxAntalGæster, int maxAntalBiler, List<Gæst> gæster)
        {
            this.ID = id;
            this.Navn = navn;
            this.Længde = længde;
            this.MaxAntalGæster = maxAntalGæster;
            this.MaxAntalBiler = maxAntalBiler;

            this.gæster = gæster;
        }
    }
}
