using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Repository.View_Models
{
    public class ActivityGroup
    {
        public int actGrpSeq { get; set; }
        public string actGrpCode { get; set; }
        public string actGrpDesc { get; set; }
    }
}
