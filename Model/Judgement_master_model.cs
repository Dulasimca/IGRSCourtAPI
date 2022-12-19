using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Judgement_master_model
    {
        public int judgementid { get; set; } //judgementid int generated always as identity primary key 
        public string judgementname { get; set; } //judgementname string
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
    }
}
