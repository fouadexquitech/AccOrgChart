using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AccOrgChart.Repository.View_Models
{
    public class ActivityTask
    {
        public int tskSeq { get; set; }
        public int subActId { get; set; }
        public string tskCode { get; set; }
        public string tskDesc { get; set; }
        public int? tskSort { get; set; }
    }
}
