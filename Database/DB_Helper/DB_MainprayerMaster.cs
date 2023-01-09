using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_MainprayerMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_MainprayerMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public List<Mainprayer_master_Model> GetMainprayerMaster()
        {
            List<Mainprayer_master_Model> response = new List<Mainprayer_master_Model>();
            var dataList = _DataContext.mainprayermaster.OrderBy(e => e.mainprayerid).ToList();
            dataList.ForEach(row => response.Add(new Mainprayer_master_Model()
            {
                mainprayerid = row.mainprayerid,
                mainprayerdesc = row.mainprayerdesc,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mainprayer_master_Model GetMainprayerMaster(int _mainprayerid)
        {
            Mainprayer_master_Model response = new Mainprayer_master_Model();
            var dataList = _DataContext.mainprayermaster.Where(a => a.mainprayerid == _mainprayerid).FirstOrDefault();
            response.mainprayerid = dataList.mainprayerid;
            response.mainprayerdesc = dataList.mainprayerdesc;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="mainprayermaster">from model folder</param>
        /// <returns></returns>
        public bool SaveMainprayerMaster(Mainprayer_master_Model mainprayermaster)
        {
            bool isSuccess = false;
            try
            {
                Mainprayer_master _mainprayermaster = new Mainprayer_master();
                // mainprayermaster  = new Mainprayer_master_Model();
                if (mainprayermaster.mainprayerid > 0)
                {
                    //PUT
                    _mainprayermaster = _DataContext.mainprayermaster.Where(d => d.mainprayerid.Equals(mainprayermaster.mainprayerid)).FirstOrDefault();
                    if (_mainprayermaster != null)
                    {
                        _mainprayermaster.mainprayerid = mainprayermaster.mainprayerid;
                        _mainprayermaster.mainprayerdesc = mainprayermaster.mainprayerdesc;
                        _mainprayermaster.createddate = mainprayermaster.createddate;
                        _mainprayermaster.flag = mainprayermaster.flag;
                    }
                }
                else
                {
                    //POST
                    _mainprayermaster.mainprayerid = mainprayermaster.mainprayerid;
                    _mainprayermaster.mainprayerdesc = mainprayermaster.mainprayerdesc;
                    _mainprayermaster.createddate = mainprayermaster.createddate;
                    _mainprayermaster.flag = mainprayermaster.flag;
                    _DataContext.mainprayermaster.Add(_mainprayermaster);
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
