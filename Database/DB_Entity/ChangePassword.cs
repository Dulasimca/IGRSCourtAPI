using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table ("changepassword")]
    public class ChangePassword
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; } //id int generated always as identity primary key 
        public int userid { get; set; }
        public string oldpassword { get; set; }//, oldpassword varchar(50)
        public string newpassword { get; set; }//, newpassword varchar(50)
        public DateTime createddate { get; set; }//, createddate timestamp
        public bool flag { get; set; } // , flag boolean
    }
}
