using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class Initializer : DropCreateDatabaseIfModelChanges<FærgeContext> //createdatabaseifnotexists<bilmodel>
    {
        protected override void Seed(FærgeContext context)
        {
            context.Biler.Add(new Bil(null, 0, "Mazda", "3", "AM12345"));
            context.Gæster.Add(new Gæst("Mathias", "Dreng", 23, new DateTime(2001, 2, 17)));
            context.Færger.Add(new Færge("Morslinjen", 40, 100, 40, new List<Gæst>()));

            context.SaveChanges();
        }
    }
}
