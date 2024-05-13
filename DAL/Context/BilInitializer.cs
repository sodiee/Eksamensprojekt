using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class BilInitializer : DropCreateDatabaseIfModelChanges<BilContext> //createdatabaseifnotexists<bilmodel>
    {
        protected override void Seed(BilContext context)
        {
            Bil bil = new Bil(null, 0, "Mazda", "3", "AM12345");
            context.Biler.Add(bil);

            context.Biler.Add(new BilModel(-1, "Ford", "Ka"));
            context.SaveChanges();
        }
    }
}
