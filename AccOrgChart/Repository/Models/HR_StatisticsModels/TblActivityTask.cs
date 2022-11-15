using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblActivityTask")]
    public partial class TblActivityTask
    {
        [Key]
        [Column("tskSeq")]
        public int TskSeq { get; set; }
        [Column("subActID")]
        public int? SubActId { get; set; }
        [Column("tskCode")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TskCode { get; set; }
        [Column("tskDesc")]
        [StringLength(500)]
        [Unicode(false)]
        public string? TskDesc { get; set; }
        [Column("tskSort")]
        public int? TskSort { get; set; }
    }
}
