using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Slp_master_model
    {
        public int slpid { get; set; } //slpid int generated always as identity primary key 
        public string name { get; set; }//, districtname varchar(200)
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
    }
}
