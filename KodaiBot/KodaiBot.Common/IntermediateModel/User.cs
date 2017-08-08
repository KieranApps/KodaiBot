using System;
using System.Collections;
using System.Collections.Generic;

namespace KodaiBot.Common.IntermediateModel
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        
        public IEnumerable<Alias> Aliases { get; set; }
        public IEnumerable<Guid> Guids { get; set; }
    }
}
