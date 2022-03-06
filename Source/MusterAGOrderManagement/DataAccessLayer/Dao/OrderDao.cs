using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class OrderDao : BaseDao
    {
        public DateTime Ordered { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDao Customer { get; set; }
        public virtual ICollection<PositionDao> Positions { get; set; }
    }
}
