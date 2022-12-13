using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Model
{
    public class Menu_Model
    {
        public int menuid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int parentid { get; set; }
        public string icon { get; set; }
        public int roleid { get; set; }
        public bool isactive { get; set; }
        public int priorities { get; set; }
        public string  rolename { get; set; }

    }

    public class Menu
    {
        public int ID { get; set; }
        public string label { get; set; }
        public string routerLink { get; set; }
        public int parentId { get; set; }
        public string icon { get; set; }
        public int RoleId { get; set; }
        public bool isActive { get; set; }
        public int Priorities { get; set; }
        public List<Menu> items { get; set; }

}
}
