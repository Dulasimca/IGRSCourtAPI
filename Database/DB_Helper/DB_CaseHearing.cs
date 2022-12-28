using IGRSCourtAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database.DB_Entity;
namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_CaseHearing
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_CaseHearing(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public List<Case_hearing_model> GetCaseHearing(int zoneid, int districtid, int sroid, int casetypeid, int courtcaseid)
        {
            try
            {
                //var dataList = _DataContext.Writappeals_Masters.OrderBy(a => a.writappeals).ToList();
                //dataList.ForEach(row => response.Add(new Writappeals_master_Model()
                //{
                //    writappealsid = row.writappealsid,
                //    zoneid = row.zoneid,
                //    districtid = row.districtid,`````````````````````````````````
                //    sroid = row.sroid,
                //    courtcaseid = row.courtcaseid,
                //    regularnumber = row.regularnumber,
                //    natureofdisposal = row.natureofdisposal,
                //    remarks = row.remarks,
                //    createddate = row.createddate,
                //    flag = row.flag
                //}));


                var _caseModel = (from _dbCaseHearingEntity in _DataContext.casehearing
                                  join Zone in _DataContext.Zone_Masters on _dbCaseHearingEntity.zoneid equals Zone.zoneid
                                  join District in _DataContext.District_Masters on _dbCaseHearingEntity.districtid equals District.districtid
                                  join Sro in _DataContext.Sro_Masters on _dbCaseHearingEntity.sroid equals Sro.sroid
                                  join CaseType in _DataContext.Casetype_Masters on _dbCaseHearingEntity.casetypeid equals CaseType.casetypeid
                                  join Courtcaseid in _DataContext.Courtcases on _dbCaseHearingEntity.courtcaseid equals Courtcaseid.courtcaseid
                                  where _dbCaseHearingEntity.zoneid == zoneid && _dbCaseHearingEntity.districtid == districtid
                                  && _dbCaseHearingEntity.sroid == sroid && _dbCaseHearingEntity.casetypeid == casetypeid && _dbCaseHearingEntity.courtcaseid == courtcaseid
                                  select new Case_hearing_model
                                  {
                                      casehearingid = _dbCaseHearingEntity.zoneid,
                                      courtcaseid = _dbCaseHearingEntity.courtcaseid,
                                      zoneid = _dbCaseHearingEntity.zoneid,
                                      districtid = _dbCaseHearingEntity.districtid,
                                      sroid = _dbCaseHearingEntity.sroid,
                                      //   remarks = _dbCaseEntity.remarks,
                                      //petitionername = _dbCaseHearingEntity.petitionername,
                                      //mainrespondents = _dbCaseHearingEntity.mainrespondents,
                                      hearingdate = _dbCaseHearingEntity.hearingdate,
                                      //casenumber = _dbCaseHearingEntity.casenumber,
                                      casetypeid = _dbCaseHearingEntity.casetypeid,
                                      createddate = _dbCaseHearingEntity.createddate,
                                      flag = _dbCaseHearingEntity.flag,
                                      userid = _dbCaseHearingEntity.userid,
                                      zonename = Zone.zonename,
                                      districtname = District.districtname,
                                      sroname = Sro.sroname,
                                      casetypename = CaseType.casetypename,
                                      
                                      remarks = _dbCaseHearingEntity.remarks

                                  }).ToList();

                return _caseModel;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool SaveCaseHearing(Case_hearing_model case_hearing_model)
        {
            bool isSuccess = false;
            try
            {
                Casehearing _casehearingentity = new Casehearing(); // from database db entity table
                // Zone_master  = new Zone_master_Model();
                _casehearingentity = _DataContext.casehearing.Where(c => c.courtcaseid.Equals(case_hearing_model.courtcaseid)).FirstOrDefault();
                _casehearingentity = _DataContext.casehearing.Where(c => c.hearingdate.Equals(case_hearing_model.hearingdate)).FirstOrDefault();

                if (_casehearingentity.courtcaseid == case_hearing_model.courtcaseid && _casehearingentity.hearingdate == case_hearing_model.hearingdate)
                {
                    //PUT
                    _casehearingentity = _DataContext.casehearing.Where(d => d.id.Equals(case_hearing_model.casehearingid)).FirstOrDefault();
                    if (_casehearingentity != null)
                    {
                        _casehearingentity.flag = case_hearing_model.flag;
                        //_zoneMaster.createddate = zone_Master.createddate;
                    }
                }
                else
                {
                    //POST
                    _casehearingentity.zoneid = case_hearing_model.zoneid;
                    _casehearingentity.districtid = case_hearing_model.districtid;
                    _casehearingentity.sroid = case_hearing_model.sroid;
                    _casehearingentity.casetypeid = case_hearing_model.casetypeid;
                    _casehearingentity.courtcaseid = case_hearing_model.courtcaseid;
                    _casehearingentity.remarks = case_hearing_model.remarks;
                    _casehearingentity.hearingdate = case_hearing_model.hearingdate;
                    _casehearingentity.userid = case_hearing_model.userid;
                    _casehearingentity.flag = case_hearing_model.flag;
                    _casehearingentity.createddate = case_hearing_model.createddate;
                    _DataContext.casehearing.Add(_casehearingentity);
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
