using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Court_master_Model
    {
        public int courtid { get; set; }// courtid int generated always as identity primary key 
        public string courtname { get; set; }//, courtname varchar(500)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; }// , flag boolean
    }
}
