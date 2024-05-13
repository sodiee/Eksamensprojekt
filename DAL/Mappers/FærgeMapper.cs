using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class FærgeMapper
    {
        public static DTO.Model.Færge Map(Færge færge)
        {
            List<DTO.Model.Gæst> færgeGæster = new List<DTO.Model.Gæst>();

            foreach (var DALgæst in færge.Gæster)
            {
                færgeGæster.Add(new DTO.Model.Gæst(DALgæst.Navn, DALgæst.Køn, DALgæst.Alder, DALgæst.Fødselsdag));
            }

            return new DTO.Model.Færge(
                            færge.Navn,
                            færge.Længde,
                            færge.MaxAntalGæster,
                            færge.MaxAntalBiler,
                            færgeGæster
                        );
        }

        public static Færge Map(DTO.Model.Færge færge)
        {
            List<Gæst> færgeGæster = new List<Gæst>();

            foreach (var DTOgæst in færge.Gæster)
            {
                færgeGæster.Add(new Gæst(DTOgæst.Navn, DTOgæst.Køn, DTOgæst.Alder, DTOgæst.Fødselsdag));
            }

            return new Færge(
                            færge.Navn,
                            færge.Længde,
                            færge.MaxAntalGæster,
                            færge.MaxAntalBiler,
                            færgeGæster
                        );
        }
    }
}
