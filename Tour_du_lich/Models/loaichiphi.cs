//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tour_du_lich.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class loaichiphi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loaichiphi()
        {
            this.chiphis = new HashSet<chiphi>();
        }
    
        public string maloaichiphi { get; set; }
        public string tenloaichiphi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chiphi> chiphis { get; set; }
    }
}
