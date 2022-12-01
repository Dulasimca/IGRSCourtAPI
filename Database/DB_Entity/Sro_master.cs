using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("sro_master")]
    public class Sro_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sroid { get; set; } // sroid int generated always as identity primary key 
        public string sroname { get; set; } //, sroname varchar(200)
        public int zoneid { get; set; } //, zoneid int
        public int districtid { get; set; }// , districtid int
        public DateTime createddate { get; set; } //, createddate timestamp
        public bool flag { get; set; }//, flag boolean
        //public Zone_master Zone_Masters { get; set; }
        //public virtual District_master District_masters { get; set; }

        //public virtual ICollection<Courtcase> Courtcases { get; set; }
    }
}
