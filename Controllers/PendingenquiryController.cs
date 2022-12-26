using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Common;
using IGRSCourtAPI.Model;

namespace IGRSCourtAPI.Controllers
{
    public class PendingenquiryController : Controller
    {
        private readonly DB_Pendingenquiry _db;

        public PendingenquiryController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_Pendingenquiry(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[Controller]/GetPendingenquiry")]
        public IActionResult Get(int zoneid, int districtid, int sroid, int casetypeid)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<Pendingenquiry_Model> data = _db.GetPendingenquiry(zoneid, districtid, sroid, casetypeid);
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SavePendingenquiry : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpPost]
        [Route("api/[controller]/SavePendingenquiry")]
        public IActionResult Post([FromBody] Pendingenquiry_Model model)
        {
            try
            {
                bool isSuccess = _db.SavePendingenquiry(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SavePendingenquiry : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
