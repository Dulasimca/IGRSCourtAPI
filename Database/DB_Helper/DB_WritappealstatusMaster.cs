using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_WritappealstatusMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_WritappealstatusMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Writappealstatus_master_Model> GetWritappealstatusMaster()
        {
            List<Writappealstatus_master_Model> response = new List<Writappealstatus_master_Model>();
            var dataList = _DataContext.Writappealstatus_Masters.OrderBy(a => a.writappealstatusname).ToList();
            dataList.ForEach(row => response.Add(new Writappealstatus_master_Model()
            {
                writappealstatusid = row.writappealstatusid,
                writappealstatusname = row.writappealstatusname,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Writappealstatus_master_Model GetWritappealstatusMaster(int _writappealstatusid)
        {
            Writappealstatus_master_Model response = new Writappealstatus_master_Model();
            var dataList = _DataContext.Writappealstatus_Masters.Where(a => a.writappealstatusid == _writappealstatusid).FirstOrDefault();
            response.writappealstatusid = dataList.writappealstatusid;
            response.writappealstatusname = dataList.writappealstatusname;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Writappealstatus_Master">from model folder</param>
        /// <returns></returns>
        public bool SaveWritappealstatusMaster(Writappealstatus_master_Model writappealstatus_Master)
        {
            bool isSuccess = false;
            try
            {
                Writappealstatus_master _writappealstatusMaster = new Writappealstatus_master();
                if (writappealstatus_Master.writappealstatusid > 0)
                {
                    //PUT
                    _writappealstatusMaster = _DataContext.Writappealstatus_Masters.Where(d => d.writappealstatusid.Equals(writappealstatus_Master.writappealstatusid)).FirstOrDefault();
                    if (_writappealstatusMaster != null)
                    {
                        _writappealstatusMaster.writappealstatusname = writappealstatus_Master.writappealstatusname;
                        _writappealstatusMaster.flag = writappealstatus_Master.flag;
                    }
                }
                else
                {
                    //POST
                    _writappealstatusMaster.writappealstatusname = writappealstatus_Master.writappealstatusname;
                    _writappealstatusMaster.flag = writappealstatus_Master.flag;
                    _writappealstatusMaster.createddate = writappealstatus_Master.createddate;
                    _DataContext.Writappealstatus_Masters.Add(_writappealstatusMaster);
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
