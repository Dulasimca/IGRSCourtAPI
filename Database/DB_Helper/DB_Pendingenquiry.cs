using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_Pendingenquiry
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_Pendingenquiry(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Pendingenquiry_Model> GetPendingenquiry(int zoneid, int districtid, int sroid, int casetypeid)
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
                                into writ from _Writappeals in writ.DefaultIfEmpty()
                                join WritAppealsStatus in _DataContext.Writappealstatus_Masters on _Writappeals.writappealstatusid equals WritAppealsStatus.writappealstatusid
                                      into writappeal from _writeappeal in writappeal.DefaultIfEmpty()
                                join pending in _DataContext.Pendingenquiry on _dbCaseEntity.courtcaseid equals pending.courtcaseid 
                                into _pending from _pendingenquiry in _pending.DefaultIfEmpty()
                                where _dbCaseEntity.zoneid == zoneid && _dbCaseEntity.districtid == districtid
                                       && _dbCaseEntity.sroid == sroid && _dbCaseEntity.casetypeid == casetypeid && _writeappeal.writappealstatusid == 1
                                select new Pendingenquiry_Model
                              {
                                  pendingenquiryid = _pendingenquiry.pendingenquiryid > 0 ? _pendingenquiry.pendingenquiryid : 0,
                                  writappealsid = _Writappeals.writappealsid,
                                  courtcaseid = _dbCaseEntity.courtcaseid,
                                  zoneid = _dbCaseEntity.zoneid,
                                  districtid = _dbCaseEntity.districtid,
                                  sroid = _dbCaseEntity.sroid,
                                  responsetypeid = _dbCaseEntity.responsetypeid,
                                  petitionername = _dbCaseEntity.petitionername,
                                  mainrespondents = _dbCaseEntity.mainrespondents,
                                  mainprayer = _dbCaseEntity.mainprayer,
                                  casenumber = _dbCaseEntity.casenumber,
                                  casetypeid = _dbCaseEntity.casetypeid,
                                  casestatusid = _dbCaseEntity.casestatusid,
                                  caseyear = _dbCaseEntity.caseyear,
                                  courtid = _dbCaseEntity.courtid,
                                  flag = _dbCaseEntity.flag,
                                  userid = _dbCaseEntity.userid,
                                  zonename = Zone.zonename,
                                  districtname = District.districtname,
                                  sroname = Sro.sroname,
                                  casetypename = CaseType.casetypename,
                                  casestatusname = CaseStatus.casestatusname,
                                  courtname = Court.courtname,
                                  writappealstatusid = _Writappeals.writappealsid,
                                  writappealstatusname = _writeappeal.writappealstatusname,
                                  subject = _pendingenquiry.subject,
                                  referenceno = _pendingenquiry.referenceno,
                                  remarks = _pendingenquiry.remarks

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
        public bool SavePendingenquiry(Pendingenquiry_Model pendingenquiry_Master)
        {
            bool isSuccess = false;
            try
            {
                Pendingenquiry _pendingenquiryMaster = new Pendingenquiry(); // from database db entity table
                if (pendingenquiry_Master.pendingenquiryid > 0)
                {
                    //PUT
                    _pendingenquiryMaster = _DataContext.Pendingenquiry.Where(d => d.pendingenquiryid.Equals(pendingenquiry_Master.pendingenquiryid)).FirstOrDefault();
                    if (_pendingenquiryMaster != null)
                    {
                        _pendingenquiryMaster = Managependingenquiry(_pendingenquiryMaster, pendingenquiry_Master);
                    }
            }
                else
                {
                    //POST
                    _pendingenquiryMaster = Managependingenquiry(_pendingenquiryMaster, pendingenquiry_Master);
                    _DataContext.Pendingenquiry.Add(_pendingenquiryMaster);
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
        public Pendingenquiry Managependingenquiry(Pendingenquiry _pendingenquiryMaster, Pendingenquiry_Model pendingenquiry_Master)
        {
            _pendingenquiryMaster.zoneid = pendingenquiry_Master.zoneid;
            _pendingenquiryMaster.districtid = pendingenquiry_Master.districtid;
            _pendingenquiryMaster.sroid = pendingenquiry_Master.sroid;
            _pendingenquiryMaster.courtcaseid = pendingenquiry_Master.courtcaseid;
            _pendingenquiryMaster.writappealsid = pendingenquiry_Master.writappealsid;
            _pendingenquiryMaster.pendingenquiryid = pendingenquiry_Master.pendingenquiryid;
            _pendingenquiryMaster.subject = pendingenquiry_Master.subject;
            _pendingenquiryMaster.referenceno = pendingenquiry_Master.referenceno;
            _pendingenquiryMaster.remarks = pendingenquiry_Master.remarks;
            _pendingenquiryMaster.flag = pendingenquiry_Master.flag;
            return _pendingenquiryMaster;
        }
    }
}
