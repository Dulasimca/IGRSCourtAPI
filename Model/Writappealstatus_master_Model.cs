using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Writappealstatus_master_Model
    {
        public int writappealstatusid { get; set; }// writappealstatusid int 
        public string writappealstatusname { get; set; }//, writappealstatusname varchar(200)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; }// flag boolean

    }
}
