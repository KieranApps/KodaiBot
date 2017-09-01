using System;
using System.Collections.Generic;

namespace KodaiBot.Common.IntermediateModel
{
    public class Guild
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }

        public IEnumerable<Alias> Aliases { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
