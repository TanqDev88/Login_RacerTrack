using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyect_RaceTrack.Models;
using System.ComponentModel.DataAnnotations;
using Proyect_RaceTrack.Utils;

//namespace Proyect_RaceTrack.ViewModels.PistaViewModels{
namespace Proyect_RaceTrack.ViewModels.PistaViewModels
{

        public class PistaIndexViewModel
        {
        public List<Pista> pistas {get; set; } = new List<Pista>();
        public String? NameFilterPista { get; set; }
        public int PistaId { get; set; }
        [Display(Name = "Nombre")]
        public string? PistaNombre {get;set;}
        [Display(Name = "Nomenclatura")]
        public int PistaCodigo { get; set; }
        public PistaType PistaMaterial { get; set; }
        [Display(Name = "Iluminacion")]
        public bool PistaIluminacion {get;set;} = true;
        [Display(Name = "Aprovisionamiento")]
        public bool PistaAprovisionamiento {get;set;} = true;
        //        [Display(Name = "Tipo de aeronave")]
        // public virtual List<Hangar> Hangars {get;set;}
}
}