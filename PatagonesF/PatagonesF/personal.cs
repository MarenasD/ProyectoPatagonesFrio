//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatagonesF
{
    using System;
    using System.Collections.Generic;
    
    public partial class personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personal()
        {
            this.AspNetUsers = new HashSet<AspNetUsers>();
            this.registro_compra = new HashSet<registro_compra>();
            this.telefono_personal = new HashSet<telefono_personal>();
        }
    
        public int rut_personal { get; set; }
        public string nombre_completo { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string direccion_personal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_compra> registro_compra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefono_personal> telefono_personal { get; set; }
    }
}
