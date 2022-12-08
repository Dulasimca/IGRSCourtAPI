using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_JudgementMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_JudgementMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Judgement_master_model> GetJudgementMaster()
        {
            List<Judgement_master_model> response = new List<Judgement_master_model>();
            var dataList = _DataContext.judgementmaster.OrderBy(e => e.judgementname).ToList();
            dataList.ForEach(row => response.Add(new Judgement_master_model()
            {
                judgementid = row.judgementid,
                judgementname = row.judgementname,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Judgement_master_model GetJudgementMaster(int _judgementmaster)
        {
            Judgement_master_model response = new Judgement_master_model();
            var dataList = _DataContext.judgementmaster.Where(a => a.judgementid == _judgementmaster).FirstOrDefault();
            response.judgementid = dataList.judgementid;
            response.judgementname = dataList.judgementname;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="judgementmaster">from model folder</param>
        /// <returns></returns>
        public bool SaveJudgementMaster(Judgement_master_model judgementmaster)
        {
            bool isSuccess = false;
            try
            {
                Judgement_master _judgementmaster = new Judgement_master();
                // judgementmaster  = new Judgement_master_model();
                if (judgementmaster.judgementid > 0)
                {
                    //PUT
                    _judgementmaster = _DataContext.judgementmaster.Where(d => d.judgementid.Equals(judgementmaster.judgementid)).FirstOrDefault();
                    if (_judgementmaster != null)
                    {
                        _judgementmaster.judgementid = judgementmaster.judgementid;
                        _judgementmaster.judgementname = judgementmaster.judgementname;
                        _judgementmaster.createddate = judgementmaster.createddate;
                        _judgementmaster.flag = judgementmaster.flag;
                    }
                }
                else
                {
                    //POST
                    _judgementmaster.judgementid = judgementmaster.judgementid;
                    _judgementmaster.judgementname = judgementmaster.judgementname;
                    _judgementmaster.createddate = judgementmaster.createddate;
                    _judgementmaster.flag = judgementmaster.flag;
                    _DataContext.judgementmaster.Add(_judgementmaster);
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
