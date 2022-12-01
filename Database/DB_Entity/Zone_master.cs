using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("zone_master")]
    public class Zone_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int zoneid { get; set; }// zoneid int 
        public string zonename { get; set; }//, zonename varchar(200)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; }// flag boolean

        //public virtual ICollection<District_master> District_masters { get; set; }

        //public virtual ICollection<Sro_master> Sro_masters { get; set; }

        //public virtual ICollection<Courtcase> Courtcases { get; set; }
    }
}
