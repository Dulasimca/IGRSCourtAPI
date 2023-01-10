using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IGRSCourtAPI.Model
{
    public class Courtcase_Model
    {
        public int courtcaseid { get; set; } //        courtcaseid int generated always as identity primary key
        public int zoneid { get; set; }// zoneid int 
        public int districtid { get; set; }// districtid int  
        public int sroid { get; set; } // sroid int
        public int casetypeid { get; set; }// casetypeid int  
        public string casenumber { get; set; }// casenumber varchar(100)
        public int caseyear { get; set; }// caseyear int
        public int courtid { get; set; } // courtid int  
        public string petitionername { get; set; } //petitionername varchar(200)
        public string mainrespondents { get; set; } //, mainrespondents varchar(3000)
        public string gistofcase { get; set; }//, mainprayer varchar(2000)
        public int counterfiledid { get; set; }
        public int casestatusid { get; set; }//, casestatusid       int 
        public int responsetypeid { get; set; } //    , responsetypeid int
        public string mainrespondentsid { get; set; }
        public int mainprayerid { get; set; } //    , mainprayerid int
       // public DateTime casedate { get; set; } //, casedate date
        public DateTime? createdate { get; set; } //createdate     timestamp
        public bool flag { get; set; } // ,flag boolean
        public int userid { get; set; }
        public string zonename { get; set; }
        public string districtname { get; set; }
        public string sroname { get; set; }
        public string casetypename { get; set; }
        public string courtname { get; set; }
        public string casestatusname { get; set; }
        public string responsetypename { get; set; }
       // public int judgementid { get; set; }
       // public string judgementname { get; set; }
        public string counterfiledname { get; set; }
        public string mainprayername { get; set; }
        // public string respondentsname { get; set; }
        public List<LinkedCase_Model> linkedCase
    }
}
