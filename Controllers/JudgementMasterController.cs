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
    public class JudgementMasterController : Controller
    {
        private readonly DB_JudgementMaster _db;
        public JudgementMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_JudgementMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetJudgementMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Judgement_master_model> data = _db.GetJudgementMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);// ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveJudgementMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<RoleMasterController>
        [HttpPost]
        [Route("api/[controller]/SaveJudgementMaster")]
        public IActionResult Post([FromBody] Judgement_master_model model)
        {
            try
            {
                bool isSuccess = _db.SaveJudgementMaster(model);
                return Ok(isSuccess == true ? model : ResponseType.Failure);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveJudgementMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

