using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPilote.Models
{
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Pays { get; set; }
        public string Poste { get; set; }
    }
}
