using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Model
{
    public class Sro_master_Model
    {
        public int sroid { get; set; } // sroid int generated always as identity primary key 
        public string sroname { get; set; } //, sroname varchar(200)
        public int zoneid { get; set; } //, zoneid int
        public int districtid { get; set; }// , districtid int
        public DateTime createddate { get; set; } //, createddate timestamp
        public bool flag { get; set; }//, flag boolean
        public string zonename { get; set; }
        public string districtname { get; set; }
    }
}
