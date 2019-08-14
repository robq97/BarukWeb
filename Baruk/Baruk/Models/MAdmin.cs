using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baruk.Models
{
    class MAdmin
    {
        //Get y Set de los atributos
        public int PersonID { get; set; } 
        public int AdminID { get; set; }
        public string UsuarioEspecial { get; set; }
        public string PasswrdEspecial { get; set; }
    }
}