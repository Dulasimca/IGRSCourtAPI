using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("menumaster")]
    public class Menumaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int menuid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int parentid { get; set; }
        public string icon { get; set; }
        public int roleid { get; set; }
        public bool isactive { get; set; }
        public int priorities { get; set; }

    }
}
