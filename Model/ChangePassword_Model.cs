using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class ChangePassword_Model
    {
        public int id { get; set; } //id int generated always as identity primary key 
        public int userid { get; set; }
        public string username { get; set; }
        public string oldpassword { get; set; }//, oldpassword varchar(50)
        public string newpassword { get; set; }//, newpassword varchar(50)
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
    }
}
