using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IGRSCourtAPI.Model

{
    public class Writappeals_master_Model
    {
           public int writappealsid { get; set; }
           public int zoneid { get; set; }
           public int districtid { get; set; }
           public int sroid { get; set; }
           public int courtcaseid { get; set; }
           public string regularnumber { get; set; }
           public string natureofdisposal { get; set; }
           public string remarks { get; set; }
    
    }
}
