using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model.Reports
{
    public class CourtCaseStatusReport_Model
    {
        public List<Courtcasestatus_model> DIGRCaseStatus { get; set; }
        public  List<CourtcaseCANotFiledRespondent_Model> RespondentStatus { get; set; }
        public List<Courtcasestatus_model> StampsStatus { get; set; }
        public List<Courtcasestatus_model> AEEStatus { get; set; }


    }
}
