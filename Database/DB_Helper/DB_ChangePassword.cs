using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;
using IGRSCourtAPI.Common;


namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_ChangePassword
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_ChangePassword(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        Security security = new Security();


        public bool SaveChangePassword(ChangePassword_Model changepassword)
        {
            bool isSuccess = false;
            try
            {
                ChangePassword _changepassword = new ChangePassword();
                // changepassword  = new ChangePassword_Model();
                _changepassword.newpassword = security.Encryptword(changepassword.newpassword);
                _changepassword.userid = changepassword.userid;
                _changepassword.oldpassword = changepassword.oldpassword;
                //_changepassword.newpassword = changepassword.newpassword;
                _changepassword.createddate = changepassword.createddate;
                _changepassword.flag = changepassword.flag;
                _DataContext.changepassword.Add(_changepassword);
                _DataContext.SaveChanges();

                // update user master tba
            var   _usermaster = _DataContext.usermaster.Where(d => d.userid.Equals(changepassword.userid)).FirstOrDefault();
                if(_usermaster != null)
                {
                    _usermaster.password = security.Encryptword(changepassword.newpassword);
                    _DataContext.SaveChanges();

                }


                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
    }
}
