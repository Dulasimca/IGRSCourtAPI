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
                remarks = row.remarks,
                responsetypeid = row.responsetypeid,
                petitionername = row.petitionername,
                mainrespondents = row.mainrespondents,
                casedate = row.casedate,
                casenumber = row.casenumber,
                casestatusid = row.casestatusid,
                casetypeid = row.casetypeid,
                caseyear = row.caseyear,
                counterfiled = row.counterfiled,
                mainprayer = row.mainprayer,
                createdate = row.createdate,
                courtid = row.courtid,
                flag = row.flag
            }));
            return _modelList;
        }

        public List<Courtcase_Model> GetCourtcase(int _userid, int _respondentType, string _fromdate, string _todate,
            int _zoneid, int _sroid, int _districtid)
        {
            var _caseModel = (from _dbCaseEntity in  _DataContext.Courtcases 
                             join Zone in  _DataContext.Zone_Masters on _dbCaseEntity.zoneid equals Zone.zoneid
                             join District in  _DataContext.District_Masters on _dbCaseEntity.zoneid equals District.districtid
                             join Sro in  _DataContext.Sro_Masters on _dbCaseEntity.sroid equals Sro.sroid
                             join CaseType in  _DataContext.Casetype_Masters on _dbCaseEntity.casetypeid equals CaseType.casetypeid
                             join Court in  _DataContext.Court_Masters on _dbCaseEntity.courtid equals Court.courtid
                             join CaseStatus in  _DataContext.Casestatus_Masters on _dbCaseEntity.casestatusid equals CaseStatus.casestatusid
                             where _dbCaseEntity.userid == _userid && _dbCaseEntity.casedate >= Convert.ToDateTime(_fromdate)
                             && _dbCaseEntity.casedate <= Convert.ToDateTime(_todate) && _dbCaseEntity.responsetypeid == _respondentType
                             && _dbCaseEntity.zoneid == _zoneid && _dbCaseEntity.districtid == _districtid && _dbCaseEntity.sroid == _sroid
                              select new Courtcase_Model
                             {
                                    courtcaseid = _dbCaseEntity.courtcaseid,
                                    zoneid = _dbCaseEntity.zoneid,
                                    districtid = _dbCaseEntity.districtid,
                                    sroid = _dbCaseEntity.sroid,
                                    remarks = _dbCaseEntity.remarks,
                                    responsetypeid = _dbCaseEntity.responsetypeid,
                                    petitionername = _dbCaseEntity.petitionername,
                                    mainrespondents = _dbCaseEntity.mainrespondents,
                                    casedate = _dbCaseEntity.casedate,
                                    casenumber = _dbCaseEntity.casenumber,
                                    casestatusid = _dbCaseEntity.casestatusid,
                                    casetypeid = _dbCaseEntity.casetypeid,
                                    caseyear = _dbCaseEntity.caseyear,
                                    counterfiled = _dbCaseEntity.counterfiled,
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
                                    courtname = Court.courtname
                             }).ToList();
                             //.Where(x => x.courtcaseid == _caseid).FirstOrDefault();//from db
            
            return _caseModel;
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
            } catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private Courtcase ManageCourtcase(Courtcase_Model _caseModel, Courtcase dbEntity)
        {
            dbEntity.zoneid = _caseModel.zoneid;
            dbEntity.districtid = _caseModel.districtid;
            dbEntity.sroid = _caseModel.sroid;
            dbEntity.petitionername = _caseModel.petitionername;
            dbEntity.remarks = _caseModel.remarks;
            dbEntity.responsetypeid = _caseModel.responsetypeid;
            dbEntity.mainprayer = _caseModel.mainprayer;
            dbEntity.mainrespondents = _caseModel.mainrespondents;
            dbEntity.courtid = _caseModel.courtid;
            dbEntity.casedate = _caseModel.casedate;
            dbEntity.casenumber = _caseModel.casenumber;
            dbEntity.casestatusid = _caseModel.casestatusid;
            dbEntity.casetypeid = _caseModel.casetypeid;
            dbEntity.caseyear = _caseModel.caseyear;
            dbEntity.counterfiled = _caseModel.counterfiled;
            dbEntity.flag = _caseModel.flag;
            dbEntity.createdate = _caseModel.createdate;
            dbEntity.userid = _caseModel.userid;
            return dbEntity;

        }
    }
  
}
