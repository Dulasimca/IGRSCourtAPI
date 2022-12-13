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
    public class MastersController : Controller
    {
        private readonly DB_Masters _db;
        private readonly DB_MenuMaster _dbmenu;
        public MastersController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_Masters(eF_DataContext);
            _dbmenu = new DB_MenuMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetMasters")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                 Masters_Model data = _db.GetMasters();
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetMasters : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetMenuMasters")]
        public IActionResult Get(int roleid)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<Menu> data = _dbmenu.GetMenuMaster(roleid);
                if (data == null)
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
    }
}
