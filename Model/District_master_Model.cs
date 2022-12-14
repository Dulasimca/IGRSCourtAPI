using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class District_master_Model
    {
        public int districtid { get; set; } //districtid int generated always as identity primary key 
        public string districtname { get; set; }//, districtname varchar(200)
        public int zoneid { get; set; }//, zoneid int
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
        public string zonename { get; set; }
    }
}
