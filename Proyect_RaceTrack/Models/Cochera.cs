using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyect_RaceTrack.Models
{
    public class Cochera
    {
        public int CocheraId { get; set; }
        [Display(Name = "Nombre")]
        public string? CocheraNombre { get; set; }
        [Display(Name = "Numero")]
        public int CocheraNumero { get; set; }
        [Display(Name = "Sector")]
        public CocheraType CocheraSector { get; set; }
        [Display(Name = "Mantenimiento")]
        public bool CocheraAptoMantenimiento { get; set; } = true;
        [Display(Name = "Oficinas")]
        public bool CocheraOficinas { get; set; } = true;
        public virtual List<Pista>? Pistas { get; set; }
        
    }
}