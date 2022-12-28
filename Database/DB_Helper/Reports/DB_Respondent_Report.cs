using IGRSCourtAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Database.DB_Helper.Reports
{
 
    public class DB_Respondent_Report
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_Respondent_Report(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public List<Courtcase_Model> GetCourtcase(int userid, int _respondentType, int _zoneid, int _districtid, int _sroid, string _fromdate, string _todate)
        {
            var _caseModel = (from _dbCaseEntity in _DataContext.Courtcases
                              join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                              join District in _DataContext.District_Masters on _dbCaseEntity.districtid equals District.districtid
                              join Sro in _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid
                              join CaseType in _DataContext.Casetype_Masters on _dbCaseEntity.casetypeid equals CaseType.casetypeid
                              join Court in _DataContext.Court_Masters on _dbCaseEntity.courtid equals Court.courtid
                              join Counterfiled in _DataContext.counterfiledmaster on _dbCaseEntity.counterfiledid equals Counterfiled.counterfiledid
                              join Judgement in _DataContext.judgementmaster on _dbCaseEntity.judgementid equals Judgement.judgementid
                              join Respondenttype in _DataContext.Responsetype_Masters on _dbCaseEntity.responsetypeid equals Respondenttype.responsetypeid
                              join CaseStatus in _DataContext.Casestatus_Masters on _dbCaseEntity.casestatusid equals CaseStatus.casestatusid
                              where _dbCaseEntity.casedate >= Convert.ToDateTime(_fromdate)
                              && _dbCaseEntity.casedate <= Convert.ToDateTime(_todate) && _dbCaseEntity.responsetypeid == _respondentType 
                              // && _dbCaseEntity.zoneid == _zoneid && _dbCaseEntity.districtid == _districtid && _dbCaseEntity.sroid == _sroid
                              select new Courtcase_Model
                              {
                                  courtcaseid = _dbCaseEntity.courtcaseid,
                                  zoneid = _dbCaseEntity.zoneid,
                                  districtid = _dbCaseEntity.districtid,
                                  sroid = _dbCaseEntity.sroid,
                                  remarks = _dbCaseEntity.remarks,
                                  petitionername = _dbCaseEntity.petitionername,
                                  mainrespondents = _dbCaseEntity.mainrespondents,
                                  casedate = _dbCaseEntity.casedate,
                                  casenumber = _dbCaseEntity.casenumber,
                                  casestatusid = _dbCaseEntity.casestatusid,
                                  casetypeid = _dbCaseEntity.casetypeid,
                                  caseyear = _dbCaseEntity.caseyear,
                                  counterfiledid = _dbCaseEntity.counterfiledid,
                                  judgementid = _dbCaseEntity.judgementid,
                                  mainprayer = _dbCaseEntity.mainprayer,
                                  createdate = _dbCaseEntity.createdate,
                                  courtid = _dbCaseEntity.courtid,
                                  mainrespondentsid = _dbCaseEntity.mainrespondentsid,
                                  flag = _dbCaseEntity.flag,
                                  userid = _dbCaseEntity.userid,
                                  zonename = Zone.zonename,
                                  districtname = District.districtname,
                                  sroname = Sro.sroname,
                                  casestatusname = CaseStatus.casestatusname,
                                  casetypename = CaseType.casetypename,
                                  courtname = Court.courtname,
                                  responsetypeid = Respondenttype.responsetypeid,
                                  responsetypename = Respondenttype.responsetypename,
                                  counterfiledname = Counterfiled.counterfiledname,
                                  judgementname = Judgement.judgementname

                              }).ToList();
            //.Where(x => x.courtcaseid == _caseid).FirstOrDefault();//from db
            return FilterCourtCases(_zoneid, _districtid, _sroid, _caseModel);
        }

        public List<Courtcase_Model> FilterCourtCases(int zoneid, int districtid, int sroid, List<Courtcase_Model> list)
        {
            List<Courtcase_Model> filteredList = new List<Courtcase_Model>();
            if (zoneid == 0)
            {
                filteredList = list;
            }
            else if (zoneid > 0 && districtid == 0)
            {
                filteredList = list.Where(a => a.zoneid == zoneid).ToList();
            }
            else if (zoneid > 0 && districtid > 0 && sroid == 0)
            {
                filteredList = list.Where(a => a.zoneid == zoneid && a.districtid == districtid).ToList();
            }
            else if (zoneid > 0 && districtid > 0 && sroid > 0)
            {
                filteredList = list.Where(a => a.zoneid == zoneid && a.districtid == districtid && a.sroid == sroid).ToList();
            }
            else
            {
                filteredList = list;
            }
            return filteredList;
        }

    }
}
