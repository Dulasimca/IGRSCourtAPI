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
    public class DB_UserMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_UserMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        Security security = new Security();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Usermaster_Model> GetUserMaster()
        {
            var usermasters = (from _dbCaseEntity in _DataContext.usermaster
                               join Role in _DataContext.rolemaster on _dbCaseEntity.roleid equals Role.roleid
                               join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid into Zone
                               from _Zone in Zone.DefaultIfEmpty()
                               join District in _DataContext.District_Masters on _dbCaseEntity.districtid equals District.districtid into District
                               from _District in District.DefaultIfEmpty()
                               join Sro in _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid into sro
                               from _sro in sro.DefaultIfEmpty()

                               select new Usermaster_Model
                               {
                                   userid = _dbCaseEntity.userid,
                                   username = _dbCaseEntity.username,
                                   mailid = _dbCaseEntity.mailid,
                                   password = security.Decryptword(_dbCaseEntity.password),
                                   mobile = _dbCaseEntity.mobile,
                                   zoneid = _dbCaseEntity.zoneid,
                                   districtid = _dbCaseEntity.districtid,
                                   sroid = _dbCaseEntity.sroid,
                                   roleid = _dbCaseEntity.roleid,
                                   createddate = _dbCaseEntity.createddate,
                                   flag = _dbCaseEntity.flag,
                                   zonename = _Zone.zonename,
                                   districtname = _District.districtname,
                                   sroname = _sro.sroname,
                                   rolename = Role.rolename,
                               }).ToList();
            return usermasters;
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
            response.password = security.Decryptword(dataList.password);
            response.mobile = dataList.mobile;
            response.zoneid = dataList.zoneid;
            response.districtid = dataList.districtid;
            response.sroid = dataList.sroid;
            response.roleid = dataList.roleid;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        public Usermaster_Model GetUserMasterByName(string username)
        {
            Usermaster_Model response = new Usermaster_Model();
            var _dataFromDB = _DataContext.usermaster.Where(a => a.username.ToLower() == username.ToLower()).FirstOrDefault();
            if (_dataFromDB != null)
            {
                response.userid = _dataFromDB.userid;
                response.username = _dataFromDB.username;
                response.mailid = _dataFromDB.mailid;
                response.password = _dataFromDB.password;
                response.mobile = _dataFromDB.mobile;
                response.zoneid = _dataFromDB.zoneid;
                response.districtid = _dataFromDB.districtid;
                response.sroid = _dataFromDB.sroid;
                response.roleid = _dataFromDB.roleid;
                response.createddate = _dataFromDB.createddate;
                response.flag = _dataFromDB.flag;
            }
            else
            {
                response = null;
            }
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
                usermaster.password = security.Encryptword(usermaster.password);
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
                        if (usermaster.zoneid > 0)
                        {
                            _userMaster.zoneid = usermaster.zoneid;
                        }
                        if (usermaster.districtid > 0)
                        {
                            _userMaster.districtid = usermaster.districtid;
                        }
                        if (usermaster.sroid > 0)
                        {
                            _userMaster.sroid = usermaster.sroid;
                        }
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
                    if(usermaster.zoneid >0)
                    {
                        _userMaster.zoneid = usermaster.zoneid;
                    }
                    if (usermaster.districtid > 0)
                    {
                        _userMaster.districtid = usermaster.districtid;
                    }
                       
                    if (usermaster.sroid > 0)
                    {
                        _userMaster.sroid = usermaster.sroid;
                    }
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
                Console.WriteLine(ex.Message);

            }
            return isSuccess;
        }

    }
}
