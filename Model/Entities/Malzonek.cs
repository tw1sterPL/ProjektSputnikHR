//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekt1.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Malzonek
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Malzonek()
        {
            this.Pracownik = new HashSet<Pracownik>();
        }
    
        public int IdMalzonek { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public System.DateTime DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public string NIP { get; set; }
        public string DowodOsobisty { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}
