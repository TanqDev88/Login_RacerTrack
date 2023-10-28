using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyect_RaceTrack.Models;

namespace Proyect_RaceTrack.ViewModels.CocheraViewModels
{
    public class CocheraIndexViewModel
    {

        //public List<Cochera> cocheras { get; set; } = new List<Cochera>();
        public List<Cochera> cocheras {get; set;} = new List<Cochera>();
        public String? NameFilterHan { get; set; }
        public int CocheraId { get; set; }
        public string? CocheraNombre { get; set; }
        public int CocheraNumero { get; set; }
        public CocheraType CocheraSector { get; set; }
        public bool CocheraAptoMantenimiento { get; set; } = true;
        public bool CocheraOficinas { get; set; } = true;
        //public virtual List<Pista> Pistas { get; set; }
    }
}