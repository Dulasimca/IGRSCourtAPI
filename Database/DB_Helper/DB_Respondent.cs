using IGRSCourtAPI.Common;
using IGRSCourtAPI.Database.DB_Entity;
using IGRSCourtAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_Respondent
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_Respondent(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public List<Courtcase_Model> GetCourtcases()
        {
            List<Courtcase_Model> _modelList = new List<Courtcase_Model>();
            var fromTable = _DataContext.Courtcases.ToList();
            fromTable.ForEach(row => _modelList.Add(new Courtcase_Model()
            {
                courtcaseid = row.courtcaseid,
                zoneid = row.zoneid,
                districtid = row.districtid,
                sroid = row.sroid,
                responsetypeid = row.responsetypeid,
                petitionername = row.petitionername,
                mainrespondents = row.mainrespondents,
                casenumber = row.casenumber,
                casestatusid = row.casestatusid,
                casetypeid = row.casetypeid,
                caseyear = row.caseyear,
                counterfiledid = row.counterfiledid,
                gistofcase = row.mainprayer,
                createdate = row.createdate,
                courtid = row.courtid,
                flag = row.flag
            }));
            return _modelList;
        }

        public List<Courtcase_Model> GetCourtcase(int _userid, int _respondentType, int _fromyear, int _toyear,
            int _zoneid, int _sroid, int _districtid)
        {
            try
            {
                var _caseModel = (from _dbCaseEntity in _DataContext.Courtcases
                                  join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                                  join District in _DataContext.District_Masters on _dbCaseEntity.districtid equals District.districtid
                                  join Sro in _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid
                                  join CaseType in _DataContext.Casetype_Masters on _dbCaseEntity.casetypeid equals CaseType.casetypeid
                                  join Court in _DataContext.Court_Masters on _dbCaseEntity.courtid equals Court.courtid
                                  join Counterfiled in _DataContext.counterfiledmaster on _dbCaseEntity.counterfiledid equals Counterfiled.counterfiledid
                                  join Respondenttype in _DataContext.Responsetype_Masters on _dbCaseEntity.responsetypeid equals Respondenttype.responsetypeid
                                  join CaseStatus in _DataContext.Casestatus_Masters on _dbCaseEntity.casestatusid equals CaseStatus.casestatusid
                                  join MainPrayer in _DataContext.Mainprayer_Master on _dbCaseEntity.mainprayerid equals MainPrayer.mainprayerid
                                  where _dbCaseEntity.caseyear >=_fromyear
                                  && _dbCaseEntity.caseyear <=_toyear && _dbCaseEntity.responsetypeid == _respondentType
                                  //&& _dbCaseEntity.zoneid == _zoneid && _dbCaseEntity.districtid == _districtid && _dbCaseEntity.sroid == _sroid
                                  select new Courtcase_Model
                                  {
                                      courtcaseid = _dbCaseEntity.courtcaseid,
                                      zoneid = _dbCaseEntity.zoneid,
                                      districtid = _dbCaseEntity.districtid,
                                      sroid = _dbCaseEntity.sroid,
                                      petitionername = _dbCaseEntity.petitionername,
                                      mainrespondents = _dbCaseEntity.mainrespondents,
                                      casenumber = _dbCaseEntity.casenumber,
                                      casestatusid = _dbCaseEntity.casestatusid,
                                      casetypeid = _dbCaseEntity.casetypeid,
                                      caseyear = _dbCaseEntity.caseyear,
                                      counterfiledid = _dbCaseEntity.counterfiledid,
                                      gistofcase = _dbCaseEntity.mainprayer,
                                      createdate = _dbCaseEntity.createdate,
                                      courtid = _dbCaseEntity.courtid,
                                      flag = _dbCaseEntity.flag,
                                      userid = _dbCaseEntity.userid,
                                      mainrespondentsid = _dbCaseEntity.mainrespondentsid,
                                      zonename = Zone.zonename,
                                      districtname = District.districtname,
                                      sroname = Sro.sroname,
                                      casestatusname = CaseStatus.casestatusname,
                                      casetypename = CaseType.casetypename,
                                      courtname = Court.courtname,
                                      responsetypeid = Respondenttype.responsetypeid,
                                      responsetypename = Respondenttype.responsetypename,
                                      counterfiledname = Counterfiled.counterfiledname,
                                      mainprayername = MainPrayer.mainprayerdesc,

                                  }).ToList();
                return FilterCourtCases(_zoneid, _districtid, _sroid, _caseModel);

            }
            catch (Exception ex)
            {

                throw;
                return null;
            }
           
            //.Where(x => x.courtcaseid == _caseid).FirstOrDefault();//from db
        }

        public List<string> GetCaseNoList(int _courttype, int _caseyear, int _casetype)
        {
            try
            {
                var _list = _DataContext.Courtcases.Where(x => x.caseyear >= _caseyear && x.caseyear <= _caseyear
                                  && x.casetypeid == _casetype && x.courtid == _courttype
                             ).Select(p =>  p.casenumber).ToList();
                return _list;

            }
            catch (Exception ex)
            {

                throw;
                return null;
            }
        }

        public List<Courtcase_Model> GetCourtCaseByCaseNo(int _courttype, int _caseyear, string _caseno)
        {
            try
            {
                var _caseModel = (from _dbCaseEntity in _DataContext.Courtcases
                                  join Zone in _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                                  join District in _DataContext.District_Masters on _dbCaseEntity.districtid equals District.districtid
                                  join Sro in _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid
                                  join CaseType in _DataContext.Casetype_Masters on _dbCaseEntity.casetypeid equals CaseType.casetypeid
                                  join Court in _DataContext.Court_Masters on _dbCaseEntity.courtid equals Court.courtid
                                  join Counterfiled in _DataContext.counterfiledmaster on _dbCaseEntity.counterfiledid equals Counterfiled.counterfiledid
                                  join Respondenttype in _DataContext.Responsetype_Masters on _dbCaseEntity.responsetypeid equals Respondenttype.responsetypeid
                                  join CaseStatus in _DataContext.Casestatus_Masters on _dbCaseEntity.casestatusid equals CaseStatus.casestatusid
                                  join MainPrayer in _DataContext.Mainprayer_Master on _dbCaseEntity.mainprayerid equals MainPrayer.mainprayerid
                                  where _dbCaseEntity.caseyear >= _caseyear && _dbCaseEntity.caseyear <= _caseyear 
                                  && _dbCaseEntity.casenumber == _caseno && _dbCaseEntity.courtid == _courttype
                                  select new Courtcase_Model
                                  {
                                      courtcaseid = _dbCaseEntity.courtcaseid,
                                      zoneid = _dbCaseEntity.zoneid,
                                      districtid = _dbCaseEntity.districtid,
                                      sroid = _dbCaseEntity.sroid,
                                     // remarks = _dbCaseEntity.remarks,
                                      petitionername = _dbCaseEntity.petitionername,
                                      mainrespondents = _dbCaseEntity.mainrespondents,
                                    //  casedate = _dbCaseEntity.casedate,
                                      casenumber = _dbCaseEntity.casenumber,
                                      casestatusid = _dbCaseEntity.casestatusid,
                                      casetypeid = _dbCaseEntity.casetypeid,
                                      caseyear = _dbCaseEntity.caseyear,
                                      counterfiledid = _dbCaseEntity.counterfiledid,
                                     // judgementid = _dbCaseEntity.judgementid,
                                      gistofcase = _dbCaseEntity.mainprayer,
                                      createdate = _dbCaseEntity.createdate,
                                      courtid = _dbCaseEntity.courtid,
                                      flag = _dbCaseEntity.flag,
                                      userid = _dbCaseEntity.userid,
                                      mainrespondentsid = _dbCaseEntity.mainrespondentsid,
                                      zonename = Zone.zonename,
                                      districtname = District.districtname,
                                      sroname = Sro.sroname,
                                      casestatusname = CaseStatus.casestatusname,
                                      casetypename = CaseType.casetypename,
                                      courtname = Court.courtname,
                                      responsetypeid = Respondenttype.responsetypeid,
                                      responsetypename = Respondenttype.responsetypename,
                                      counterfiledname = Counterfiled.counterfiledname,
                                      mainprayername = MainPrayer.mainprayerdesc,
                                      //judgementname = Judgement.judgementname

                                  }).ToList();
                return _caseModel;

            }
            catch (Exception ex)
            {

                throw;
                return null;
            }

            //.Where(x => x.courtcaseid == _caseid).FirstOrDefault();//from db
        }

        public List<Courtcase_Model> FilterCourtCases(int zoneid, int districtid, int sroid, List<Courtcase_Model> list)
        {
            List <Courtcase_Model> filteredList = new List<Courtcase_Model>();
            if(zoneid == 0)
            {
                filteredList = list;
            }
            else if(zoneid > 0 && districtid == 0)
            {
                filteredList = list.Where(a => a.zoneid == zoneid).ToList();
            }
            else if(zoneid > 0 && districtid > 0 && sroid == 0)
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

        public bool saveCourtCases(Courtcase_Model _caseModel)
        {
            bool result = false;
            try
            {
                Courtcase _dbCaseEntity = new Courtcase();

                if(_caseModel.courtcaseid > 0)
                {
                    //PUT
                    _dbCaseEntity = _DataContext.Courtcases.Where(x => x.courtcaseid == _caseModel.courtcaseid).FirstOrDefault();
                   Console.WriteLine(_dbCaseEntity);
                    if (_dbCaseEntity != null)
                    {
                        _dbCaseEntity = ManageCourtcase(_caseModel, _dbCaseEntity);
                     //   _DataContext.Courtcases.Update(_dbCaseEntity);
                    }
                } else
                {
                    //POST
                    _dbCaseEntity = ManageCourtcase(_caseModel, _dbCaseEntity);
                    _DataContext.Courtcases.Add(_dbCaseEntity);
                }
                _DataContext.SaveChanges();
                result = true;
            } 
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private Courtcase ManageCourtcase(Courtcase_Model _caseModel, Courtcase dbEntity)
        {
            dbEntity.courtid = _caseModel.courtid;
            dbEntity.casenumber = _caseModel.casenumber;
            dbEntity.caseyear = _caseModel.caseyear; 
            dbEntity.responsetypeid = _caseModel.responsetypeid;
            dbEntity.zoneid = _caseModel.zoneid;
            dbEntity.districtid = _caseModel.districtid;
            dbEntity.sroid = _caseModel.sroid;  
            dbEntity.casetypeid = _caseModel.casetypeid;
            dbEntity.petitionername = _caseModel.petitionername;
           // dbEntity.remarks = _caseModel.remarks;
            dbEntity.responsetypeid = _caseModel.responsetypeid;
            dbEntity.mainrespondentsid = _caseModel.mainrespondentsid;
            dbEntity.mainprayer = _caseModel.gistofcase;
            dbEntity.counterfiledid = _caseModel.counterfiledid;
            dbEntity.casestatusid = _caseModel.casestatusid;
            dbEntity.mainprayerid = _caseModel.mainprayerid;
            dbEntity.mainrespondentsid = _caseModel.mainrespondentsid;
            dbEntity.flag = _caseModel.flag;
            dbEntity.createdate = _caseModel.createdate;
            dbEntity.userid = _caseModel.userid;
            return dbEntity;

        }
    }
  
}
