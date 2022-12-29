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
    public class CounterfiledMasterController : Controller
    {
        private readonly DB_CounterfiledMaster _db;
        public CounterfiledMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_CounterfiledMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetCounterfiledMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Counterfiled_master_Model> data = _db.GetCounterfiledMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCounterfiledMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<CounterfiledMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveCounterfiledMaster")]
        public IActionResult Post([FromBody] Counterfiled_master_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveCounterfiledMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCounterfiledMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
