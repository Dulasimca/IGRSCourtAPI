using IGRSCourtAPI.Common;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Database;

namespace IGRSCourtAPI.Controllers
{
    [ApiController]
    public class SupremeCourtCaseController : ControllerBase
    {
        private readonly DB_SupremeCourtCase _db;

        public SupremeCourtCaseController(EF_IGRSCC_DataContext dataContext)
        {
            _db = new DB_SupremeCourtCase(dataContext);
        }
        //POST
        [HttpGet]
        [Route("api/[controller]/GetSupremeCourtCase")]
        public IActionResult Get(int userid, string fromdate, string todate, int zoneid, int sroid, int districtid)
        {
            try
            {
                List<SupremeCourtCaseModel> _data = _db.GetCourtCases(userid, fromdate, todate, zoneid, sroid, districtid);
                if (_data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(_data);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetSupremeCourtCase : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }

        [HttpPost]
        [Route("api/[controller]/SaveSupremeCourtCase")]
        public IActionResult Post([FromBody] SupremeCourtCaseModel model)
        {
            try
            {
                bool isSuccess = _db.SaveSupremeCourtCase(model);
                return Ok(isSuccess == true ? isSuccess : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveSupremeCourtCase : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }
    }
}
