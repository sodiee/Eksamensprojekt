using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Bil
    {
        private List<Gæst> gæster;
        public int ID { get; set; }
        public Gæst FørerAfBil { get; set; }
        public int AntalGæster { get; set; }
        public List<Gæst> Gæster { get { return gæster; } set { } }
        public string Navn { get; set; }
        public string Model { get; set; }
        public string Nummerplade { get; set; }

        public Bil() { }

        public Bil(Gæst førerAfBil, int antalGæster, string navn, string model, string nummerplade)
        {
            this.FørerAfBil = førerAfBil;
            this.AntalGæster = antalGæster;
            this.gæster = new List<Gæst>();
            this.Navn = navn;
            this.Model = model;
            this.Nummerplade = nummerplade;

            gæster.Add(førerAfBil);
        }

        public Bil(int id, Gæst førerAfBil, int antalGæster, string navn, string model, string nummerplade)
        {
            this.ID = id;
            this.FørerAfBil = førerAfBil;
            this.AntalGæster = antalGæster;
            this.gæster = new List<Gæst>();
            this.Navn = navn;
            this.Model = model;
            this.Nummerplade = nummerplade;

            gæster.Add(førerAfBil);
        }
    }
}
