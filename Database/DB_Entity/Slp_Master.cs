using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("slpmaster")]
    public class Slp_Master
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
        public int slpid { get; set; } //slpid int generated always as identity primary key 
        public string name { get; set; }//, name varchar(200)
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean

    }
}
