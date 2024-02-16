namespace Proyect_RaceTrack.ViewModels.CocheraViewModels
{
    public class CocheraEditViewModel
    {
        public int CocheraId { get; set; }
        public string? CocheraNombre { get; set; }
        public int CocheraNumero { get; set; }
        public CocheraType CocheraSector { get; set; }
        public bool CocheraAptoMantenimiento { get; set; } = true;
        public bool CocheraOficinas { get; set; } = true;

        public List<int>? PistaIds { get; set; }
    }
}