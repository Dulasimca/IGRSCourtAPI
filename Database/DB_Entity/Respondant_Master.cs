using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("respondentsmaster")]
    public class Respondant_Master
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
        public int respondentsid { get; set; } //roleid int generated always as identity primary key 
        public string respondentsname { get; set; }//, rolename varchar(200)
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean

    }
}
