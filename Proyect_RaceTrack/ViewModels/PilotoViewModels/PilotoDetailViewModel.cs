using Proyect_RaceTrack.Models;
using System.ComponentModel.DataAnnotations;

namespace Proyect_RaceTrack.ViewModels.PilotoViewModels
{
    public class PilotoDetailViewModel
    {
        public List<Piloto> pilotos { get; set; } = new List<Piloto>();
        public String? NameFilter { get; set; }
        public int PilotoId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre del piloto")]
        [MinLength(3, ErrorMessage = "El nombre ingresado debe poseer mas de tres letras")]
        [MaxLength(15)]
        public string? PilotoNombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Debe ingresar el apellido del piloto")]
        [MinLength(3, ErrorMessage = "El nombre ingresado debe poseer mas de tres letras")]
        [MaxLength(15)]
        public string? PilotoApellido { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Debe ingresar el DNI del piloto")]
        [Range(11111, 99999999, ErrorMessage = "El DNI debe ser un valor entre 10000000 y 99999999")]
        public int PilotoDni { get; set; }

        [Display(Name = "Numero registro")]
        [Required(ErrorMessage = "Debe ingresar el numero de registro")]
        [Range(10000, 99999, ErrorMessage = "El Registro debe ser un valor entre 10000 y 99999")]
        public int PilotoNumeroLicencia { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [Required(ErrorMessage = "Debe ingresar la fecha de vencimiento")]
        public DateTime PilotoExpedicion { get; set; }

        [Display(Name = "Es propietario?")]
        public bool PilotoPropietario { get; set; } = true;

        [Display(Name = "Tipo de carrocería")]
        public int VehiculoId { get; set; }
        public virtual Vehiculo? Vehiculo { get; set; }
    }
}