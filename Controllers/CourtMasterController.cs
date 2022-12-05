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
    public class CourtMasterController : Controller
    {
        private readonly DB_CourtMaster _db;
        public CourtMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_CourtMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetCourtMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Court_master_Model> data = _db.GetCourtMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCourtMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<CourtMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveCourtMaster")]
        public IActionResult Post([FromBody] Court_master_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveCourtMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCourtMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
