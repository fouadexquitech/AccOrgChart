using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblVerbs")]
    [Index("VerbDesc", Name = "IX_tblVerbs", IsUnique = true)]
    public partial class TblVerb
    {
        [Key]
        [Column("verbId")]
        public int VerbId { get; set; }
        [Column("verbDesc")]
        [StringLength(150)]
        [Unicode(false)]
        public string? VerbDesc { get; set; }
    }
}
