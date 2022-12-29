using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("counterfiledmaster")]
    public class CounterfiledMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int counterfiledid { get; set; }
        public string counterfiledname { get; set; }
        public bool flag { get; set; }
        public DateTime createddate { get; set; }
    }
}
