using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblActivityTask")]
    public partial class TblActivityTask
    {
        [Key]
        [Column("tskSeq")]
        public int TskSeq { get; set; }
        [Key]
        [Column("subActID")]
        public int SubActId { get; set; }
        [Column("tskCode")]
        [StringLength(50)]
        public string TskCode { get; set; }
        [Column("tskDesc")]
        [StringLength(500)]
        public string TskDesc { get; set; }
        [Column("tskSort")]
        public int? TskSort { get; set; }
    }
}
