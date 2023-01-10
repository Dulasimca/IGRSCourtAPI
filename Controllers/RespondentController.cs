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
        public IActionResult Get(int userid, int respondentType, int fromyear, int toyear, int zoneid, int sroid, int districtid)
        {
            try
            {
                List<Courtcase_Model> _data = _db.GetCourtcase(userid, respondentType, fromyear, toyear, zoneid, sroid, districtid);
                
                if (_data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(_data);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRespondentCase : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetCaseNoList")]
        public IActionResult Get(int courttype, int caseyear, int casetype)
        {
            try
            {
                List<string> _data = _db.GetCaseNoList(courttype, caseyear, casetype);

                if (_data == null)
                {
                    return Ok(ResponseType.NotFound);
                }
                return Ok(_data);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetCaseNoList : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetCourtCase")]
        public IActionResult Get(int courttype, int caseyear, string caseno)
        {
            try
            {
                List<Courtcase_Model> _data = _db.GetCourtCaseByCaseNo(courttype, caseyear, caseno);

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

        [HttpPost]
        [Route("api/[controller]/SaveRespondentCase")]
        public IActionResult Post([FromBody] Courtcase_Model model)
        {
            try
            {
                bool isSuccess = _db.saveCourtCases(model);
                return Ok(isSuccess == true ? isSuccess : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRespondentCase : " + ex.Message);
                return BadRequest(ResponseType.Failure);
            }
        }
    }
}
