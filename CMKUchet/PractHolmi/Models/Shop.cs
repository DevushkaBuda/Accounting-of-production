//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProkatHolm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop()
        {
            this.Process = new HashSet<Process>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int idMaterial { get; set; }
    
        public virtual Material Material { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Process> Process { get; set; }
    }
}