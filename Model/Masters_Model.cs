using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Masters_Model
    {
        public List<Zone_master_Model> Zone_Masters { get; set; }
        public List<District_master_Model> District_Masters { get; set; }
        public List<Sro_master_Model> Sro_Masters { get; set; }
        public List<Court_master_Model> Court_Masters { get; set; }
        public List<Casetype_master_Model> Casetype_Masters { get; set; }
        public List<Casestatus_master_Model> Casestatus_Masters { get; set; }
        public List<Role_master_model> rolemaster { get; set; }
        public List<Respondant_master_model> respondentsmaster { get; set; }
        public List<Slp_master_model> slpmaster { get; set; }
        public List<Judgement_master_model> judgementmaster { get; set; }
        public List<Menu_Model> menumaster { get; set; }
        public List<Writappealstatus_master_Model> Writappealstatus_Masters { get; internal set; }
    }
}
