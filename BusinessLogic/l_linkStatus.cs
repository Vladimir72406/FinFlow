//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class l_linkStatus
    {
        public int l_linkStatus1 { get; set; }
        public int c_status_id_current { get; set; }
        public int c_status_id_new { get; set; }
    
        public virtual c_status c_status { get; set; }
        public virtual c_status c_status1 { get; set; }
    }
}
