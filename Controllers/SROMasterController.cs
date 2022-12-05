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
    public class SROMasterController : ControllerBase
    {
        private readonly DB_SroMaster _db;
        public SROMasterController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_SroMaster(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetSroMaster")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Sro_master_Model> data = _db.GetSroMaster();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveSroMaster : " + ex.Message);
                return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
            }
        }

            //POST api/<SroMasterController>
            [HttpPost]
            [Route("api/[controller]/SaveSroMaster")]
            public IActionResult Post([FromBody] Sro_master_Model model)

            {
                try
                {
                    bool isSuccess = _db.SaveSroMaster(model);
                    return Ok(isSuccess == true ? model : ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    AuditLog.WriteError("SaveSroMaster : " + ex.Message);
                    return BadRequest(ResponseType.Failure);
                }
            }
        }
    } 
