//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unit_TestAuth
{
    using System;
    using System.Collections.Generic;
    
    public partial class Process
    {
        public int id { get; set; }
        public System.DateTime date_creation { get; set; }
        public System.TimeSpan time_creation { get; set; }
        public System.DateTime date_closing { get; set; }
        public int Process_time { get; set; }
        public int idOrder { get; set; }
        public int idShop { get; set; }
    
        public virtual FinishedProd FinishedProd { get; set; }
        public virtual Order Order { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
