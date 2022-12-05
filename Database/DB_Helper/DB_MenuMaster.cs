using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model;

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
    }
}
