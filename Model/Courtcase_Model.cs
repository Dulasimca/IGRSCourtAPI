﻿using System;
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
        public string mainprayer { get; set; }//, mainprayer varchar(2000)
        public bool counterfiled { get; set; } //, counterfiled boolean
        public int casestatusid { get; set; }//, casestatusid       int 
        public string remarks { get; set; } // , remarks varchar(1000)
        public int responsetypeid { get; set; } //    , responsetypeid int
        public DateTime casedate { get; set; } //, casedate date
        public DateTime? createdate { get; set; } //createdate     timestamp
        public bool flag { get; set; } // ,flag boolean

    }
}
