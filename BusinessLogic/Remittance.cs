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
    
    public partial class Remittance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Remittance()
        {
            this.Funds = new HashSet<Funds>();
            this.Remittance_state_log = new HashSet<Remittance_state_log>();
        }
    
        public System.Guid Remittance_Id { get; set; }
        public string Code { get; set; }
        public int c_status_id { get; set; }
        public int Sender_id { get; set; }
        public int Receiver_id { get; set; }
    
        public virtual c_status c_status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funds> Funds { get; set; }
        public virtual person person { get; set; }
        public virtual person person1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Remittance_state_log> Remittance_state_log { get; set; }
    }
}
