using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyect_RaceTrack.Models;

namespace Proyect_RaceTrack.ViewModels.CocheraViewModels
{
    public class CocheraDetailViewModel
    {
        public int CocheraId { get; set; }
        public string? CocheraNombre { get; set; }
        public int CocheraNumero { get; set; }
        public CocheraType CocheraSector { get; set; }
        public bool CocheraAptoMantenimiento { get; set; } = true;
        public bool CocheraOficinas { get; set; } = true;
        public int PistaId {get; set;}
        public virtual List<Pista>? Pistas { get; set; }
    }
}