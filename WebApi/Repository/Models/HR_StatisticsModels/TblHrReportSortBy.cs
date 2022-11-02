using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
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
        public string SortDesc { get; set; }
        [StringLength(100)]
        public string SortValue { get; set; }
    }
}
