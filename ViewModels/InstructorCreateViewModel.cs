using ProyectoPrimerParcial.Models;
using System.ComponentModel.DataAnnotations;
using ProyectoPrimerParcial.Utils;

namespace ProyectoPrimerParcial.ViewModels;

public class InstructorCreateViewModel{
        public int InstructorId { get; set; }

        [Required(ErrorMessage ="Debe ingresar el Nombre del instructor")]
        [Display(Name = "Nombre")]


        public string? NombreInstructor {get; set;}

        [Required(ErrorMessage ="Debe ingresar el Apellido del instructor")]
        [Display(Name = "Apellido")]
        public string? Apellido {get; set;}


        [Required(ErrorMessage ="Debe ingresar el DNI del instructor")]
        [Display(Name = "DNI")]
        public int DNI {get; set;}

        [Required(ErrorMessage ="Debe ingresar el tipo de licencia")]
        [Display(Name = "Tipo de licencia")]
        public LicenciaType TipoLicencia { get; set; }

        [Required(ErrorMessage ="Debe ingresar el numero de la licencia")]
        [Display(Name = "Numero")]
        public int NumeroLicencia {get; set;}

        [Display(Name = "Fecha expedicion")]
        public DateTime FechaExpedicion {get;set;}

        [Display(Name = "En actividad")]
        public bool EnActividad {get;set;} = true;

        [Display(Name = "Aeronave")]
        public int AeronaveId { get; set; }
        public virtual Aeronave? Aeronave { get; set; }

}