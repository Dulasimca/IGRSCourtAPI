using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("judgementmaster")]

    public class Judgement_master
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
        public int judgementid { get; set; } //judgementid int generated always as identity primary key 
        public string judgementname { get; set; } //judgementname string
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean

        //public virtual Zone_master Zone_Masters { get; set; }

        //public virtual ICollection<Sro_master> Sro_masters { get; set; }
        //public virtual ICollection<Courtcase> Courtcases { get; set; }
    }
}
