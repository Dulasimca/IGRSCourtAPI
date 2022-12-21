using IGRSCourtAPI.Database.DB_Entity;
using IGRSCourtAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_SupremeCourtCase
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_SupremeCourtCase(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public List<SupremeCourtCaseModel> GetCourtCases(int _courtcaseid)
        {
            var _caseList = (from _dbSupremeCourtEntity in _DataContext.SupremeCourtCase
                                      join Zone in _DataContext.Zone_Masters on _dbSupremeCourtEntity.zoneid equals Zone.zoneid
                                      join District in _DataContext.District_Masters on _dbSupremeCourtEntity.districtid equals District.districtid
                                      join Sro in _DataContext.Sro_Masters on _dbSupremeCourtEntity.sroid equals Sro.sroid
                                      join Slp in _DataContext.slpmaster on _dbSupremeCourtEntity.slptypeid equals Slp.slpid
                                      join CaseStatus in _DataContext.Casestatus_Masters on _dbSupremeCourtEntity.casestatusid equals CaseStatus.casestatusid
                                      where _dbSupremeCourtEntity.courtcaseid == _courtcaseid
                                      select new SupremeCourtCaseModel
                                      {
                                          courtcaseid = _dbSupremeCourtEntity.courtcaseid,
                                          zoneid = _dbSupremeCourtEntity.zoneid,
                                          districtid = _dbSupremeCourtEntity.districtid,
                                          sroid = _dbSupremeCourtEntity.sroid,
                                          slptypeid = _dbSupremeCourtEntity.slptypeid,
                                          slpcaseno = _dbSupremeCourtEntity.slpcaseno,
                                          petitionername = _dbSupremeCourtEntity.petitionername,
                                          mainprayer = _dbSupremeCourtEntity.mainprayer,
                                          mainrespondents = _dbSupremeCourtEntity.mainrespondents,
                                          casestatusid = _dbSupremeCourtEntity.casestatusid,
                                          casedate = _dbSupremeCourtEntity.casedate,
                                          counterfiled = _dbSupremeCourtEntity.counterfiled,
                                          casefiledby = _dbSupremeCourtEntity.casefiledby,
                                          highcourtrefno = _dbSupremeCourtEntity.highcourtrefno,
                                          remarks = _dbSupremeCourtEntity.remarks,
                                          createdate = _dbSupremeCourtEntity.createdate,
                                          flag = _dbSupremeCourtEntity.flag,
                                          userid = _dbSupremeCourtEntity.userid,
                                          zonename = Zone.zonename,
                                          districtname = District.districtname,
                                          sroname = Sro.sroname,
                                          casestatusname = CaseStatus.casestatusname,
                                          slptypename = Slp.name,
                                      }).ToList();
            return _caseList;
        }

        public bool SaveSupremeCourtCase(SupremeCourtCaseModel _caseModel)
        {
            bool isSuccess = false;
            try
            {
                SupremeCourtCase _dbEntity = new SupremeCourtCase();
                if(_caseModel.courtcaseid > 0)
                {
                    _dbEntity = _DataContext.SupremeCourtCase.Where(x => x.courtcaseid == _caseModel.courtcaseid).FirstOrDefault();
                    if(_dbEntity != null)
                    {
                        _dbEntity = ManageCourtCase(_dbEntity, _caseModel);
                    }
                } else
                {
                    _dbEntity = ManageCourtCase(_dbEntity, _caseModel);
                    _DataContext.SupremeCourtCase.Add(_dbEntity);
                }
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }

        private SupremeCourtCase ManageCourtCase(SupremeCourtCase _dbEntity, SupremeCourtCaseModel _caseModel)
        {
            _dbEntity.zoneid = _caseModel.zoneid;
            _dbEntity.sroid = _caseModel.sroid;
            _dbEntity.districtid = _caseModel.districtid;
            _dbEntity.slpcaseno = _caseModel.slpcaseno;
            _dbEntity.slptypeid = _caseModel.slptypeid;
            _dbEntity.casestatusid = _caseModel.casestatusid;
            _dbEntity.userid = _caseModel.userid;
            _dbEntity.flag = _caseModel.flag;
            _dbEntity.createdate = _caseModel.createdate;
            _dbEntity.casedate = _caseModel.casedate;
            _dbEntity.counterfiled = _caseModel.counterfiled;
            _dbEntity.casefiledby = _caseModel.casefiledby;
            _dbEntity.petitionername = _caseModel.petitionername;
            _dbEntity.mainprayer = _caseModel.mainprayer;
            _dbEntity.mainrespondents = _caseModel.mainrespondents;
            _dbEntity.remarks = _caseModel.remarks;
            _dbEntity.highcourtrefno = _caseModel.highcourtrefno;
            return _dbEntity;
        }

    }
}
