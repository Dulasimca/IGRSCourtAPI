using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Responsetype_master_Model
    {
        public int responsetypeid { get; set; }//        responsetypeid int generated always as identity primary key 
        public string responsetypename { get; set; } //    ,responsetypename varchar(500)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } //, flag boolean

    }
}
