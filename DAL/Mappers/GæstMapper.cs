using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class GæstMapper
    {
        public static DTO.Model.Gæst Map(Gæst gæst)
        {
            return new DTO.Model.Gæst(
                            gæst.Navn,
                            gæst.Køn,
                            gæst.Alder,
                            gæst.Fødselsdag
                        );
        }

        public static Gæst Map(DTO.Model.Gæst gæst)
        {
            return new Gæst(
                            gæst.Navn,
                            gæst.Køn,
                            gæst.Alder,
                            gæst.Fødselsdag
                        );
        }
    }
}
