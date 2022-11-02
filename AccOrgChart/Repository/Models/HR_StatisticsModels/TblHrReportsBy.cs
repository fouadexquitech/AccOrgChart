using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrReportsBy")]
    public partial class TblHrReportsBy
    {
        [Key]
        public byte ReportNo { get; set; }
        [Key]
        [Column("bySeq")]
        public byte BySeq { get; set; }
        [Column("byDesc")]
        [StringLength(50)]
        public string ByDesc { get; set; }
        [Column("byRptObject")]
        [StringLength(150)]
        public string ByRptObject { get; set; }
        [Column("byRptTittle")]
        [StringLength(150)]
        public string ByRptTittle { get; set; }
        [Column("byDesignVisible")]
        public byte? ByDesignVisible { get; set; }
        [Column("byField")]
        [StringLength(30)]
        public string ByField { get; set; }
    }
}
