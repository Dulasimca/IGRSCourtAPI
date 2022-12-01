﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_Masters
    {
        private readonly EF_IGRSCC_DataContext _DataContext;
        public DB_Masters(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Masters_Model GetMasters()
        {
            List<Zone_master_Model> zone_Master_Model = new List<Zone_master_Model>();
            List<District_master_Model> district_Master_Models = new List<District_master_Model>();
            List<Sro_master_Model> sro_Master_Models = new List<Sro_master_Model>();
            List<Casestatus_master_Model> casestatus_master_Models = new List<Casestatus_master_Model>();
            List<Court_master_Model> court_Master_Models = new List<Court_master_Model>();
            List<Casetype_master_Model> casetype_Master_Models = new List<Casetype_master_Model>();
            List<Responsetype_master_Model> responsetype_Master_Models = new List<Responsetype_master_Model>();
            try
            {

                var ZoneList = _DataContext.Zone_Masters.ToList();
                var DistrictList = _DataContext.District_Masters.ToList();
                var SroList = _DataContext.Sro_Masters.ToList();
                var CourtList = _DataContext.Court_Masters.ToList();
                var CasetypeList = _DataContext.Casetype_Masters.ToList();
                var CasestatusList = _DataContext.Casestatus_Masters.ToList();
                var ResponseList = _DataContext.Responsetype_Masters.ToList();

                ZoneList.ForEach(row => zone_Master_Model.Add(new Zone_master_Model()
                {
                    zoneid = row.zoneid,
                    zonename = row.zonename,
                    flag = row.flag
                }));

                DistrictList.ForEach(row => district_Master_Models.Add(new District_master_Model()
                {
                    districtid = row.districtid,
                    districtname = row.districtname,
                    zoneid = row.zoneid,
                    flag = row.flag
                }));

                SroList.ForEach(row => sro_Master_Models.Add(new Sro_master_Model()
                {
                    sroid = row.sroid,
                    sroname = row.sroname,
                    districtid = row.districtid,
                    zoneid = row.zoneid,
                    flag = row.flag
                }));

                CourtList.ForEach(row => court_Master_Models.Add(new Court_master_Model()
                {
                    courtid = row.courtid,
                    courtname = row.courtname,
                    flag = row.flag
                }));

                CasetypeList.ForEach(row => casetype_Master_Models.Add(new Casetype_master_Model()
                {
                    casetypeid = row.casetypeid,
                    casetypename = row.casetypename,
                    flag = row.flag
                }));
                
                CasestatusList.ForEach(row => casestatus_master_Models.Add(new Casestatus_master_Model()
                {
                    casestatusid = row.casestatusid,
                    casestatusname = row.casestatusname,
                    flag = row.flag
                }));

                ResponseList.ForEach(row => responsetype_Master_Models.Add(new Responsetype_master_Model()
                {
                    responsetypeid = row.responsetypeid,
                    responsetypename = row.responsetypename,
                    flag = row.flag
                }));
                Masters_Model masters_Model = new Masters_Model
                {
                    Zone_Masters = zone_Master_Model,
                    District_Masters = district_Master_Models,
                    Sro_Masters = sro_Master_Models,
                    Casestatus_Masters= casestatus_master_Models,
                    Court_Masters= court_Master_Models,
                    Casetype_Masters= casetype_Master_Models,
                    Responsetype_Masters= responsetype_Master_Models
                };
                return masters_Model;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}