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
    [ApiController]
    public class CasetypeMasterController : Controller
    {
            private readonly DB_CasetypeMaster _db;
            public CasetypeMasterController(EF_IGRSCC_DataContext eF_DataContext)
            {
                _db = new DB_CasetypeMaster(eF_DataContext);
            }

            [HttpGet]
            [Route("api/[controller]/GetCasetypeMaster")]
            public IActionResult Get()
            {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Casetype_master_Model> data = _db.GetCasetypeMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasetypeMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
            }
        // POST api/<CasetypeMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveCasetypeMaster")]
        public IActionResult Post([FromBody] Casetype_master_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveCasetypeMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasetypeMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
