﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Dao
{
    public class CustomerDao : BaseDao
    {
        public string CustomerNr { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Password { get; set; }
        public int AddressId { get; set; }
        public virtual AddressDao Address { get; set; }
    }
}
