using laba1;
using System;
using System.Collections.Generic;
using System.Text;

namespace model.Entities
{
    public abstract class IEntities : IDomainObject
    {
        public String Name { get; set; }
        public int Id { get; set; }
    }
}
