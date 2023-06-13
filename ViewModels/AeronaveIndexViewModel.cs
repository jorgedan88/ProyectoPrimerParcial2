using System;
using System.Collections.Generic;
using ProyectoPrimerParcial.Models;

namespace ProyectoPrimerParcial2.ViewModels;

public class AeronaveIndexViewmodels

{
    public List<Aeronave> aeronaves {get; set; } = new List<Aeronave>();

    public String NameFilter { get; set; }
    
} 