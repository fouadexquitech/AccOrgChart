using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblCompetencyGroup")]
    [Index(nameof(ComgDesc), Name = "IX_tblCompetencyGroup", IsUnique = true)]
    public partial class TblCompetencyGroup
    {
        [Key]
        [Column("comgId")]
        public int ComgId { get; set; }
        [Column("comgDesc")]
        [StringLength(500)]
        public string ComgDesc { get; set; }
    }
}
