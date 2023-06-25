using ProyectoPrimerParcial.Utils;

namespace ProyectoPrimerParcial.Models
{
    public class Hangar{
        public int HangarId { get; set; }
        public string? NombreHangar {get;set;}
        public HangarType Sector { get; set; }
        public bool AptoMantenimiento {get;set;} = true;
        public bool oficinas {get;set;} = true;
        public virtual List<Aeronave>? Aeronaves { get; set; }

    }
}
