using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaMobil
{
    class User
    {
        string nama;
        string noTelp;
        string noKtp;
        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }
        public string NoTelp
        {
            get { return noTelp; }
            set { noTelp = value; }
        }
        public string NoKtp
        {
            get { return noKtp; }
            set { noKtp = value; }
        }
    }
}
