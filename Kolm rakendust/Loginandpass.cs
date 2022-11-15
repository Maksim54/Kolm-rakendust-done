using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kolm_rakendust
{
    public class Loginandpass
    {
        public int Id { get; set; }
        public string kasutajanimi { get; set; }
        public string email { get; set; }
        public string sugu { get; set; }
        public int vanus { get; set; }
        public string password { get; set; }

    }

}
