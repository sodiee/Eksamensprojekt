using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    internal class Bil
    {
        private int id;
        private Gæst førerAfBil;
        private int antelGæster;
        private List<Gæst> gæster;
        private string navn;
        private string model;
        private string nummerplade;

        public int ID { get { return id; } set { } }
        public Gæst FørerAfBil { get { return førerAfBil; } set { } }
        public int AntalGæster { get { return antelGæster; } set { } }
        public List<Gæst> Gæster { get { return gæster; } set { } }
        public string Navn { get { return navn; } set { } }
        public string Model { get { return model; } set { } }
        public string Nummerplade { get { return nummerplade; } set { } }

        public Bil() { }

        public Bil(Gæst førerAfBil, int antalGæster, string navn, string model, string nummerplade)
        {
            this.førerAfBil = førerAfBil;
            this.antelGæster = antalGæster;
            this.gæster = new List<Gæst>();
            this.navn = navn;
            this.model = model;
            this.nummerplade = nummerplade;

            gæster.Add(førerAfBil);
        }
    }
}
