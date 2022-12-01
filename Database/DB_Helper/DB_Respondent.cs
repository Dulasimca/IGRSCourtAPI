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

        public Courtcase_Model GetCourtcase(int _caseid)
        {
            Courtcase_Model _caseModel = new Courtcase_Model();
            var fromTable = _DataContext.Courtcases.Where(x => x.courtcaseid == _caseid).FirstOrDefault();//from db
            if(fromTable != null)
            {
                _caseModel.courtcaseid = fromTable.courtcaseid;
                _caseModel.zoneid = fromTable.zoneid;
                _caseModel.districtid = fromTable.districtid;
                _caseModel.sroid = fromTable.sroid;
                _caseModel.remarks = fromTable.remarks;
                _caseModel.responsetypeid = fromTable.responsetypeid;
                _caseModel.petitionername = fromTable.petitionername;
                _caseModel.mainrespondents = fromTable.mainrespondents;
                _caseModel.casedate = fromTable.casedate;
                _caseModel.casenumber = fromTable.casenumber;
                _caseModel.casestatusid = fromTable.casestatusid;
                _caseModel.casetypeid = fromTable.casetypeid;
                _caseModel.caseyear = fromTable.caseyear;
                _caseModel.counterfiled = fromTable.counterfiled;
                _caseModel.mainprayer = fromTable.mainprayer;
                _caseModel.createdate = fromTable.createdate;
                _caseModel.courtid = fromTable.courtid;
                _caseModel.flag = fromTable.flag;
            }
            return _caseModel;
        }

        public bool saveCourtCases(Courtcase_Model _caseModel)
        {
            bool result = false;
            try
            {
                Courtcase _caseEntity = new Courtcase();

                if(_caseModel.courtcaseid > 0)
                {
                    //PUT
                    _caseEntity = _DataContext.Courtcases.Where(x => x.courtcaseid == _caseModel.courtcaseid).FirstOrDefault();
                    if(_caseEntity != null)
                    {
                        _caseEntity = ManageCourtcase(_caseModel);
                    }
                } else
                {
                    //POST
                    _caseEntity = ManageCourtcase(_caseModel);
                    _DataContext.Courtcases.Add(_caseEntity);
                }
                _DataContext.SaveChanges();
                result = true;
            } catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private Courtcase ManageCourtcase(Courtcase_Model _caseModel)
        {
            Courtcase courtcase = new Courtcase();
            courtcase.zoneid = _caseModel.zoneid;
            courtcase.districtid = _caseModel.districtid;
            courtcase.sroid = _caseModel.sroid;
            courtcase.petitionername = _caseModel.petitionername;
            courtcase.remarks = _caseModel.remarks;
            courtcase.responsetypeid = _caseModel.responsetypeid;
            courtcase.mainprayer = _caseModel.mainprayer;
            courtcase.mainrespondents = _caseModel.mainrespondents;
            courtcase.courtid = _caseModel.courtid;
            courtcase.casedate = _caseModel.casedate;
            courtcase.casenumber = _caseModel.casenumber;
            courtcase.casestatusid = _caseModel.casestatusid;
            courtcase.casetypeid = _caseModel.casetypeid;
            courtcase.caseyear = _caseModel.caseyear;
            courtcase.counterfiled = _caseModel.counterfiled;
            courtcase.flag = _caseModel.flag;
            courtcase.createdate = _caseModel.createdate;
            return courtcase;

        }
    }
  
}
