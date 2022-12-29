using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_RespondantMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_RespondantMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Respondant_master_model> GetRespondentsMaster()
        {
            List<Respondant_master_model> response = new List<Respondant_master_model>();
            var dataList = _DataContext.respondentsmaster.OrderBy(e => e.respondentsname).ToList();
            dataList.ForEach(row => response.Add(new Respondant_master_model()
            {
                respondentsid = row.respondentsid,
                respondentsname = row.respondentsname,
                mobno1 = row.mobno1,
                mobno2 = row.mobno2,
                mailid = row.mailid,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Respondant_master_model GetRespondentsMaster(int _respondentsmaster)
        {
            Respondant_master_model response = new Respondant_master_model();
            var dataList = _DataContext.respondentsmaster.Where(a => a.respondentsid == _respondentsmaster).FirstOrDefault();
            response.respondentsid = dataList.respondentsid;
            response.respondentsname = dataList.respondentsname;
            response.mobno1 = dataList.mobno1;
            response.mobno2 = dataList.mobno2;
            response.mailid = dataList.mailid;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="respondentsmaster">from model folder</param>
        /// <returns></returns>
        public bool SaveRespondentsMaster(Respondant_master_model respondentsmaster)
        {
            bool isSuccess = false;
            try
            {
                Respondant_Master _respondentsmaster = new Respondant_Master();
                // respondentsmaster  = new Respondant_master_model();
                if (respondentsmaster.respondentsid > 0)
                {
                    //PUT
                    _respondentsmaster = _DataContext.respondentsmaster.Where(d => d.respondentsid.Equals(respondentsmaster.respondentsid)).FirstOrDefault();
                    if (_respondentsmaster != null)
                    {
                        _respondentsmaster.respondentsid = respondentsmaster.respondentsid;
                        _respondentsmaster.respondentsname = respondentsmaster.respondentsname;
                        _respondentsmaster.mobno1 = respondentsmaster.mobno1;
                        _respondentsmaster.mobno2 = respondentsmaster.mobno2;
                        _respondentsmaster.mailid = respondentsmaster.mailid;
                        _respondentsmaster.createddate = respondentsmaster.createddate;
                        _respondentsmaster.flag = respondentsmaster.flag;
                    }
                }
                else
                {
                    //POST
                    _respondentsmaster.respondentsid = respondentsmaster.respondentsid;
                    _respondentsmaster.respondentsname = respondentsmaster.respondentsname;
                    _respondentsmaster.mobno1 = respondentsmaster.mobno1;
                    _respondentsmaster.mobno2 = respondentsmaster.mobno2;
                    _respondentsmaster.mailid = respondentsmaster.mailid;
                    _respondentsmaster.createddate = respondentsmaster.createddate;
                    _respondentsmaster.flag = respondentsmaster.flag;
                    _DataContext.respondentsmaster.Add(_respondentsmaster);
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
