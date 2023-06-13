using ProyectoPrimerParcial.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPrimerParcial.ViewModels;

public class AeronaveDetailViewModel{ 

        [Display(Name = "Fecha de fabricacion")]
        public DateTime FechaFabricacion {get;set;}

        [Required(ErrorMessage ="Debe ingresar el tipo de aeronave")]
        [Display(Name = "Tipo de aeronave")]
        public string? TipoAeronave {get; set;}

}