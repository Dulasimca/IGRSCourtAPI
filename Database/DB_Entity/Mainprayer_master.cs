using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("mainprayermaster")]
    public class Mainprayer_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int mainprayerid { get; set; }
        public string mainprayerdesc { get; set; }
        public DateTime createddate { get; set; }
        public bool flag { get; set; }
    }
}
