using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDAODate { get; set; }
    }
}