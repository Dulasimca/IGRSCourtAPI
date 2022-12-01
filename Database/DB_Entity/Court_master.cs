using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("court_master")]
    public class Court_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courtid { get; set; }// courtid int generated always as identity primary key 
        public string courtname { get; set; }//, courtname varchar(500)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; }// , flag boolean
        public virtual ICollection<Courtcase> Courtcases { get; set; }
    }
}
