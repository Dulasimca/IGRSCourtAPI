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
                            // from b in _DataContext.Responsetype_Masters.Where(x => a.responsetypeid == x.responsetypeid).DefaultIfEmpty()
                        join r in _DataContext.Responsetype_Masters on a.responsetypeid equals r.responsetypeid into _respont
                        from respont in _respont.DefaultIfEmpty()
                        group a by a.responsetypeid into _courtcase
                        orderby _courtcase.Key ascending
                        select new
                        {
                            id = _courtcase.Key > 0 ? _courtcase.Key : 0,
                            count =  _courtcase.Count()
                        }).ToList();
            writ_count = _DataContext.Writappeals_Masters.Count();
            supreme_count = _DataContext.SupremeCourtCase.Count();
            list.Add(new KeyValuePair<string, int>("GOV", 0));
            list.Add(new KeyValuePair<string, int>("IGR", 0));
            list.Add(new KeyValuePair<string, int>("OTHERS", 0));
            list.Add(new KeyValuePair<string, int>("WRIT", writ_count));
            list.Add(new KeyValuePair<string, int>("PENDING", pending_count));
            list.Add(new KeyValuePair<string, int>("SUPREME", supreme_count));
            list.Add(new KeyValuePair<string, int>("TIMEBOUND", timebound_count));
            list.Add(new KeyValuePair<string, int>("LAW", law_count));
            return list;
        }
    }
}
