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
    
    public partial class RodzicPracownika
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RodzicPracownika()
        {
            this.Pracownik = new HashSet<Pracownik>();
        }
    
        public int IdRodzicaPracownika { get; set; }
        public string ImieOjca { get; set; }
        public string ImieMatki { get; set; }
        public string NazwiskoRodowe { get; set; }
        public string NazwiskoRodoweMatki { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}