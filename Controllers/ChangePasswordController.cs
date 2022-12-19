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
    public class ChangePasswordController : Controller
    {
        private readonly DB_ChangePassword _db;
        private readonly DB_UserMaster _dbusermaster;
        public ChangePasswordController(EF_IGRSCC_DataContext eF_DataContext)
        {
            _db = new DB_ChangePassword(eF_DataContext);
            _dbusermaster = new DB_UserMaster(eF_DataContext);
        }

        // Save api/<ChangePasswordController>
        [HttpPost]
        [Route("api/[controller]/SaveChangePassword")]
        public Tuple<bool, string> Post([FromBody] ChangePassword_Model model)
        {

           // Usermaster_Model _user = new Usermaster_Model();
            try
            {
             var  _user = _dbusermaster.GetUserMasterByName(model.username);
                if (_user == null)
                {
                    return new Tuple<bool, string>(false, "Username mismatch, Please enter the correct user name");
                }
                else
                {
                    Security _security = new Security();
                    if (_security.Encryptword(model.oldpassword) == _user.password)
                    {

                        _db.SaveChangePassword(model);
                        return new Tuple<bool, string>(true, "Success");
                    }
                    else
                    {
                        return new Tuple<bool, string>(false, "Password mismatch, Please enter the correct old password");
                    }
                }
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveChangePassword : " + ex.Message);
                return new Tuple<bool, string>(false, "Username mismatch");
            }
        }
    }
}
