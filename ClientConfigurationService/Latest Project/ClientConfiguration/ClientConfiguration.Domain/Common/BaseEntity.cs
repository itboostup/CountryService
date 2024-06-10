using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConfiguration.Domain
{
    public class BaseEntity
    {
        //Auditfileds
        public int CreatedOn { get; set; }
        public int UpdatedOn { get; set;}
        public int CreatedBy { get; set;}
        public int UpdatedBy { get; set;}
        public bool isActive { get; set; }
    }
}
