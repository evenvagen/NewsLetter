using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Core
{
    class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity(Guid id)
        {
            Id = Guid.NewGuid();
        }
    }
}
