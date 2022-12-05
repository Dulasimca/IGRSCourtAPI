using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("usermaster")]
    public class Usermaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; } //int generated always as identity primary key
        public string username { get; set; } //varchar(100)
        public string mailid { get; set; } //varchar(100)
        public string password { get; set; } //varchar(2000)
        public string mobile { get; set; } //varchar(20)
        public int zoneid { get; set; } //int references zone_master(zoneid)
        public int districtid { get; set; } //int references district_master(districtid)
        public int sroid { get; set; } //int references sro_master(sroid)
        public int roleid { get; set; } //int references rolemaster(roleid)
        public DateTime createddate { get; set; } //timestamp
        public bool flag { get; set; } //boolean
    }
}
