using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_CourtMaster
    {
        public EF_IGRSCC_DataContext _DataContext;
        public DB_CourtMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns

        public List<Court_master_Model> GetCourtMaster()
        {
            List<Court_master_Model> response = new List<Court_master_Model>();
            var dataList = _DataContext.Court_Masters.ToList();
            dataList.ForEach(row => response.Add(new Court_master_Model()
            {
                courtid = row.courtid,
                courtname = row.courtname,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Court_master_Model GetCourtMaster(int _courtid)
        {
            Court_master_Model response = new Court_master_Model();
            var dataList = _DataContext.Court_Masters.Where(a => a.courtid == _courtid).FirstOrDefault();
            response.courtid = dataList.courtid;
            response.courtname = dataList.courtname;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }
        ///<summary>
        ///insert and update
        /// </summary>
        /// <param name="court_Master">from model folder</param>
        /// <returns></returns>

        public bool SaveCourtMaster(Court_master_Model court_Master)
        {
            bool isSuccess = false;
            try
            {
                Court_master _courtMaster = new Court_master(); // from database db entity table
                // Court_master  = new Court_master_Model();
                if (court_Master.courtid > 0)
                {
                    //PUT
                    _courtMaster = _DataContext.Court_Masters.Where(d => d.courtid.Equals(court_Master.courtid)).FirstOrDefault();
                    if (_courtMaster != null)
                    {
                        _courtMaster.courtname = court_Master.courtname;
                        _courtMaster.flag = court_Master.flag;
                        _courtMaster.createddate = court_Master.createddate;
                    }
                }
                else
                {
                    //POST
                    _courtMaster.courtname = court_Master.courtname;
                    _courtMaster.flag = court_Master.flag;
                    _courtMaster.createddate = court_Master.createddate;
                    _DataContext.Court_Masters.Add(_courtMaster);
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

