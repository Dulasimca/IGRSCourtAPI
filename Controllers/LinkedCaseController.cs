using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Database.DB_Entity;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IGRSCourtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedCaseController : ControllerBase
    {
        private DB_LinkedCase _db;

        public LinkedCaseController(EF_IGRSCC_DataContext dataContext)
        {
            _db = new DB_LinkedCase(dataContext);
        }


        [HttpGet]
        [Route("api/[controller]/GetLinkedCase")]
        public IActionResult Get(int courtcaseid)
        {
            try
            {
                List<LinkedCase_Model> _data = _db.GetLinkedCase(courtcaseid);

                if (_data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(_data);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetCourtCaseByCaseNo : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }
    }
}
