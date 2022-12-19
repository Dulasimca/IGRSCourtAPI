using IGRSCourtAPI.Model;
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
            int gov_count = 0, igr_count = 0, others_count = 0;
            var fromTable = _DataContext.Courtcases.ToList();
            fromTable.ForEach(row =>
            {
                if (row.responsetypeid == 1 && !row.counterfiled)
                {
                    gov_count++;
                }
                else if (row.responsetypeid == 2)
                {
                    igr_count++;
                }
                else if (row.responsetypeid == 3)
                {
                    others_count++;
                }
            });
            list.Add(new KeyValuePair<string, int>("GOVT Respondent", gov_count));
            list.Add(new KeyValuePair<string, int>("IGR Respondent", igr_count));
            list.Add(new KeyValuePair<string, int>("OTHERS Respondent", others_count));
            list.Add(new KeyValuePair<string, int>("Pending with G.P for vetting", 0));
            return list;
        }
    }
}
