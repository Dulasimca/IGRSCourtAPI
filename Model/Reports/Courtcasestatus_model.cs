using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model.Reports
{
    public class Courtcasestatus_model
    {
        public string Name { get; set; }
        public int CANotFileduptoyesterday { get; set; }
        public int CANotFiledToday { get; set; }
        public int CANotFiledTotal { get; set; }
        public int CAFiledToday { get; set; }
        public int CAFiledBalance { get; set; }
        public int GPVetting { get; set; }
        public int IGRApproval { get; set; }

    }
}
