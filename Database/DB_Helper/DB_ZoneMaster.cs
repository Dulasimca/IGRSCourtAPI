using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_ZoneMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_ZoneMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Zone_master_Model> GetZoneMaster()
        {
            List<Zone_master_Model> response = new List<Zone_master_Model>();
            var dataList = _DataContext.Zone_Masters.OrderBy(a=> a.zonename).ToList();
            dataList.ForEach(row => response.Add(new Zone_master_Model()
            {
                zoneid = row.zoneid,
                zonename = row.zonename,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Zone_master_Model GetZoneMaster(int _zoneid)
        {
            Zone_master_Model response = new Zone_master_Model();
            var dataList = _DataContext.Zone_Masters.Where(a => a.zoneid == _zoneid).FirstOrDefault();
            response.zoneid = dataList.zoneid;
            response.zonename = dataList.zonename;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zone_Master">from model folder</param>
        /// <returns></returns>
        public bool SaveZoneMaster(Zone_master_Model zone_Master)
        {
            bool isSuccess = false;
            try
            {
                Zone_master _zoneMaster = new Zone_master(); // from database db entity table
                // Zone_master  = new Zone_master_Model();
                if (zone_Master.zoneid > 0)
                {
                    //PUT
                    _zoneMaster = _DataContext.Zone_Masters.Where(d => d.zoneid.Equals(zone_Master.zoneid)).FirstOrDefault();
                    if (_zoneMaster != null)
                    {
                        _zoneMaster.zonename = zone_Master.zonename;
                        _zoneMaster.flag = zone_Master.flag;
                        //_zoneMaster.createddate = zone_Master.createddate;
                    }
                }
                else
                {
                    //POST
                    _zoneMaster.zonename = zone_Master.zonename;
                    _zoneMaster.flag = zone_Master.flag;
                    _zoneMaster.createddate = zone_Master.createddate;
                    _DataContext.Zone_Masters.Add(_zoneMaster);
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
