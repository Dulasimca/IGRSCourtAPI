using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Controllers
{
    public class WritappealsController : Controller
    {
        private readonly DB_WritappealsMaster _db;
        public WritappealsController(EF_IGRSCC_DataContext dataContext)
            {
                _db = new DB_WritappealsMaster(dataContext);
            }

            [HttpGet]
            [Route("api/[controller]/GetWritappealsMaster")]
            public IActionResult Get(int zoneid, int districtid, int sroid, int courtcaseid)
            {
                ResponseType type = ResponseType.Success;
                try
                {
                    IEnumerable<Writappeals_master_Model> data = _db.GetWritappealsMaster(zoneid, districtid, sroid, courtcaseid);
                    if (!data.Any())
                    {
                        type = ResponseType.NotFound;
                    }
                    return Ok(data);// ResponseHandler.GetAppResponse(type, data));
                }
                catch (Exception ex)
                {
                    AuditLog.WriteError("SaveWritappealsMaster : " + ex.Message);
                    return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
                }
            }

        // POST api/<WritappealsController>
        [HttpPost]
            [Route("api/[controller]/Writappeals")]
            public IActionResult Post([FromBody] Writappeals_master_Model model)
            {
                try
                {
                    bool isSuccess = _db.SaveWritappealsMaster(model);
                    return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
                }
                catch (Exception ex)
                {
                    AuditLog.WriteError("SaveWritappealsMaster : " + ex.Message);
                    return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
                }
            }

        }
    }

