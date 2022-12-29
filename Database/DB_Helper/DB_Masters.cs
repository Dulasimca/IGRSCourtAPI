using System;
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
            List<Role_master_model> Role_master_models = new List<Role_master_model>();
            List<Respondant_master_model> respondant_Master_Models = new List<Respondant_master_model>();
            List<Responsetype_master_Model> responsetype_Master_Models = new List<Responsetype_master_Model>();
            List<Slp_master_model> slp_Master_Models = new List<Slp_master_model>();
            List<Judgement_master_model> judgement_Master_Models = new List<Judgement_master_model>();
           // List<Menu_Model> menu_Models = new List<Menu_Model>();
            List<Writappealstatus_master_Model> writappealstatus_Master_Model = new List<Writappealstatus_master_Model>();
            List<Counterfiled_master_Model> counterfiled_Master_Models = new List<Counterfiled_master_Model>();

            try
            {

                var ZoneList = _DataContext.Zone_Masters.ToList();
                var DistrictList = _DataContext.District_Masters.ToList();
                var SroList = _DataContext.Sro_Masters.ToList();
                var CourtList = _DataContext.Court_Masters.ToList();
                var CasetypeList = _DataContext.Casetype_Masters.ToList();
                var CasestatusList = _DataContext.Casestatus_Masters.ToList();
                var RoleMasterList = _DataContext.rolemaster.ToList();
                var RespondentMasterList = _DataContext.respondentsmaster.ToList();
                var ResponsetypeList = _DataContext.Responsetype_Masters.ToList(); 
                 var SlpMasterList = _DataContext.slpmaster.ToList();
                var JudgementMasterList = _DataContext.judgementmaster.ToList();
               // var MenuMasterList = _DataContext.Menumasters.ToList();
                var WritappealstatusList = _DataContext.Writappealstatus_Masters.ToList();
                var counterFiledList = _DataContext.counterfiledmaster.ToList();

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

                RoleMasterList.ForEach(row => Role_master_models.Add(new Role_master_model()
                {
                    roleid = row.roleid,
                    rolename = row.rolename,
                    flag = row.flag
                }));

                RespondentMasterList.ForEach(row => respondant_Master_Models.Add(new Respondant_master_model()
                {
                    respondentsid = row.respondentsid,
                    respondentsname = row.respondentsname,
                    mobno1 = row.mobno1,
                    mobno2 = row.mobno2,
                    mailid = row.mailid,
                    createddate = row.createddate,
                    flag = row.flag,
                    responsetypeid=row.responsetypeid
                }));

                ResponsetypeList.ForEach(row => responsetype_Master_Models.Add(new Responsetype_master_Model()
                {
                    responsetypeid = row.responsetypeid,
                    responsetypename = row.responsetypename,
                    createddate = row.createddate,
                    flag = row.flag
                }));

                SlpMasterList.ForEach(row => slp_Master_Models.Add(new Slp_master_model()
                {
                    slpid = row.slpid,
                    name = row.name,
                    createddate = row.createddate,
                    flag = row.flag
                }));

                WritappealstatusList.ForEach(row => writappealstatus_Master_Model.Add(new Writappealstatus_master_Model()
                {
                    writappealstatusid = row.writappealstatusid,
                    writappealstatusname = row.writappealstatusname,
                    flag = row.flag
                }));

                JudgementMasterList.ForEach(row => judgement_Master_Models.Add(new Judgement_master_model()
                {
                    judgementid = row.judgementid,
                    judgementname = row.judgementname,
                    createddate = row.createddate,
                    flag = row.flag
                }));

                counterFiledList.ForEach(row => counterfiled_Master_Models.Add(new Counterfiled_master_Model()
                {
                    counterfiledid = row.counterfiledid,
                    counterfiledname = row.counterfiledname,
                    createddate = row.createddate,
                    flag = row.flag
                }));

                //MenuMasterList.ForEach(row => menu_Models.Add(new Menu_Model()
                //{
                //    menuid = row.menuid,
                //    id = row.id,
                //    name = row.name,
                //    url = row.url,
                //    parentid = row.parentid,
                //    icon = row.icon,
                //    roleid = row.roleid,
                //    isactive = row.isactive,
                //    priorities = row.priorities
                //}));




                Masters_Model masters_Model = new Masters_Model
                {
                    Zone_Masters = zone_Master_Model,
                    District_Masters = district_Master_Models,
                    Sro_Masters = sro_Master_Models,
                    Casestatus_Masters= casestatus_master_Models,
                    Court_Masters= court_Master_Models,
                    Casetype_Masters= casetype_Master_Models,
                    rolemaster = Role_master_models,
                    respondentsmaster = respondant_Master_Models,
                    slpmaster = slp_Master_Models,
                    judgementmaster = judgement_Master_Models,
                    counterfiledmaster = counterfiled_Master_Models,
                    Writappealstatus_Masters = writappealstatus_Master_Model,
                    responsetype_Masters= responsetype_Master_Models

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
