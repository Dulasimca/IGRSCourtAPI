using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Case_hearing_model
    {
        public int casehearingid { get; set; }
        public int zoneid { get; set; }// zoneid int 
        public int districtid { get; set; }
        public int sroid { get; set; }
        public int casetypeid { get; set; }
        public int courtcaseid { get; set; }
        public string remarks { get; set; }//, zonename varchar(200)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public DateTime hearingdate { get; set; } //, casedate date
        public bool flag { get; set; }// flag boolean
        public int userid { get; set; }
        public string zonename { get; set; }
        public string districtname { get; set; }

        public string sroname { get; set; }
        public string casetypename { get; set; }




    }
}
