using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class AddressDao : BaseDao
    {
        public string Street { get; set; }
        public int TownId { get; set; }
        public virtual TownDao Town { get; set; }
        public virtual ICollection<CustomerDao> Customers { get; set; }
    }
}
