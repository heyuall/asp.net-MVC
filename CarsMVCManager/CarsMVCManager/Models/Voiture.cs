//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarsMVCManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Voiture
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int PFiscale { get; set; }
        public EnumMarque Marque { get; set; }
        public EnumModele Modele { get; set; }
        public EnumCarburant Carburant { get; set; }
        public string Matricule { get; set; }
        public string Couleur { get; set; }
        public int ProprietaireId { get; set; }
    
        public virtual Proprietaire Proprietaire { get; set; }
    }
}
