using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model.Reports
{
    public class CourtcaseCANotFiledRespondent_Model
    {
        public string Name { get; set; }
        public int GovtRespondent { get; set; }
        public int IGRRespondent { get; set; }
        public int OtherRespondent { get; set; }
        public int TotalRespondent { get; set; }
        public int GPVetting { get; set; }

        public int IGRApproval { get; set; }
     
    }
}
