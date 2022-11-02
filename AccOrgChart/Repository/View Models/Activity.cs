using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AccOrgChart.Repository.View_Models
{
    public class Activities
    {
        public int actSeq { get; set; }
        public int actGrpId { get; set; }
        public string actCode { get; set; }
        public string actDesc { get; set; }
        public int? actSort { get; set; }
    }
}
