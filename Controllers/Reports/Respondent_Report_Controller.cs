using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Database.DB_Helper.Reports;
using IGRSCourtAPI.Model;

namespace IGRSCourtAPI.Controllers.Reports
{
    public class Respondent_Report_Controller : Controller
    {
        private readonly DB_Respondent_Report _db;
        public Respondent_Report_Controller(EF_IGRSCC_DataContext dataContext)
        {
            _db = new DB_Respondent_Report(dataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetRespondentReport")]
        public IActionResult Get(int respondentType, int zoneid, int sroid, int districtid, string fromdate, string todate)
        {
            try
            {
                List<Courtcase_Model> _data = _db.GetCourtcase(respondentType, zoneid, sroid, districtid, fromdate, todate);
                if (_data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(_data);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRespondentReport : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }
    }
}
