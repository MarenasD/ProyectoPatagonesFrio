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
    
    public partial class registro_compra
    {
        public int id_registro_compra { get; set; }
        public int cantidad_comprada { get; set; }
        public System.DateTime fecha_comprada { get; set; }
        public string n_factura { get; set; }
        public string lote { get; set; }
        public string tipo_documento { get; set; }
        public int fk_id_producto { get; set; }
        public int fk_id_personal { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual personal personal { get; set; }
    }
}
