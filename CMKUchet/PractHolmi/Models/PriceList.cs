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
    
    public partial class PriceList
    {
        public int id { get; set; }
        public string ed_izmer { get; set; }
        public int price { get; set; }
        public int idNomencl { get; set; }
    
        public virtual Nomenclature Nomenclature { get; set; }
    }
}