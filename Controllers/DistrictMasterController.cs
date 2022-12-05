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
    public class DistrictMasterController : Controller
   { 
    private readonly DB_DistrictMaster _db;
    public DistrictMasterController(EF_IGRSCC_DataContext eF_DataContext)
    {
        _db = new DB_DistrictMaster(eF_DataContext);
    }

    [HttpGet]
    [Route("api/[controller]/GetDistrictMaster")]
    public IActionResult Get()
    {
        ResponseType type = ResponseType.Success;
        try
        {
            IEnumerable<District_master_Model> data = _db.GetDistrictMaster();
            if (!data.Any())
            {
                type = ResponseType.NotFound;
            }
            return Ok(data);// ResponseHandler.GetAppResponse(type, data));
        }
        catch (Exception ex)
        {
            AuditLog.WriteError("SaveDistrictMaster : " + ex.Message);
            return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
        }
    }

        // POST api/<DistrictMasterController>
        [HttpPost]
    [Route("api/[controller]/SaveDistrictMaster")]
    public IActionResult Post([FromBody] District_master_Model model)
    {
        try
        {
            bool isSuccess = _db.SaveDistrictMaster(model);
            return Ok(isSuccess == true ? model : ResponseType.Failure);
        }
        catch (Exception ex)
        {
            AuditLog.WriteError("SaveDistrictMaster : " + ex.Message);
            return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
        }
    }

    }
}
