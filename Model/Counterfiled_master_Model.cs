using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Counterfiled_master_Model
    {
        public int counterfiledid { get; set; } //counterfiledid int generated always as identity primary key 
        public string counterfiledname { get; set; } //counterfiledname string
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
    }
}
