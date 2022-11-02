using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblVerbs")]
    [Index(nameof(VerbDesc), Name = "IX_tblVerbs", IsUnique = true)]
    public partial class TblVerb
    {
        [Key]
        [Column("verbId")]
        public int VerbId { get; set; }
        [Column("verbDesc")]
        [StringLength(150)]
        public string VerbDesc { get; set; }
    }
}
