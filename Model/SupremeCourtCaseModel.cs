using System;

namespace IGRSCourtAPI.Model
{
    public class SupremeCourtCaseModel
    {
        public int courtcaseid { get; set; }
        public int zoneid { get; set; }
        public int districtid { get; set; }
        public int sroid { get; set; }
        public int slptypeid { get; set; }
        public string petitionername { get; set; }
        public string mainrespondents { get; set; }
        public string mainprayer { get; set; }
        public bool counterfiled { get; set; }
        public bool casefiledby { get; set; }
        public int casestatusid { get; set; }
        public string slpcaseno { get; set; }
        public string highcourtrefno { get; set; }
        public DateTime casedate { get; set; }
        public DateTime? createdate { get; set; }
        public bool flag { get; set; }
        public int userid { get; set; }
        public string remarks { get; set; }
        public string zonename { get; set; }
        public string districtname { get; set; }
        public string sroname { get; set; }
        public string slptypename { get; set; }
        public string casestatusname { get; set; }
    }
}
