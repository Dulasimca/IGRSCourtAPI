using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Usermaster_Model
    {
        public int userid { get; set; }  
        public string username { get; set; }  
        public string? mailid { get; set; }  
        public string password { get; set; }  
        public string? mobile { get; set; }  
        public int? zoneid { get; set; }  
        public int? districtid { get; set; }  
        public int? sroid { get; set; }  
        public int roleid { get; set; }  
        public DateTime createddate { get; set; }  
        public bool flag { get; set; }
        public string zonename { get; set; }
        public string districtname { get; set; }
        public string sroname { get; set; }
        public string rolename { get; set; }







    }
}
