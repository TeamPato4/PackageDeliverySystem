//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageDelivery.Repository.Implementation.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class vehiculo
    {
        public long id { get; set; }
        public string placa { get; set; }
        public Nullable<long> idTipoTransporte { get; set; }
    
        public virtual tipoTransporte tipoTransporte { get; set; }
    }
}
