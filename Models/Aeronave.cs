using System.ComponentModel.DataAnnotations;

namespace ProyectoPrimerParcial.Models
{
    public class Aeronave
    {
        public int AeronaveId { get; set; }

        [Display(Name = "Fecha de fabricacion")]        
        public DateTime FechaFabricacion {get;set;}

        [Required(ErrorMessage ="Debe ingresar el tipo de aeronave")]
        [Display(Name = "Tipo de aeronave")]
        public string? TipoAeronave {get; set;}
        public ICollection<Instructor> InstructorList { get; set; } = new List<Instructor>();
    }
}
