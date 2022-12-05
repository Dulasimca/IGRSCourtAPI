using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_CasetypeMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_CasetypeMaster(EF_IGRSCC_DataContext dataContext)

        {
            _DataContext = dataContext;
        }

        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>

        public List<Casetype_master_Model> GetCasetypeMaster()
        {
            List<Casetype_master_Model> response = new List<Casetype_master_Model>();
            var dataList = _DataContext.Casetype_Masters.ToList();
            dataList.ForEach(row => response.Add(new Casetype_master_Model()
            {
                casetypeid = row.casetypeid,
                casetypename = row.casetypename,
                createddate = row.createddate,
                flag = row.flag
            }));
            return response;
        }

        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>

        public Casetype_master_Model GetCasetypeMaster(int _casetypeid)
        {
            Casetype_master_Model response = new Casetype_master_Model();
            var dataList = _DataContext.Casetype_Masters.Where(a => a.casetypeid == _casetypeid).FirstOrDefault();
            response.casetypeid = dataList.casetypeid;
            response.casetypename = dataList.casetypename;
            response.createddate = dataList.createddate;
            response.flag = dataList.flag;
            return response;
        }

        ///<summary>
        ///inseert and update
        /// </summary>
        /// <returns></returns>

        public bool SaveCasetypeMaster(Casetype_master_Model casetype_Master)

        {
            bool isSuccess = false;
            try
            {
                Casetype_master _casetypeMaster = new Casetype_master();
                // Casetype_master = new Casetype_master_Model();
                if (casetype_Master.casetypeid > 0)
                {
                    //PUT
                    _casetypeMaster = _DataContext.Casetype_Masters.Where(d => d.casetypeid.Equals(casetype_Master.casetypeid)).FirstOrDefault();
                    if (_casetypeMaster != null)
                    {
                        _casetypeMaster.casetypename = casetype_Master.casetypename;
                        _casetypeMaster.createddate = casetype_Master.createddate;
                        _casetypeMaster.flag = casetype_Master.flag;
                    }
                }
                else
                {
                    //POST
                    _casetypeMaster.casetypename = casetype_Master.casetypename;
                    _casetypeMaster.createddate = casetype_Master.createddate;
                    _casetypeMaster.flag = casetype_Master.flag;
                    _DataContext.Casetype_Masters.Add(_casetypeMaster);
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

