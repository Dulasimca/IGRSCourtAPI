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

        public List<Writappeals_master_Model> GetWritappealsMaster(int zoneid, int districtid, int sroid, int casetypeid)
        {
            try
            {
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
                                  join District in _DataContext.District_Masters on _dbCaseEntity.districtid equals District.districtid
                                  join Sro in _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid
                                  join CaseType in _DataContext.Casetype_Masters on _dbCaseEntity.casetypeid equals CaseType.casetypeid
                                  join Court in _DataContext.Court_Masters on _dbCaseEntity.courtid equals Court.courtid
                                  join CaseStatus in _DataContext.Casestatus_Masters on _dbCaseEntity.casestatusid equals CaseStatus.casestatusid
                                  join Writappeals in _DataContext.Writappeals_Masters on _dbCaseEntity.courtcaseid equals Writappeals.courtcaseid into writ
                                        from _write in writ.DefaultIfEmpty()
                                  join WritAppealsStatus in _DataContext.Writappealstatus_Masters on _write.writappealstatusid equals WritAppealsStatus.writappealstatusid
                                  where _dbCaseEntity.zoneid == zoneid && _dbCaseEntity.districtid == districtid
                                  && _dbCaseEntity.sroid == sroid && _dbCaseEntity.casetypeid == casetypeid 
                                  select new Writappeals_master_Model
                                  {
                                      writappealsid = _write.writappealsid > 0 ? _write.writappealsid : 0,
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
                                      natureofdisposal = _write.natureofdisposal,
                                      hcreferenceno = _write.hcreferenceno,
                                      regularnumber = _write.regularnumber,
                                      writappealstatusid = _write.writappealstatusid > 0 ? _write.writappealstatusid : 0,
                                      writappealstatusname = WritAppealsStatus.writappealstatusname,
                                      remarks = _write.remarks

                                  }).ToList();

                return _caseModel;
            }
            catch (Exception ex)
            {

                throw;
            }
          
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
                        _writappealsMaster = Managewritappeals(_writappealsMaster,writappeals_Master);
                    }
                }
                else
                {
                    //POST
                    _writappealsMaster = Managewritappeals(_writappealsMaster,writappeals_Master);
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

        public Writappeals_master Managewritappeals(Writappeals_master _writappealsMaster,Writappeals_master_Model writappeals_Master)
        {
            _writappealsMaster.zoneid = writappeals_Master.zoneid;
            _writappealsMaster.districtid = writappeals_Master.districtid;
            _writappealsMaster.sroid = writappeals_Master.sroid;
            _writappealsMaster.courtcaseid = writappeals_Master.courtcaseid;
            _writappealsMaster.regularnumber = writappeals_Master.regularnumber;
            _writappealsMaster.hcreferenceno = writappeals_Master.hcreferenceno;
            _writappealsMaster.natureofdisposal = writappeals_Master.natureofdisposal;
            _writappealsMaster.writappealstatusid = writappeals_Master.writappealstatusid;
            _writappealsMaster.createddate = writappeals_Master.createddate;
            _writappealsMaster.remarks = writappeals_Master.remarks;
            _writappealsMaster.flag = writappeals_Master.flag;
            return _writappealsMaster;
        }

    }

}