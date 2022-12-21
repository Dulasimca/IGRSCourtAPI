using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("writappealstatus_master")]
    public class Writappealstatus_master
    {
        public Writappealstatus_master()
        { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int writappealstatusid { get; set; }// writappealstatusid int 
        public string writappealstatusname { get; set; }//, writappealstatusname varchar(200)
        public DateTime? createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; }// flag boolean


    }
}
