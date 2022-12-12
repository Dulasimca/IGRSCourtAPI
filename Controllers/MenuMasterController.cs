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
    public class MenuMasterController : Controller
    {
        private readonly DB_MenuMaster _db;
        public MenuMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_MenuMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetMenuMasters")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Menu_Model> data = _db.GetMenuMasters();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveMenuMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<MenuMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveMenuMaster")]
        public IActionResult Post([FromBody] Menu_Model model)
        {
            try
            {
                bool isSuccess = _db.SaveMenuMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveMenuMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
