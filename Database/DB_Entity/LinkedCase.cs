using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGRSCourtAPI.Database.DB_Entity
{
    [Table("linkedcase_details")]
    public class LinkedCase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int caseid { get; set; }
        public int courtcaseid { get; set; }
        public string caseno { get; set; }
        public int caseyear { get; set; }
        public int courtid { get; set; }
        public int casetypeid { get; set; }
        public int created_on { get; set; }
    }
}
