using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Role_master_model
    {
        public int roleid { get; set; } //roleid int generated always as identity primary key 
        public string rolename { get; set; }//, districtname varchar(200)
        public bool flag { get; set; } // , flag boolean
    }
}
