using Proyect_RaceTrack.Models;
using System.ComponentModel.DataAnnotations;
using Proyect_RaceTrack.Utils;

namespace Proyect_RaceTrack.ViewModels.PistaViewModels;

public class PistaDetailViewModel{

        public int PistaId { get; set; }
        [Display(Name = "Nombre")]
        public string? PistaNombre {get;set;}
        [Display(Name = "Pista codigo")]
        public int PistaCodigo { get; set; }

        [Display(Name = "Material")]
        public PistaType PistaMaterial { get; set; }
        [Display(Name = "Iluminacion")]
        public bool PistaIluminacion {get;set;} = true;
        [Display(Name = "Aprovisionamiento")]
        public bool PistaAprovisionamiento {get;set;} = true;

        public int CocheraId {get; set;}
        public List<Cochera>? Cocheras {get;set;}

}
