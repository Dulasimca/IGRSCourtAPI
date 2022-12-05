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
    public class UserMasterController : Controller
    { 
    private readonly DB_UserMaster _db;
    public UserMasterController(EF_IGRSCC_DataContext eF_DataContext)
    {
        _db = new DB_UserMaster(eF_DataContext);
    }

    [HttpGet]
    [Route("api/[controller]/GetUserMaster")]
    public IActionResult Get()
    {
        ResponseType type = ResponseType.Success;
        try
        {
            IEnumerable<Usermaster_Model> data = _db.GetUserMaster();
            if (!data.Any())
            {
                type = ResponseType.NotFound;
            }
            return Ok(data);// ResponseHandler.GetAppResponse(type, data));
        }
        catch (Exception ex)
        {
            AuditLog.WriteError("SaveUserMaster : " + ex.Message);
            return BadRequest(ResponseType.Failure);// ResponseHandler.GetExceptionResponse(ex));
        }
    }

        // POST api/<UserMasterController>
        [HttpPost]
    [Route("api/[controller]/SaveUserMaster")]
    public IActionResult Post([FromBody] Usermaster_Model model)
    {
        try
        {
            bool isSuccess = _db.SaveUserMaster(model);
            return Ok(isSuccess == true ? model : ResponseType.Failure);// ResponseHandler.GetAppResponse(type, model));
        }
        catch (Exception ex)
        {
            AuditLog.WriteError("SaveUserMaster : " + ex.Message);
            return BadRequest(ResponseType.Failure); //ResponseHandler.GetExceptionResponse(ex));
        }
    }

}
}
