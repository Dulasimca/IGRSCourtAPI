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
    public class TimeboundController : Controller
    {
        private readonly DB_Timebound _db;

        public TimeboundController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_Timebound(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[Controller]/GetTimebound")]
        public IActionResult Get(int zoneid, int districtid, int sroid, int casetypeid)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<Timebound_Model> data = _db.GetTimebound(zoneid, districtid, sroid, casetypeid);
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveTimebound : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpPost]
        [Route("api/[controller]/SaveTimebound")]
        public IActionResult Post([FromBody] Timebound_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveTimebound(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveTimebound : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

       }
    }
