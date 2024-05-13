using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Færge
    {
        private int id;
        private int længde;
        private int maxAntalGæster;
        private int maxAntalBiler;

        public int ID { get { return id; } set { } }
        public int Længde { get; set; }
        public int MaxAntalGæster { get; set; }
        public int MaxAntalBiler { get; set; }

        public Færge() { }

        public Færge(int længde, int maxAntalGæster, int maxAntalBiler)
        {
            this.længde = længde;
            this.maxAntalGæster = maxAntalGæster;
            this.maxAntalBiler = maxAntalBiler;
        }
    }
}
