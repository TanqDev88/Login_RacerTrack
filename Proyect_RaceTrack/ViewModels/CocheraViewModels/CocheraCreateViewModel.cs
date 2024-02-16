using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyect_RaceTrack.ViewModels.CocheraViewModels
{
    public class CocheraCreateViewModel
    {
        public int CocheraId { get; set; }

        [Display(Name = "Nombre de la Cochera")]
        [Required(ErrorMessage = "Debe ingresar el nombre de la cochera")]
        public string? CocheraNombre { get; set; }

        [Display(Name = "Numero de Cochera")]
        [Required(ErrorMessage = "El numero de cochera es obligatorio")]
        public int CocheraNumero { get; set; }

        [Display(Name = "Sector")]
        public CocheraType CocheraSector { get; set; }

        [Display(Name = "Cuenta con taller?")]
        public bool CocheraAptoMantenimiento { get; set; } = true;

        [Display(Name = "Cuenta con oficinas?")]
        public bool CocheraOficinas { get; set; } = true;

        [Display(Name = "Pistas")]
        [Required(ErrorMessage = "Debe seleccionar al menos una pista")]
        public List<int>? PistaIds { get; set; }
    }
}