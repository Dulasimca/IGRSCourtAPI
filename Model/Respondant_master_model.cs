using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Respondant_master_model
    {
        public int respondentsid { get; set; } //respondentsid int generated always as identity primary key 
        public string respondentsname { get; set; }//, respondentsname varchar(200)
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
    }
}
