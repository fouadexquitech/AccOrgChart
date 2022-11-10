using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrReportSortBy")]
    public partial class TblHrReportSortBy
    {
        [Key]
        [Column("bySeq")]
        public byte BySeq { get; set; }
        [Key]
        public byte SortSeq { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? SortDesc { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? SortValue { get; set; }
    }
}
