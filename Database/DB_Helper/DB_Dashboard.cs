using Azure;
using IGRSCourtAPI.Common;
using IGRSCourtAPI.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace IGRSCourtAPI.Database.DB_Helper
{
    public class DB_Dashboard
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_Dashboard(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public List<KeyValuePair<string, int>> GetCount()
        {
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            int writ_count = 0, pending_count = 0, supreme_count = 0, timebound_count = 0, law_count = 0;
            var temp = (from a in _DataContext.Courtcases
                         group a by a.responsetypeid into _courtcase
                        select new
                        {
                            id = _courtcase.Key > 0 ? _courtcase.Key : 0,
                            count = _courtcase.Key > 0 ? _courtcase.Count() : 0
                        }).ToList();
            writ_count = _DataContext.Writappeals_Masters.Count();
            supreme_count = _DataContext.SupremeCourtCase.Count();
            list.Add(new KeyValuePair<string, int>("GOV", temp.Where(a=>a.id ==1).FirstOrDefault() == null? 0 : temp.Where(a => a.id == 1).FirstOrDefault().count));
            list.Add(new KeyValuePair<string, int>("IGR", temp.Where(a => a.id == 2).FirstOrDefault()== null ? 0 : temp.Where(a => a.id == 2).FirstOrDefault().count));
            list.Add(new KeyValuePair<string, int>("OTHERS", temp.Where(a => a.id == 3).FirstOrDefault()==null ?0 : temp.Where(a => a.id == 3).FirstOrDefault().count));
            list.Add(new KeyValuePair<string, int>("WRIT", writ_count));
            list.Add(new KeyValuePair<string, int>("PENDING", pending_count));
            list.Add(new KeyValuePair<string, int>("SUPREME", supreme_count));
            list.Add(new KeyValuePair<string, int>("TIMEBOUND", timebound_count));
            list.Add(new KeyValuePair<string, int>("LAW", law_count));
            return list;
        }
    }
}
