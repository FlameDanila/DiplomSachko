//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SachkoKursovaya
{
    using System;
    using System.Collections.Generic;
    
    public partial class Apartments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartments()
        {
            this.Owners = new HashSet<Owners>();
        }
    
        public int id { get; set; }
        public Nullable<int> RoomsCount { get; set; }
        public Nullable<int> Metro { get; set; }
        public string Adres { get; set; }
        public Nullable<int> Cost { get; set; }
        public string City { get; set; }
        public Nullable<int> LivingSpace { get; set; }
        public Nullable<int> TotalSpace { get; set; }
        public Nullable<int> Floor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Owners> Owners { get; set; }
    }
}