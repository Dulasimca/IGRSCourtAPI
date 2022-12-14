using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;
using IGRSCourtAPI.Common;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_SroMaster
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_SroMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Sro_master_Model> GetSroMaster()
        {
            var sromaster = (from _dbCaseEntity in _DataContext.Sro_Masters
                                  join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                                  join District in _DataContext.District_Masters on _dbCaseEntity.zoneid equals District.districtid
                             select new Sro_master_Model
                                  {
                                        sroid = _dbCaseEntity.sroid,
                                        sroname = _dbCaseEntity.sroname,
                                        zoneid = _dbCaseEntity.zoneid,
                                        districtid = _dbCaseEntity.districtid,
                                        createddate = _dbCaseEntity.createddate,
                                        flag = _dbCaseEntity.flag,
                                        zonename = Zone.zonename,
                                        districtname = District.districtname,
                             }).ToList();
            return sromaster;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Sro_master_Model GetSroMaster(int _sroid)
        {
            Sro_master_Model response = new Sro_master_Model();
            var dataList = _DataContext.Sro_Masters.Where(a => a.sroid == _sroid).FirstOrDefault();
            response.sroid = dataList.sroid;
            response.sroname = dataList.sroname;
            response.zoneid = dataList.zoneid;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="sro_Master">from model folder</param>
        /// <returns></returns>
        public bool SaveSroMaster(Sro_master_Model sro_Master)
        {
            bool isSuccess = false;
            try
            {
                Sro_master _sroMaster = new Sro_master(); // from database db entity table
                // Sro_master  = new Sro_master_Model();
                if (sro_Master.sroid > 0)
                {
                    //PUT
                    _sroMaster = _DataContext.Sro_Masters.Where(d => d.sroid.Equals(sro_Master.sroid)).FirstOrDefault();
                    if (_sroMaster != null)
                    {
                        _sroMaster.sroname = sro_Master.sroname;
                        _sroMaster.zoneid = sro_Master.zoneid;
                        _sroMaster.districtid = sro_Master.districtid;
                        _sroMaster.createddate = sro_Master.createddate;
                        _sroMaster.flag = sro_Master.flag;
                    }
                }
                else
                {
                    //POST
                    _sroMaster.sroname = sro_Master.sroname;
                    _sroMaster.zoneid = sro_Master.zoneid;
                    _sroMaster.districtid = sro_Master.districtid;
                    _sroMaster.createddate = sro_Master.createddate;
                    _sroMaster.flag = sro_Master.flag;
                    _DataContext.Sro_Masters.Add(_sroMaster);
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
