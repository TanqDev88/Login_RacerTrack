using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyect_RaceTrack.Models
{
    public class Piloto
    {
        public int PilotoId { get; set; }
        public string? PilotoNombre { get; set; }
        public string? PilotoApellido { get; set; }
        public int PilotoDni { get; set; }
        public int PilotoNumeroLicencia { get; set; }
        public DateTime PilotoExpedicion { get; set; }
        public bool PilotoPropietario { get; set; } = true;
        public int VehiculoId { get; set; }
        public virtual Vehiculo? Vehiculo { get; set; }
    }
}