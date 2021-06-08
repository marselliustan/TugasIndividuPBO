using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SewaMobil
{
    class MobilModel:DbContext
    {
        public MobilModel(): base()
        {

        }
        public virtual DbSet<Mobil> Mobils { get; set; }
    }
}
