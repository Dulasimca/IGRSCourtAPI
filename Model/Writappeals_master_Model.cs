using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IGRSCourtAPI.Model

{
    public class Writappeals_master_Model
    {
           public int writappealsid { get; set; }
           public int zoneid { get; set; }
           public int districtid { get; set; }
           public int sroid { get; set; }
           public int courtcaseid { get; set; }
           public string regularnumber { get; set; }
           public string natureofdisposal { get; set; }
           public string writ_remarks { get; set; }
           public DateTime? createddate { get; set; }
           public bool flag { get; set; }

        public int casetypeid { get; set; }// casetypeid int  
        public string casenumber { get; set; }// casenumber varchar(100)
        public int caseyear { get; set; }// caseyear int
        public int courtid { get; set; } // courtid int  
        public string petitionername { get; set; } //petitionername varchar(200)
        public string mainrespondents { get; set; } //, mainrespondents varchar(3000)
        public string mainprayer { get; set; }//, mainprayer varchar(2000)
        public bool counterfiled { get; set; } //, counterfiled boolean
        public int casestatusid { get; set; }//, casestatusid       int 
        public int responsetypeid { get; set; } //    , responsetypeid int
        public DateTime casedate { get; set; } //, casedate date
        public DateTime? createdate { get; set; } //createdate     timestamp
        public int userid { get; set; }
        public string zonename { get; set; }
        public string districtname { get; set; }
        public string sroname { get; set; }
        public string casetypename { get; set; }
        public string courtname { get; set; }
        public string casestatusname { get; set; }

    }

  
}
