using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Casetype_master_Model
    {
        public int casetypeid { get; set; }//   casetypeid int generated always as identity primary key 
        public string casetypename { get; set; } // , casetypename varchar(500)
        public DateTime? createddate { get; set; } //    , createddate timestamp
        public bool flag { get; set; } //, flag boolean

    }
}
