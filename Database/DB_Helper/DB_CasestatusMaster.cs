using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_CasestatusMaster
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_CasestatusMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>

        public List<Casestatus_master_Model> GetCasestatusMaster()
        {
            List<Casestatus_master_Model> response = new List<Casestatus_master_Model>();
            var dataList = _DataContext.Casestatus_Masters.OrderBy(a=> a.casestatusname).ToList();
            dataList.ForEach(row => response.Add(new Casestatus_master_Model()
            {
                casestatusid = row.casestatusid,
                casestatusname = row.casestatusname,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }
        ///<summary>
        ///
        /// <param name="casetype_Master">from model folder</param>
        /// </summary>
        /// <returns></returns>
        public bool SaveCasestatusMaster(Casestatus_master_Model casestatus_Master)
        {
            bool isSuccess = false;
            try
            {
                Casestatus_master _casestatusMaster = new Casestatus_master();

                if (casestatus_Master.casestatusid > 0)
                {
                    //PUT
                    _casestatusMaster = _DataContext.Casestatus_Masters.Where(d => d.casestatusid.Equals(casestatus_Master.casestatusid)).FirstOrDefault();
                    if (_casestatusMaster != null)
                    {
                        _casestatusMaster.casestatusname = casestatus_Master.casestatusname;
                        _casestatusMaster.createddate = casestatus_Master.createddate;
                        _casestatusMaster.flag = casestatus_Master.flag;
                    }
                }
                else
                {
                    //POST
                    _casestatusMaster.casestatusname = casestatus_Master.casestatusname;
                    _casestatusMaster.createddate = casestatus_Master.createddate;
                    _casestatusMaster.flag = casestatus_Master.flag;
                    _DataContext.Casestatus_Masters.Add(_casestatusMaster);
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
