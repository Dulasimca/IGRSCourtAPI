using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_WritappealsMaster
    {
        private EF_IGRSCC_DataContext _DataContext;

        pubic DB_WritappealsMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>

        public List<Writappeals_master_Model> GetWritappealsMaster()
        {
            List<Writappeals_master_Model> response = new List<Writappeals_master_Model>();
            var dataList = _DataContext.Writappeals_Masters.OrderBy(a => a.writappeals).ToList();
            dataList.ForEach(row => response.Add(new Writappeals_master_Model()
            {
                writappealsid = row.writappealsid,
                zoneid = row.zoneid,
                districtid = row.districtid,
                sroid = row.sroid,
                courtcaseid = row.courtcaseid,
                regularnumber = row.regularnumber,
                natureofdisposal = row.natureofdisposal,
                remarks = row.remarks,
                createddate = row.createddate,
                flag = row.flag
            }));

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        public bool SaveWritappealsMaster(Writappeals_master_Model writappeals_Master)
        {
            bool isSuccess = false;
            try
            {
                Writappeals_master _writappealsMaster = new Writappeals_master(); // from database db entity table
                // Writappeals_master  = new Writappeals_master_Model();
                if (writappeals_Master.writappealsid > 0)
                {
                    //PUT



                }
            }
        }

    }
}
