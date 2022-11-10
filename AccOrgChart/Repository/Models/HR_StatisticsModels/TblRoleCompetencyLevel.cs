using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblRoleCompetencyLevel")]
    public partial class TblRoleCompetencyLevel
    {
        [Key]
        [Column("rcRoleId")]
        public int RcRoleId { get; set; }
        [Key]
        [Column("rcCompId")]
        public int RcCompId { get; set; }
        [Column("rcCompLevel")]
        public int? RcCompLevel { get; set; }
    }
}
