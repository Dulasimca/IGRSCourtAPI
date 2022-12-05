using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IGRSCourtAPI.Controllers
{
    [ApiController]
    public class RespondentController : Controller
    {
        private readonly DB_Respondent _db;

        public RespondentController(EF_IGRSCC_DataContext dataContext)
        {
            _db = new DB_Respondent(dataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetRespondentCase")]
        public IActionResult Get(int userid, int respondentType, string fromdate, string todate)
        {
            try
            {
               List<Courtcase_Model> _data = _db.GetCourtcase(userid, respondentType, fromdate, todate);
                if (_data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(_data);
            }
            catch (Exception ex)
            {   
                AuditLog.WriteError("SaveZoneMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }

        [HttpPost]
        [Route("api/[controller]/SaveRespondentCase")]
        public IActionResult Post([FromBody] Courtcase_Model model)
        {
            try
            {
                bool isSuccess = _db.saveCourtCases(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch(Exception ex)
            {
                AuditLog.WriteError("SaveZoneMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }
    }
}
