using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int State { get; set; }
    }
}
