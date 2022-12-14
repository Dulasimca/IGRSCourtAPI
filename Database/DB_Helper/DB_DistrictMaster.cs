using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_DistrictMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_DistrictMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<District_master_Model> GetDistrictMaster()
        {
            var districtmaster = (from _dbCaseEntity in _DataContext.District_Masters
                                  join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                                  select new District_master_Model
                               {
                                    districtid = _dbCaseEntity.districtid,
                                    districtname = _dbCaseEntity.districtname,
                                    zoneid = _dbCaseEntity.zoneid,
                                    createddate = _dbCaseEntity.createddate,
                                    flag = _dbCaseEntity.flag,
                                   zonename = Zone.zonename,
                               }).ToList();
            return districtmaster;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public District_master_Model GetDistrictMaster(int _districtid)
        {
            District_master_Model response = new District_master_Model();
            var dataList = _DataContext.District_Masters.Where(a => a.districtid == _districtid).FirstOrDefault();
            response.districtid = dataList.districtid;
            response.districtname = dataList.districtname;
            response.zoneid = dataList.zoneid;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="district_Master">from model folder</param>
        /// <returns></returns>
        public bool SaveDistrictMaster(District_master_Model district_Master)
        {
            bool isSuccess = false;
            try
            {
                District_master _districtMaster = new District_master();
                // District_master  = new District_master_Model();
                if (district_Master.districtid > 0)
                {
                    //PUT
                    _districtMaster = _DataContext.District_Masters.Where(d => d.districtid.Equals(district_Master.districtid)).FirstOrDefault();
                    if (_districtMaster != null)
                    {
                        _districtMaster.districtname = district_Master.districtname;
                        _districtMaster.zoneid = district_Master.zoneid;
                        _districtMaster.createddate = district_Master.createddate;
                        _districtMaster.flag = district_Master.flag;
                    }
                }
                else
                {
                    //POST
                    _districtMaster.districtname = district_Master.districtname;
                    _districtMaster.zoneid = district_Master.zoneid;
                    _districtMaster.createddate = district_Master.createddate;
                    _districtMaster.flag = district_Master.flag;
                    _DataContext.District_Masters.Add(_districtMaster);
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
