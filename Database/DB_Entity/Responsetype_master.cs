using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("responsetype_master")]
    public class Responsetype_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int responsetypeid { get; set; }//        responsetypeid int generated always as identity primary key 
        public string responsetypename { get; set; } //    ,responsetypename varchar(500)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } //, flag boolean
        public virtual ICollection<Courtcase> Courtcases { get; set; }

    }
}
