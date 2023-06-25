using ProyectoPrimerParcial.Utils;

namespace ProyectoPrimerParcial.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string? NombreInstructor {get; set;}
        public string? Apellido {get; set;}
        public int DNI {get; set;}
        public LicenciaType TipoLicencia { get; set; }
        public int NumeroLicencia {get; set;}
        public DateTime FechaExpedicion {get;set;}
        public bool EnActividad {get;set;} = true;
        public int AeronaveId { get; set; }
        public virtual Aeronave? Aeronave { get; set; }
        
    }
}