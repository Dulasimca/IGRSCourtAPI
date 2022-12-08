using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_SlpMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_SlpMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Slp_master_model> GetSlpMaster()
        {
            List<Slp_master_model> response = new List<Slp_master_model>();
            var dataList = _DataContext.slpmaster.OrderBy(e => e.name).ToList();
            dataList.ForEach(row => response.Add(new Slp_master_model()
            {
                slpid = row.slpid,
                name = row.name,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Slp_master_model GetSlpMaster(int _Slp_master)
        {
            Slp_master_model response = new Slp_master_model();
            var dataList = _DataContext.slpmaster.Where(a => a.slpid == _Slp_master).FirstOrDefault();
            response.slpid = dataList.slpid;
            response.name = dataList.name;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="slpmaster">from model folder</param>
        /// <returns></returns>
        public bool SaveSlpMaster(Slp_master_model slpmaster)
        {
            bool isSuccess = false;
            try
            {
                Slp_Master _Slp_master = new Slp_Master();
                // slpmaster  = new Slp_master_model();
                if (slpmaster.slpid > 0)
                {
                    //PUT
                    _Slp_master = _DataContext.slpmaster.Where(d => d.slpid.Equals(slpmaster.slpid)).FirstOrDefault();
                    if (_Slp_master != null)
                    {
                        _Slp_master.slpid = slpmaster.slpid;
                        _Slp_master.name = slpmaster.name;
                        _Slp_master.createddate = _Slp_master.createddate;
                        _Slp_master.flag = slpmaster.flag;
                    }
                }
                else
                {
                    //POST
                    _Slp_master.slpid = slpmaster.slpid;
                    _Slp_master.name = slpmaster.name;
                    _Slp_master.createddate = _Slp_master.createddate;
                    _Slp_master.flag = slpmaster.flag;
                    _DataContext.slpmaster.Add(_Slp_master);
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
