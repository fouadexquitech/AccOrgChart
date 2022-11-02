using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblCompetencies")]
    [Index(nameof(CompDesc), Name = "IX_tblCompetencies", IsUnique = true)]
    public partial class TblCompetency
    {
        [Key]
        [Column("compId")]
        public int CompId { get; set; }
        [Column("compGroupId")]
        public int? CompGroupId { get; set; }
        [Column("compCode")]
        [StringLength(250)]
        public string CompCode { get; set; }
        [Column("compDesc")]
        [StringLength(500)]
        public string CompDesc { get; set; }
    }
}
