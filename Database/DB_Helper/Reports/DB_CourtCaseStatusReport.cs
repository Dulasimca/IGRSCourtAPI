using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGRSCourtAPI.Model.Reports;
using IGRSCourtAPI.Database;

namespace IGRSCourtAPI.Database.DB_Helper.Reports
{
    public class DB_CourtCaseStatusReport
    {
        private EF_IGRSCC_DataContext _DataContext;

        public DB_CourtCaseStatusReport(EF_IGRSCC_DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public List<CourtCaseStatusReport_Model> GetCourtCaseStatusReport(string _fromdate, string _todate)
        {
            //var temp = (from a in _DataContext.Courtcases
            //            join z in _DataContext.Zone_Masters on a.zoneid equals z.zoneid
            //            join c in _DataContext.counterfiledmaster on a.counterfiledid equals c.counterfiledid
            //            ).ToList().GroupBy(g=> new { g.zonename,g.counterfiledname })
            //            .Select 
            //            select new
            //            {
            //                id = _courtcase.Key > 0 ? _courtcase.Key : 0,
            //                count = _courtcase.Key > 0 ? _courtcase.Count() : 0
            //            }).ToList();
            return null;
        }
    }
}
