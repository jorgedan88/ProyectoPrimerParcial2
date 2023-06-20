using System;
using System.Collections.Generic;
using ProyectoPrimerParcial.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPrimerParcial2.ViewModels;

public class AeronaveIndexViewmodels

{
    public List<Aeronave> aeronaves {get; set; } = new List<Aeronave>();

    public String NameFilter { get; set; }
    
        public int AeronaveId { get; set; }
        [Display(Name = "Fecha de fabricacion")]
        public DateTime FechaFabricacion {get;set;}

        [Required(ErrorMessage ="Debe ingresar el tipo de aeronave")]
        [Display(Name = "Tipo de aeronave")]
        public string? TipoAeronave {get; set;}

}
