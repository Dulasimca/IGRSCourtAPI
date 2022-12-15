using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Database.DB_Helper;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IGRSCourtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DB_UserMaster _db;

        public LoginController(EF_IGRSCC_DataContext dataContext)
        {
            _db = new DB_UserMaster(dataContext);
        }

        [HttpGet]
        public Tuple<bool, string, Usermaster_Model> GetLogin(string username, string password)
        {
            Usermaster_Model _user = new Usermaster_Model();
            try
            {
                _user =  _db.GetUserMasterByName(username);
                if (_user == null)
                {
                    return new Tuple<bool, string, Usermaster_Model>(false, "Username mismatch", _user);
                } else
                {
                    Security _security = new Security();
                    if(_security.Encryptword(password) == _user.password)
                    {
                        return new Tuple<bool, string, Usermaster_Model>(true, "Success", _user);
                    } else
                    {
                        return new Tuple<bool, string, Usermaster_Model>(false, "Password mismatch", _user);
                    }
                }
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetLogin : " + ex.Message);
                return new Tuple<bool, string, Usermaster_Model>(false, "Username mismatch", null);
            }
        }
    }
}
