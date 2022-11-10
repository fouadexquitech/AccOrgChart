using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrReports")]
    public partial class TblHrReport
    {
        [Key]
        [Column("rptSeq")]
        public short RptSeq { get; set; }
        [Column("rptDesc")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RptDesc { get; set; }
        [Column("rptObject")]
        [StringLength(30)]
        [Unicode(false)]
        public string? RptObject { get; set; }
        [Column("rptHasColumns")]
        public byte? RptHasColumns { get; set; }
        public byte? PermissionExcept { get; set; }
        [Column("rptRunSSRS")]
        public byte? RptRunSsrs { get; set; }
        [Column("rptIsDynamicCol")]
        public byte? RptIsDynamicCol { get; set; }
        [Column("rptFixSpace")]
        public double? RptFixSpace { get; set; }
    }
}
