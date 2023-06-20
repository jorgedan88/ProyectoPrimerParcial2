using ProyectoPrimerParcial.Models;
using System.ComponentModel.DataAnnotations;
using ProyectoPrimerParcial2.Utils;

namespace ProyectoPrimerParcial.ViewModels;

public class HangarEditViewModel{ 
        public int HangarId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="Debe ingresar el nombre del Hangar")]
        public string? NombreHangar {get;set;}

        [Required(ErrorMessage ="Debe ingresar el sector")]
        [Display(Name = "Sector")]
        public HangarType Sector { get; set; }

        [Display(Name = "Taller disponible")]
        public bool AptoMantenimiento {get;set;} = true;

        [Display(Name = "Cuenta con oficinas?")]
        public bool oficinas {get;set;} = true;
        public virtual List<Aeronave> Aeronaves { get; set; }
}