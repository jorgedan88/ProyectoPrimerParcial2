namespace ProyectoPrimerParcial.Models
{
    public class Aeronave
    {
        public int AeronaveId { get; set; }
        public DateTime FechaFabricacion {get;set;}
        public string? TipoAeronave {get; set;}
        public ICollection<Instructor> InstructorList { get; set; } = new List<Instructor>();
        public virtual List<Hangar>? Hangars { get; set; }

    }
}
