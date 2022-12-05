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
    [ApiController]
    public class CasestatusMasterController : Controller
    {
        private readonly DB_CasestatusMaster _db;
        public CasestatusMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_CasestatusMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetCasestatusMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Casestatus_master_Model> data = _db.GetCasestatusMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasestatusMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<CasestatusMasterController>
        [HttpPost]
        [Route("api/[controller]/CasestatusMaster")]
        public IActionResult Post([FromBody] Casestatus_master_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveCasestatusMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasestatusMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
