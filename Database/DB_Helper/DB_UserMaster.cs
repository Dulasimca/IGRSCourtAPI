using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_UserMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_UserMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Usermaster_Model> GetUserMaster()
        {
            List<Usermaster_Model> response = new List<Usermaster_Model>();
            var dataList = _DataContext.usermaster.ToList();
            dataList.ForEach(row => response.Add(new Usermaster_Model()
            {
                userid = row.userid,
                username = row.username,
                mailid = row.mailid,
                password = row.password,
                mobile = row.mobile,
                zoneid = row.zoneid,
                districtid = row.districtid,
                sroid = row.sroid,
                roleid = row.roleid,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Usermaster_Model GetUserMaster(int _userid)
        {
            Usermaster_Model response = new Usermaster_Model();
            var dataList = _DataContext.usermaster.Where(a => a.userid == _userid).FirstOrDefault();
                response.userid = dataList.userid;
                response.username = dataList.username;
                response.mailid = dataList.mailid;
                response.password = dataList.password;
                response.mobile = dataList.mobile;
                response.zoneid = dataList.zoneid;
                response.districtid = dataList.districtid;
                response.sroid = dataList.sroid;
                response.roleid = dataList.roleid;
                response.createddate = dataList.createddate;
                response.flag = dataList.flag;
                return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userMaster">from model folder</param>
        /// <returns></returns>
        public bool SaveUserMaster(Usermaster_Model usermaster)
        {
            bool isSuccess = false;
            try
            {
                Usermaster _userMaster = new Usermaster(); // from database db entity table
                // Usermaster  = new Usermaster_Model();
                if (usermaster.userid > 0)
                {
                    //PUT
                    _userMaster = _DataContext.usermaster.Where(d => d.userid.Equals(usermaster.userid)).FirstOrDefault();
                    if (_userMaster != null)
                    {
                        _userMaster.username = usermaster.username;
                        _userMaster.mailid = usermaster.mailid;
                        _userMaster.password = usermaster.password;
                        _userMaster.mobile = usermaster.mobile;
                        _userMaster.zoneid = usermaster.zoneid;
                        _userMaster.districtid = usermaster.districtid;
                        _userMaster.sroid = usermaster.sroid;
                        _userMaster.roleid = usermaster.roleid;
                        _userMaster.createddate = usermaster.createddate;
                        _userMaster.flag = usermaster.flag;
                        
                    }
                }
                else
                {
                    //POST
                        _userMaster.username = usermaster.username;
                        _userMaster.mailid = usermaster.mailid;
                        _userMaster.password = usermaster.password;
                        _userMaster.mobile = usermaster.mobile;
                        _userMaster.zoneid = usermaster.zoneid;
                        _userMaster.districtid = usermaster.districtid;
                        _userMaster.sroid = usermaster.sroid;
                        _userMaster.roleid = usermaster.roleid;
                        _userMaster.createddate = usermaster.createddate;
                        _userMaster.flag = usermaster.flag;
                        _DataContext.usermaster.Add(_userMaster);
                }
                _DataContext.SaveChanges();
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
