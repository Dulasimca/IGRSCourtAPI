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

        public DB_WritappealsMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>

        public List<Writappeals_master_Model> GetWritappealsMaster(int zoneid,int districtid, int sroid,int courtcaseid)
        {
            List<Writappeals_master_Model> response = new List<Writappeals_master_Model>();
            //var dataList = _DataContext.Writappeals_Masters.OrderBy(a => a.writappeals).ToList();
            //dataList.ForEach(row => response.Add(new Writappeals_master_Model()
            //{
            //    writappealsid = row.writappealsid,
            //    zoneid = row.zoneid,
            //    districtid = row.districtid,
            //    sroid = row.sroid,
            //    courtcaseid = row.courtcaseid,
            //    regularnumber = row.regularnumber,
            //    natureofdisposal = row.natureofdisposal,
            //    remarks = row.remarks,
            //    createddate = row.createddate,
            //    flag = row.flag
            //}));


            var _caseModel = (from _dbCaseEntity in _DataContext.Courtcases
                              join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                              join District in _DataContext.District_Masters on _dbCaseEntity.zoneid equals District.districtid
                              join Sro in _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid
                              join CaseType in _DataContext.Casetype_Masters on _dbCaseEntity.casetypeid equals CaseType.casetypeid
                              join Court in _DataContext.Court_Masters on _dbCaseEntity.courtid equals Court.courtid
                              join CaseStatus in _DataContext.Casestatus_Masters on _dbCaseEntity.casestatusid equals CaseStatus.casestatusid
                              join Writappeals in _DataContext.Writappeals_Masters on _dbCaseEntity.courtcaseid equals Writappeals.courtcaseid
                             where _dbCaseEntity.zoneid == zoneid && _dbCaseEntity.districtid == districtid
                              && _dbCaseEntity.sroid == sroid && _dbCaseEntity.courtcaseid == courtcaseid
                              select new Writappeals_master_Model
                              {
                                  courtcaseid = _dbCaseEntity.courtcaseid,
                                  zoneid = _dbCaseEntity.zoneid,
                                  districtid = _dbCaseEntity.districtid,
                                  sroid = _dbCaseEntity.sroid,
                               //   remarks = _dbCaseEntity.remarks,
                                  responsetypeid = _dbCaseEntity.responsetypeid,
                                  petitionername = _dbCaseEntity.petitionername,
                                  mainrespondents = _dbCaseEntity.mainrespondents,
                                  casedate = _dbCaseEntity.casedate,
                                  casenumber = _dbCaseEntity.casenumber,
                                  casestatusid = _dbCaseEntity.casestatusid,
                                  casetypeid = _dbCaseEntity.casetypeid,
                                  caseyear = _dbCaseEntity.caseyear,
                                  mainprayer = _dbCaseEntity.mainprayer,
                                  createdate = _dbCaseEntity.createdate,
                                  courtid = _dbCaseEntity.courtid,
                                  flag = _dbCaseEntity.flag,
                                  userid = _dbCaseEntity.userid,
                                  zonename = Zone.zonename,
                                  districtname = District.districtname,
                                  sroname = Sro.sroname,
                                  casestatusname = CaseStatus.casestatusname,
                                  casetypename = CaseType.casetypename,
                                  courtname = Court.courtname,
                                  regularnumber = Writappeals.regularnumber,
                                  natureofdisposal =Writappeals.natureofdisposal,
                                  writ_remarks= Writappeals.writ_remarks

                              }).ToList();

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
                    _writappealsMaster = _DataContext.Writappeals_Masters.Where(d => d.writappealsid.Equals(writappeals_Master.writappealsid)).FirstOrDefault();
                    if (_writappealsMaster != null)
                    {
                        _writappealsMaster = Managewritappeals(writappeals_Master);
                    }
                }
                else
                {
                    //POST
                    _writappealsMaster = Managewritappeals(writappeals_Master);
                    _DataContext.Writappeals_Masters.Add(_writappealsMaster);
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

        public Writappeals_master Managewritappeals(Writappeals_master_Model writappeals_Master)
        {
            Writappeals_master _writappealsMaster = new Writappeals_master();
            _writappealsMaster.zoneid = writappeals_Master.zoneid;
            _writappealsMaster.districtid = writappeals_Master.districtid;
            _writappealsMaster.sroid = writappeals_Master.sroid;
            _writappealsMaster.courtcaseid = writappeals_Master.courtcaseid;
            _writappealsMaster.regularnumber = writappeals_Master.regularnumber;
            _writappealsMaster.natureofdisposal = writappeals_Master.natureofdisposal;
            _writappealsMaster.writ_remarks = writappeals_Master.writ_remarks;
            _writappealsMaster.flag = writappeals_Master.flag;
            return _writappealsMaster;
        }

    }
           
}
