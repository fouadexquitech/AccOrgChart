using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrMarketRef")]
    public partial class TblHrMarketRef
    {
        [Key]
        [Column("mrCarrer")]
        [StringLength(150)]
        [Unicode(false)]
        public string MrCarrer { get; set; } = null!;
        [Key]
        [Column("mrLevel")]
        public byte MrLevel { get; set; }
        [Column("mrMarkRef")]
        public int? MrMarkRef { get; set; }
    }
}
