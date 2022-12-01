using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Zone_master_Model
    {
        public int zoneid { get; set; }// zoneid int 
        public string zonename { get; set; }//, zonename varchar(200)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; }// flag boolean

    }
}
