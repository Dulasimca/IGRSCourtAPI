using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("timebound")]
    public class Timebound
    {
        public Timebound()
        {
            // District_masters = new HashSet<District_master>();
            //Sro_masters = new HashSet<Sro_master>();
            //Zone_masters = new.HashSet<Zone_master>();
            // Courtcases = new HashSet<Courtcase>();
            //.Writappealsmaster = new.HashSet<Writappealsmaster>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int timeboundid { get; set; }
        public int zoneid { get; set; }
        public int districtid { get; set; }
        public int sroid { get; set; }
        public int courtcaseid { get; set; }
        public int writappealsid { get; set; }
        public DateTime judgementdate { get; set; }
        public DateTime receiptdate { get; set; }
        public string timelimit { get; set; }
        public DateTime expirydate { get; set; }
        public string directedto { get; set; }
        public string natureofdirection { get; set; }
        public string compiledornot { get; set; }
        public string remarks { get; set; }
        public DateTime? createddate { get; set; }
        public bool flag { get; set; }

        //public virtual ICollection<District_master> District_masters { get; set; }

        //public virtual ICollection<Sro_master> Sro_masters { get; set; }

        //public virtual ICollection<Zone_master> Zone_masters { get; set; }

        //public virtual ICollection<Courtcase> Courtcases { get; set; }

        //public virtual ICollection<Writappeals_master> Writappeals_masters { get; set; }
    }
}
