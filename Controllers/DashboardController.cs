using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IGRSCourtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DB_Dashboard _db;

        public DashboardController(EF_IGRSCC_DataContext dataContext)
        {
            _db = new DB_Dashboard(dataContext);
        }
        [HttpGet]
        public IActionResult GetCount()
        {
            List<KeyValuePair<string, int>> list = _db.GetCount();
            try
            {
                if(list == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetCountDashboard : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }
    }
}
