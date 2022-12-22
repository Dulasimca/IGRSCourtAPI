using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_Timebound
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_Timebound(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Timebound_Model> GetTimebound(int zoneid, int districtid, int sroid, int casetypeid)
        {
            try
            {
                var _caseModel = (from _dbCaseEntity in _DataContext.Courtcases
                                  join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                                  join District in _DataContext.District_Masters on _dbCaseEntity.districtid equals District.districtid
                                  join Sro in _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid
                                  join CaseType in _DataContext.Casetype_Masters on _dbCaseEntity.casetypeid equals CaseType.casetypeid
                                  join Court in _DataContext.Court_Masters on _dbCaseEntity.courtid equals Court.courtid
                                  join CaseStatus in _DataContext.Casestatus_Masters on _dbCaseEntity.casestatusid equals CaseStatus.casestatusid
                                  join Writappeals in _DataContext.Writappeals_Masters on _dbCaseEntity.courtcaseid equals Writappeals.courtcaseid 
                                  join WritAppealsStatus in _DataContext.Writappealstatus_Masters on Writappeals.writappealstatusid equals WritAppealsStatus.writappealstatusid
                                  join times in _DataContext.Timebound on _dbCaseEntity.courtcaseid equals times.courtcaseid into _times from  _timebound in _times.DefaultIfEmpty()
                                  where _dbCaseEntity.zoneid == zoneid && _dbCaseEntity.districtid == districtid
                                  && _dbCaseEntity.sroid == sroid && _dbCaseEntity.casetypeid == casetypeid && Writappeals.writappealstatusid==2
                                  select new Timebound_Model
                                  {
                                      timeboundid = _timebound.timeboundid > 0 ? _timebound.timeboundid : 0,
                                      writappealsid = Writappeals.writappealsid,
                                      courtcaseid = _dbCaseEntity.courtcaseid,
                                      zoneid = _dbCaseEntity.zoneid,
                                      districtid = _dbCaseEntity.districtid,
                                      sroid = _dbCaseEntity.sroid,
                                      responsetypeid = _dbCaseEntity.responsetypeid,
                                      petitionername = _dbCaseEntity.petitionername,
                                      mainrespondents = _dbCaseEntity.mainrespondents,
                                      casenumber = _dbCaseEntity.casenumber,
                                      casetypeid = _dbCaseEntity.casetypeid,
                                      caseyear = _dbCaseEntity.caseyear,
                                      courtid = _dbCaseEntity.courtid,
                                      flag = _dbCaseEntity.flag,
                                      userid = _dbCaseEntity.userid,
                                      zonename = Zone.zonename,
                                      districtname = District.districtname,
                                      sroname = Sro.sroname,
                                      casetypename = CaseType.casetypename,
                                      courtname = Court.courtname,
                                      writappealstatusname = WritAppealsStatus.writappealstatusname,
                                      writappealstatusid= Writappeals.writappealstatusid,
                                      judgementdate = _timebound.timeboundid > 0 ? _timebound.judgementdate : DateTime.Now,
                                      receiptdate = _timebound.timeboundid > 0 ? _timebound.receiptdate:DateTime.Now,
                                      timelimit = _timebound.timelimit,
                                      expirydate = _timebound.timeboundid > 0 ? _timebound.expirydate :DateTime.Now,
                                      directedto = _timebound.directedto,
                                      natureofdirection = _timebound.natureofdirection,
                                      compiledornot = _timebound.compiledornot,
                                      remarks = _timebound.remarks,
                                      //createddate = _timebound.createddate

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
        public bool SaveTimebound(Timebound_Model timebound_Master)
        {
            bool isSuccess = false;
            try
            {
                Timebound _timeboundMaster = new Timebound(); // from database db entity table
                if (timebound_Master.timeboundid > 0)
                {
                    //PUT
                    _timeboundMaster = _DataContext.Timebound.Where(d => d.timeboundid.Equals(timebound_Master.timeboundid)).FirstOrDefault();
                    if (_timeboundMaster != null)
                    {
                        _timeboundMaster = Managetimebound(_timeboundMaster, timebound_Master);
                    }
                }
                else
                {
                    //POST
                    _timeboundMaster = Managetimebound(_timeboundMaster, timebound_Master);
                    _DataContext.Timebound.Add(_timeboundMaster);
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
        public Timebound Managetimebound(Timebound _timeboundMaster, Timebound_Model timebound_Master)
        {
            _timeboundMaster.zoneid = timebound_Master.zoneid;
            _timeboundMaster.districtid = timebound_Master.districtid;
            _timeboundMaster.sroid = timebound_Master.sroid;
            _timeboundMaster.courtcaseid = timebound_Master.courtcaseid;
            _timeboundMaster.writappealsid = timebound_Master.writappealsid;
            _timeboundMaster.timeboundid = timebound_Master.timeboundid;
            _timeboundMaster.judgementdate = timebound_Master.judgementdate;
            _timeboundMaster.receiptdate = timebound_Master.receiptdate;
            _timeboundMaster.timelimit = timebound_Master.timelimit;
            _timeboundMaster.expirydate = timebound_Master.expirydate;
            _timeboundMaster.directedto = timebound_Master.directedto;
            _timeboundMaster.natureofdirection = timebound_Master.natureofdirection;
            _timeboundMaster.compiledornot = timebound_Master.compiledornot;
            _timeboundMaster.createddate = timebound_Master.createddate;
            _timeboundMaster.remarks = timebound_Master.remarks;
            _timeboundMaster.flag = timebound_Master.flag;
            return _timeboundMaster;
        }
    }
}
