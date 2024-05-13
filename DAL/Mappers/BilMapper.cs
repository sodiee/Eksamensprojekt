using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Mappers
{
    internal class BilMapper
    {
        public static DTO.Model.Bil Map(Bil bil)
        {
            return new DTO.Model.Bil(
                            new DTO.Model.Gæst(bil.FørerAfBil.Navn, bil.FørerAfBil.Køn, bil.FørerAfBil.Alder, bil.FørerAfBil.Fødselsdag),
                            bil.AntalGæster,
                            bil.Navn,
                            bil.Model,
                            bil.Nummerplade
                        );
        }

        public static Bil Map(DTO.Model.Bil bil)
        {
            return new Bil(
                new Gæst(bil.FørerAfBil.Navn, bil.FørerAfBil.Køn, bil.FørerAfBil.Alder, bil.FørerAfBil.Fødselsdag),
                bil.AntalGæster,
                bil.Navn,
                bil.Model,
                bil.Nummerplade
                );
        }
    }
}
