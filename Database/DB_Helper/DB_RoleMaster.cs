using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Database;
using IGRSCourtAPI.Model;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_RoleMaster
    {
        private EF_IGRSCC_DataContext _DataContext;
        public DB_RoleMaster(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Role_master_model> GetRoleMaster()
        {
            List<Role_master_model> response = new List<Role_master_model>();
            var dataList = _DataContext.rolemaster.OrderBy(e => e.rolename).ToList();
            dataList.ForEach(row => response.Add(new Role_master_model()
            {
                roleid = row.roleid,
                rolename = row.rolename,
                flag = row.flag
            }));
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Role_master_model GetRoleMaster(int _rolemaster)
        {
            Role_master_model response = new Role_master_model();
            var dataList = _DataContext.rolemaster.Where(a => a.roleid == _rolemaster).FirstOrDefault();
            response.roleid = dataList.roleid;
            response.rolename = dataList.rolename;
            response.flag = dataList.flag;
            return response;
        }

        /// <summary>
        /// insert and update
        /// </summary>
        /// <param name="rolemaster">from model folder</param>
        /// <returns></returns>
        public bool SaveRoleMaster(Role_master_model rolemaster)
        {
            bool isSuccess = false;
            try
            {
                Role_master _rolemaster = new Role_master();
                // rolemaster  = new Role_master_model();
                if (rolemaster.roleid > 0)
                {
                    //PUT
                    _rolemaster = _DataContext.rolemaster.Where(d => d.roleid.Equals(rolemaster.roleid)).FirstOrDefault();
                    if (_rolemaster != null)
                    {
                        _rolemaster.roleid = rolemaster.roleid;
                        _rolemaster.rolename = rolemaster.rolename;
                        _rolemaster.flag = rolemaster.flag;
                    }
                }
                else
                {
                    //POST
                    _rolemaster.roleid = rolemaster.roleid;
                    _rolemaster.rolename = rolemaster.rolename;
                    _rolemaster.flag = rolemaster.flag;
                    _DataContext.rolemaster.Add(_rolemaster);
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
