using System;
using System.Collections.Generic;
using ProyectoPrimerParcial.Models;

namespace ProyectoPrimerParcial2.ViewModels;

public class HangarViewmodels

{
    public List<Hangar> hangars {get; set; } = new List<Hangar>();

    public String NameFilterHan { get; set; }
    
} 