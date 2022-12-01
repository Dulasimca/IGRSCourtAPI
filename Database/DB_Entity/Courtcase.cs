using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("courtcase")]
    public class Courtcase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courtcaseid { get; set; } //        courtcaseid int generated always as identity primary key
        public int zoneid { get; set; }// zoneid int 
        public int districtid { get; set; }// districtid int  
        public int sroid { get; set; } // sroid int
        public int casetypeid { get; set; }// casetypeid int  
        public string casenumber { get; set; }// casenumber varchar(100)
        public int caseyear { get; set; }// caseyear int
        public int courtid { get; set; } // courtid int  
        public string petitionername { get; set; } //petitionername varchar(200)
        public string mainrespondents { get; set; } //, mainrespondents varchar(3000)
        public string mainprayer { get; set; }//, mainprayer varchar(2000)
        public bool counterfiled { get; set; } //, counterfiled boolean
        public int casestatusid { get; set; }//, casestatusid       int 
        public string remarks { get; set; } // , remarks varchar(1000)
        public int responsetypeid { get; set; } //    , responsetypeid int
        public DateTime casedate { get; set; } //, casedate date
        public DateTime? createdate { get; set; } //createdate     timestamp
        public bool flag { get; set; } // ,flag boolean

        public virtual Zone_master Zone_Masters { get; set; }
        public virtual District_master District_masters { get; set; }
        public virtual Sro_master Sro_masters { get; set; }
        public virtual Court_master Court_masters { get; set; }
        public virtual Casetype_master Casetype_masters { get; set; }

        public virtual Responsetype_master Responsetype_masters { get; set; }
        public virtual Casestatus_master Casestatus_masters { get; set; }

    }
}
