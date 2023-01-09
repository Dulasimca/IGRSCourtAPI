namespace IGRSCourtAPI.Model
{
    public class LinkedCase_Model
    {
        public int caseid { get; set; }
        public int courtcaseid { get; set; }
        public string caseno { get; set; }
        public int caseyear { get; set; }
        public int courtid { get; set; }
        public int casetypeid { get; set; }
        public int created_on { get; set; }
        public string casetypename { get; set; }
        public string courtname { get; set; }
    }
}
