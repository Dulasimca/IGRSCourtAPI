using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Controllers
{
    [ApiController]
    public class CaseHearingController : Controller
    {
        private readonly DB_CaseHearing _db;
        public CaseHearingController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_CaseHearing(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/SaveCaseHearing")]
        public IActionResult Index([FromBody] Case_hearing_model model)
        {
            try
            {
                bool isSuccess = _db.SaveCaseHearing(model);
                return Ok(isSuccess == true ? isSuccess : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCaseHearing : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetCaseHearing")]
        public IActionResult Get(int zoneid, int districtid, int sroid, int casetypeid, int courtcaseid)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<Case_hearing_model> data = _db.GetCaseHearing(zoneid, districtid, sroid, casetypeid, courtcaseid);
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetCaseHearing : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }


    }
}
