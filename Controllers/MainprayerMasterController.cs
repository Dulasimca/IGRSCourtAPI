using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Common;
using IGRSCourtAPI.Model;

namespace IGRSCourtAPI.Controllers
{
    public class MainprayerMasterController : Controller
    {
        private readonly DB_MainprayerMaster _db;
        public MainprayerMasterController(EF_IGRSCC_DataContext ef_DataContext)
        {
            _db = new DB_MainprayerMaster(ef_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetMainprayerMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Mainprayer_master_Model> data = _db.GetMainprayerMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveMainprayerMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }
        //POST api/<MainprayerMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveMainprayerMaster")]
        public IActionResult Post([FromBody] Mainprayer_master_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveMainprayerMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveMainprayerMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
