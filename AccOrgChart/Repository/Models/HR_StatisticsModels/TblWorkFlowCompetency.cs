using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblWorkFlowCompetencies")]
    public partial class TblWorkFlowCompetency
    {
        [Key]
        [Column("workFlowId")]
        public int WorkFlowId { get; set; }
        [Key]
        [Column("competencyId")]
        public int CompetencyId { get; set; }
        [Column("competencyLevel")]
        public int? CompetencyLevel { get; set; }
    }
}
