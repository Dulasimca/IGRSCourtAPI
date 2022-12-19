using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity

{
    [Table("writappealsmaster")]
    public class Writappeals_master
    {

        public Writappeals_master()
        {
            // District_masters = new HashSet<District_master>();
            //Sro_masters = new HashSet<Sro_master>();
            //Zone_masters = new.HashSet<Zone_master>();
            // Courtcases = new HashSet<Courtcase>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int writappealsid { get; set; }
        public int zoneid { get; set; }
        public int districtid { get; set; }
        public int sroid { get; set; }
        public int courtcaseid { get; set; }
        public string regularnumber { get; set; }
        public string remarks { get; set; }
        public DateTime? createddate { get; set; }
        public bool flag { get; set; }

        //public virtual ICollection<District_master> District_masters { get; set; }

        //public virtual ICollection<Sro_master> Sro_masters { get; set; }

        //public virtual ICollection<Zone_master> Zone_masters { get; set; }

        //public virtual ICollection<Courtcase> Courtcases { get; set; }

    }
}
