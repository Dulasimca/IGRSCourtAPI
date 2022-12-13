using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_MenuMaster
    {
        private readonly EF_IGRSCC_DataContext _DataContext;
        public DB_MenuMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetMenuMaster(int roleid)
        {
            List<Menu_Model> Menu_Master_Model = new List<Menu_Model>();
            try
            {

                var MenuList = _DataContext.Menumasters.Where(a => a.roleid == roleid).ToList();

                MenuList.ForEach(row => Menu_Master_Model.Add(new Menu_Model()
                {
                    menuid = row.menuid,
                    id = row.id,
                    name = row.name,
                    url=row.url,
                    parentid=row.parentid,
                    icon=row.icon,
                    roleid=row.roleid,
                    isactive=row.isactive,
                    priorities=row.priorities
                }));

              
                return GetMenuTree(Menu_Master_Model,0);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
  


        private List<Menu> GetMenuTree(List<Menu_Model> list, int? parent)
        {
            try
            {
                return list.Where(x => x.parentid == parent).OrderBy(a => a.priorities).Select(x => new Menu
                {
                    ID = x.id,
                    label = x.name,
                    parentId = x.parentid,
                    routerLink = x.url,
                    isActive = x.isactive,
                    icon = x.icon,
                    items = GetMenuTree(list, x.id)
                }).ToList();
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        //MenuMasterWithJoin
        public List<Menu_Model> GetMenuMasters()
        {
            var menumaster = (from _dbCaseEntity in _DataContext.Menumasters
                              join Role in _DataContext.rolemaster on _dbCaseEntity.roleid equals Role.roleid
                              
                              select new Menu_Model
                              {
                                  menuid = _dbCaseEntity.menuid,
                                  id = _dbCaseEntity.id,
                                  name = _dbCaseEntity.name,
                                  url = _dbCaseEntity.url,
                                  parentid = _dbCaseEntity.parentid,
                                  icon = _dbCaseEntity.icon,
                                  roleid = _dbCaseEntity.roleid,
                                  isactive = _dbCaseEntity.isactive,
                                  priorities = _dbCaseEntity.priorities,
                                  rolename = Role.rolename
                              }).ToList();
            //.Where(x => x.roleid == _menuid).FirstOrDefault();//from db

            return menumaster;
        }

        public bool SaveMenuMaster(Menu_Model menumaster)
        {
            bool isSuccess = false;
            try
            {
                Menumaster _menumaster = new Menumaster();
                // rolemaster  = new Role_master_model();
                if (menumaster.menuid > 0)
                {
                    //PUT
                    _menumaster = _DataContext.Menumasters.Where(d => d.menuid.Equals(menumaster.menuid)).FirstOrDefault();
                    if (_menumaster != null)
                    {
                        _menumaster.menuid = menumaster.menuid;                   
                        _menumaster.id = menumaster.id;
                        _menumaster.name = menumaster.name;
                        _menumaster.url = menumaster.url;
                        _menumaster.parentid = menumaster.parentid;
                        _menumaster.icon = menumaster.icon;
                        _menumaster.roleid = menumaster.roleid;
                        _menumaster.isactive = menumaster.isactive;
                        _menumaster.priorities = menumaster.priorities;
                    }
                }
                else
                {
                    //POST
                    _menumaster.menuid = menumaster.menuid;
                    _menumaster.id = menumaster.id;
                    _menumaster.name = menumaster.name;
                    _menumaster.url = menumaster.url;
                    _menumaster.parentid = menumaster.parentid;
                    _menumaster.icon = menumaster.icon;
                    _menumaster.roleid = menumaster.roleid;
                    _menumaster.isactive = menumaster.isactive;
                    _menumaster.priorities = menumaster.priorities;
                    _DataContext.Menumasters.Add(_menumaster);
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
