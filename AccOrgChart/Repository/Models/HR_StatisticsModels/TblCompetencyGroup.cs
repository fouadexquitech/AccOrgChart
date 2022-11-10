using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblCompetencyGroup")]
    [Index("ComgDesc", Name = "IX_tblCompetencyGroup", IsUnique = true)]
    public partial class TblCompetencyGroup
    {
        [Key]
        [Column("comgId")]
        public int ComgId { get; set; }
        [Column("comgDesc")]
        [StringLength(500)]
        [Unicode(false)]
        public string? ComgDesc { get; set; }
    }
}
