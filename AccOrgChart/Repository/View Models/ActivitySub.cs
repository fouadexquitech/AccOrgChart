using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AccOrgChart.Repository.View_Models
{
    public class ActivitySub
    {
            public int sacSeq { get; set; }
            public int actId { get; set; }
            public string sacCode { get; set; }
            public string sacDesc { get; set; }
            public int? sacSort { get; set; }
        
    }
}
