using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Casestatus_master_Model
    {
        public int casestatusid { get; set; }//       casestatusid int generated always as identity primary key 
        public string casestatusname { get; set; }//    , casestatusname varchar(500)
        public DateTime? createddate { get; set; }//    , createddate timestamp
        public bool flag { get; set; } // , flag boolean

    }
}
