using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("casehearing")]
    public class Casehearing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }// zoneid int 
        public int zoneid { get; set; }
        public int districtid { get; set; }
        public int sroid { get; set; }
        public int casetypeid { get; set; }
        public int courtcaseid { get; set; }
        public string remarks { get; set; }//, zonename varchar(200)
        public DateTime hearingdate { get; set; } //, casedate date
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; }// flag boolean
        public int userid { get; set; }

    }
}
