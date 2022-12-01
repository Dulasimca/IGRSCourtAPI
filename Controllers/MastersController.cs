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
        public MastersController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_Masters(eF_DataContext);
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
                AuditLog.WriteError("SaveZoneMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
