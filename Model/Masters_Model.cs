﻿using System;
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
        public List<Responsetype_master_Model> Responsetype_Masters { get; set; }
        public List<Casestatus_master_Model> Casestatus_Masters { get; set; }
    }
}