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
    public class ZoneMasterController : Controller
    {
        private readonly DB_ZoneMaster _db;
        public ZoneMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_ZoneMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetZoneMaster")]
        public IActionResult Get()
        {
            ResponseType type =  ResponseType.Success;
            try
            {
                IEnumerable<Zone_master_Model> data = _db.GetZoneMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveZoneMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<ZoneMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveZoneMaster")]
        public IActionResult Post([FromBody] Zone_master_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveZoneMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveZoneMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetZoneMaster/{id}")]
        public IActionResult Get(int zoneid)
        {
            try
            {
                Zone_master_Model data = _db.GetZoneMaster(zoneid);
                if (data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveZoneMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
