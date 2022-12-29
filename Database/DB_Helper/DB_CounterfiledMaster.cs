using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_CounterfiledMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_CounterfiledMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Counterfiled_master_Model> GetCounterfiledMaster()
        {
            List<Counterfiled_master_Model> response = new List<Counterfiled_master_Model>();
            var dataList = _DataContext.counterfiledmaster.OrderBy(e => e.counterfiledid).ToList();
            dataList.ForEach(row => response.Add(new Counterfiled_master_Model()
            {
                counterfiledid = row.counterfiledid,
                counterfiledname = row.counterfiledname,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Counterfiled_master_Model GetCounterfiledMaster(int _counterfiledid)
        {
            Counterfiled_master_Model response = new Counterfiled_master_Model();
            var dataList = _DataContext.counterfiledmaster.Where(a => a.counterfiledid == _counterfiledid).FirstOrDefault();
            response.counterfiledid = dataList.counterfiledid;
            response.counterfiledname = dataList.counterfiledname;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="counterfiledmaster">from model folder</param>
        /// <returns></returns>
        public bool SaveCounterfiledMaster(Counterfiled_master_Model counterfiledmaster)
        {
            bool isSuccess = false;
            try
            {
                Counterfiled_master _counterfiledmaster = new Counterfiled_master();
                // counterfiledmaster  = new Counterfiled_master_Model();
                if (counterfiledmaster.counterfiledid > 0)
                {
                    //PUT
                    _counterfiledmaster = _DataContext.counterfiledmaster.Where(d => d.counterfiledid.Equals(counterfiledmaster.counterfiledid)).FirstOrDefault();
                    if (_counterfiledmaster != null)
                    {
                        _counterfiledmaster.counterfiledid = counterfiledmaster.counterfiledid;
                        _counterfiledmaster.counterfiledname = counterfiledmaster.counterfiledname;
                        _counterfiledmaster.createddate = counterfiledmaster.createddate;
                        _counterfiledmaster.flag = counterfiledmaster.flag;
                    }
                }
                else
                {
                    //POST
                    _counterfiledmaster.counterfiledid = counterfiledmaster.counterfiledid;
                    _counterfiledmaster.counterfiledname = counterfiledmaster.counterfiledname;
                    _counterfiledmaster.createddate = counterfiledmaster.createddate;
                    _counterfiledmaster.flag = counterfiledmaster.flag;
                    _DataContext.counterfiledmaster.Add(_counterfiledmaster);
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
