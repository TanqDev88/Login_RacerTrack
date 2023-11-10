using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyect_RaceTrack.Utils;

namespace Proyect_RaceTrack.Models
{
    public class Pista
    {
        public int PistaId { get; set; }
        public string? PistaNombre { get; set; }
        public int PistaCodigo { get; set; }
        public PistaType PistaMaterial { get; set; }
        public bool PistaIluminacion { get; set; } = true;
        public bool PistaAprovisionamiento { get; set; } = true;
        public virtual List<Cochera> Cocheras { get; set; }
        

    }
}