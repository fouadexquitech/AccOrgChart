using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tmp")]
    public partial class Tmp
    {
        [Unicode(false)]
        public string? Job { get; set; }
        [Column("JobID")]
        [Unicode(false)]
        public string? JobId { get; set; }
        [Unicode(false)]
        public string? ActGrp { get; set; }
        [Column("ActGrpID")]
        [Unicode(false)]
        public string? ActGrpId { get; set; }
        [Unicode(false)]
        public string? Act { get; set; }
        [Column("ActID")]
        [Unicode(false)]
        public string? ActId { get; set; }
        [Unicode(false)]
        public string? SubAct { get; set; }
        [Column("subActId")]
        [Unicode(false)]
        public string? SubActId { get; set; }
        [Unicode(false)]
        public string? Task { get; set; }
        [Column("TaskID")]
        [Unicode(false)]
        public string? TaskId { get; set; }
        [Unicode(false)]
        public string? T6 { get; set; }
        [Unicode(false)]
        public string? T7 { get; set; }
        [Key]
        [Column("seq1")]
        public int Seq1 { get; set; }
    }
}
