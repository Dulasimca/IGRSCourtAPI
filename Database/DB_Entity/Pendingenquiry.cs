using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("pendingenquiry")]
    public class Pendingenquiry
    {
        //public Pendingenquiry()
        //{
            // District_masters = new HashSet<District_master>();
            //Sro_masters = new HashSet<Sro_master>();
            //Zone_masters = new.HashSet<Zone_master>();
            // Courtcases = new HashSet<Courtcase>();
            //.Writappealsmaster = new.HashSet<Writappealsmaster>();
        //}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int pendingenquiryid { get; set; }
        public int zoneid { get; set; }
        public int districtid { get; set; }
        public int sroid { get; set; }
        public int courtcaseid { get; set; }
        public int writappealsid { get; set; }
        public string subject { get; set; }
        public string referenceno { get; set; }
        public string remarks { get; set; }
        public DateTime? createddate { get; set; }
        public bool flag { get; set; }
    }
}
