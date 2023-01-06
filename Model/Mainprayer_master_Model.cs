using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Mainprayer_master_Model
    {
        public int mainprayerid { get; set; }
        public string mainprayerdesc { get; set; }
        public DateTime createddate { get; set; }
        public bool flag { get; set; }
    }
}
