using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Common;
using IGRSCourtAPI.Model;

namespace IGRSCourtAPI.Controllers
{
    public class RespondantMasterController : Controller
    {
        private readonly DB_RespondantMaster _db;
        public RespondantMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_RespondantMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetRespondentsMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Respondant_master_model> data = _db.GetRespondentsMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRespondantMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<RespondantMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveRespondentsMaster")]
        public IActionResult Post([FromBody] Respondant_master_model model)
        {
            try
            {
                bool isSuccess = _db.SaveRespondentsMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRespondantMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

