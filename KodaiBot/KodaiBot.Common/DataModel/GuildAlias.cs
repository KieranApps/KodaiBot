//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KodaiBot.Common.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class GuildAlias
    {
        public System.Guid Id { get; set; }
        public System.Guid GuildId { get; set; }
        public System.Guid AliasId { get; set; }
    
        public virtual Alias Alias { get; set; }
        public virtual Guild Guild { get; set; }
    }
}
