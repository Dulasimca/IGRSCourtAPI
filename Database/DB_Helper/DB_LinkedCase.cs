using IGRSCourtAPI.Database.DB_Entity;
using IGRSCourtAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_LinkedCase
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_LinkedCase(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public List<LinkedCase_Model> GetLinkedCase(int _courtcaseid)
        {
            try
            {
                var _linkedcases = (from _dbLinkedCaseEntity in _DataContext.LinkedCases
                                  join court_master in _DataContext.Court_Masters on _dbLinkedCaseEntity.courtid equals court_master.courtid
                                  join casetype_master in _DataContext.Casetype_Masters on _dbLinkedCaseEntity.casetypeid equals casetype_master.casetypeid
                                  where _dbLinkedCaseEntity.courtcaseid == _courtcaseid
                                  select new LinkedCase_Model
                                  {
                                      courtcaseid = _dbLinkedCaseEntity.courtcaseid,
                                      caseno = _dbLinkedCaseEntity.caseno,
                                      casetypeid = _dbLinkedCaseEntity.casetypeid,
                                      caseyear = _dbLinkedCaseEntity.caseyear,
                                      created_on = _dbLinkedCaseEntity.created_on,
                                      courtid = _dbLinkedCaseEntity.courtid,
                                      casetypename = casetype_master.casetypename,
                                      courtname = court_master.courtname,

                                  }).ToList();
                return _linkedcases;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool SaveLinkedCase(List<LinkedCase_Model> model, int Courtcaseid)
        {
            bool result = false;
            try
            {
                foreach (var item in model)
                {
                    LinkedCase _dbLinkedCaseEntity = new LinkedCase();
                    _dbLinkedCaseEntity = ManageLinkedcase(item, _dbLinkedCaseEntity, Courtcaseid);
                    _DataContext.LinkedCases.Add(_dbLinkedCaseEntity);
                    if (item.caseid > 0)
                    {
                        //PUT
                        _DataContext.Entry(_dbLinkedCaseEntity).State = EntityState.Modified;
                    }
                    _DataContext.SaveChanges();
                }
                
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private LinkedCase ManageLinkedcase(LinkedCase_Model _caseModel, LinkedCase dbEntity,int Courtcaseid)
        {
            dbEntity.courtcaseid = Courtcaseid;
            dbEntity.courtid = _caseModel.courtid;
            dbEntity.caseno = _caseModel.caseno;
            dbEntity.caseyear = _caseModel.caseyear;
            dbEntity.casetypeid = _caseModel.casetypeid;
            dbEntity.created_on = _caseModel.created_on;
            return dbEntity;

        }
    }
}
