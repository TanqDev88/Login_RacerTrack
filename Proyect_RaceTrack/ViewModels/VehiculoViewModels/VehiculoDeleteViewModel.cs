using System.ComponentModel.DataAnnotations;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.Utils;

namespace Proyect_RaceTrack.ViewModels.VehiculoViewModels
{
    public class VehiculoDeleteViewModel
    {
        public int VehiculoId { get; set; }
        public List<Vehiculo> vehiculos { get; set; } = new List<Vehiculo>();

        public String? NameFilter { get; set; }

        [Display(Name = "Nombre Propietario")]
        [Required(ErrorMessage = "Debe ingresar el nombre del propietario")]
        [MinLength(3, ErrorMessage = "El nombre ingresado debe poseer mas de tres letras")]
        [MaxLength(15)]
        public string? VehiculoNombre { get; set; }

        [Display(Name = "Apellido Propietario")]
        [Required(ErrorMessage = "Debe ingresar el apellido del propietario")]
        [MinLength(3, ErrorMessage = "El nombre ingresado debe poseer mas de tres letras")]
        [MaxLength(15)]
        public string? VehiculoApellido { get; set; }

        [Display(Name = "Tipo de Carroceria")]
        [Required(ErrorMessage = "Debe ingresar el tipo de vehiculo")]
        [MinLength(3, ErrorMessage = "El nombre ingresado debe poseer mas de tres letras")]
        [MaxLength(15)]
        public VehiculoType VehiculoTipo { get; set; }

        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "Debe ingresar el numero de matricula")]
        [MinLength(6, ErrorMessage = "La matricula debe contener al menos 6 caracteres")]
        [MaxLength(7)]
        public string? VehiculoMatricula { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Debe ingresar el año de fabricacion")]

        public DateTime VehiculoFabricacion { get; set; }
        public ICollection<Piloto> PilotoList { get; set; } = new List<Piloto>();
    }
}