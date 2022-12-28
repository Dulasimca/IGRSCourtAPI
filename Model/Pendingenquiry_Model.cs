using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Pendingenquiry_Model
    {
        public int pendingenquiryid { get; set; }
        public int zoneid { get; set; }
        public int districtid { get; set; }
        public int sroid { get; set; }
        public int courtcaseid { get; set; }
        public int writappealsid { get; set; }
        public string subject { get; set; }
        public string referenceno { get; set; }
        public string remarks { get; set; }
        public DateTime? createddate { get; set; }
        public bool flag { get; set; }

        public int casetypeid { get; set; }
        public int casestatusid { get; set; }
        public int writappealstatusid { get; set; }
        public string casenumber { get; set; }
        public int caseyear { get; set; }
        public int courtid { get; set; }
        public string petitionername { get; set; }
        public string mainrespondents { get; set; }
        public string mainprayer { get; set; }
        public int responsetypeid { get; set; }
        public DateTime? createdate { get; set; }
        public int userid { get; set; }
        public string zonename { get; set; }
        public string districtname { get; set; }
        public string sroname { get; set; }
        public string courtname { get; set; }
        public string casestatusname { get; set; }
        public string casetypename { get; set; }
        public string writappealstatusname { get; set; }
    }
}
