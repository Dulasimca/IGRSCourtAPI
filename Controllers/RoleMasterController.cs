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
    public class RoleMasterController : Controller
    {
        private readonly DB_RoleMaster _db;
        public RoleMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_RoleMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetRoleMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Role_master_model> data = _db.GetRoleMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRoleMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<RoleMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveRoleMaster")]
        public IActionResult Post([FromBody] Role_master_model model)
        {
            try
            {
                bool isSuccess = _db.SaveRoleMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRoleMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
