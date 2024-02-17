using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyect_RaceTrack.Utils;
using System.ComponentModel.DataAnnotations;

namespace Proyect_RaceTrack.Models
{
    public class Pista
    {
        public int PistaId { get; set; }
        [Display(Name = "Nombre")]
        public string? PistaNombre { get; set; }
        [Display(Name = "Codigo")]
        public int PistaCodigo { get; set; }
        [Display(Name = "Material")]
        public PistaType PistaMaterial { get; set; }
        [Display(Name = "Iluminacion")]
        public bool PistaIluminacion { get; set; } = true;
        [Display(Name = "Aprovisionamiento")]
        public bool PistaAprovisionamiento { get; set; } = true;
        public virtual List<Cochera> Cocheras { get; set; }
        

    }
}