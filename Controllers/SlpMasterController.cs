using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public class SlpMasterController : Controller
    {
    
        private readonly DB_SlpMaster _db;
        public SlpMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_SlpMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetSlpMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Slp_master_model> data = _db.GetSlpMaster();
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

        // POST api/<SlpMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveSlpMaster")]
        public IActionResult Post([FromBody] Slp_master_model model)
        {
            try
            {
                bool isSuccess = _db.SaveSlpMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveSlpMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

