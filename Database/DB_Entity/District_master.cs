using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("district_master")]
    public class District_master
    {
        //public District_master()
        //{
        //    Zone_Masters = new Zone_master();
        //    Sro_masters = new HashSet<Sro_master>();
        //    Courtcases = new HashSet<Courtcase>();
        //   // this.Issuememodonoes = new HashSet<Issuememodono>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int districtid { get; set; } //districtid int generated always as identity primary key 
        public string districtname { get; set; }//, districtname varchar(200)

        [ForeignKey("Zone_master")]
        public int zoneid { get; set; }//, zoneid int
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
 
        //public virtual Zone_master Zone_Masters { get; set; }
 
        //public virtual ICollection<Sro_master> Sro_masters { get; set; }
        //public virtual ICollection<Courtcase> Courtcases { get; set; }
    }
}
