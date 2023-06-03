using System;
using System.Collections.Generic;
using ProyectoPrimerParcial.Models;

namespace ProyectoPrimerParcial2.ViewModels;

public class InstructorViewmodels

{
    public List<Instructor> instructors {get; set; } = new List<Instructor>();

    public String NameFilterIns { get; set; }
    
} 