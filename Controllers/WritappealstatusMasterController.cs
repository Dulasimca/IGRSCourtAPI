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
    public class WritappealstatusMasterController : Controller
    {
        private readonly DB_WritappealstatusMaster _db;
        public WritappealstatusMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_WritappealstatusMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetWritappealstatusMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Writappealstatus_master_Model> data = _db.GetWritappealstatusMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveWritappealstatusMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<WritappealstatusMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveWritappealstatusMaster")]
        public IActionResult Post([FromBody] Writappealstatus_master_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveWritappealstatusMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveWritappealstatusMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetWritappealstatusMaster/{id}")]
        public IActionResult Get(int writappealstatusid)
        {
            try
            {
                Writappealstatus_master_Model data = _db.GetWritappealstatusMaster(writappealstatusid);
                if (data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveWritappealstatusMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }
    }
}
