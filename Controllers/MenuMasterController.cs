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
        [Route("api/[controller]/GetMenuMasterCase")]
        public IActionResult Get()
        {
            try
            {
                List<Menu_Model> _data = _db.GetMenuMasters();
                if (_data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(_data);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveMenuMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);
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
