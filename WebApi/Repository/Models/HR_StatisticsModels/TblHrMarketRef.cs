using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrMarketRef")]
    public partial class TblHrMarketRef
    {
        [Key]
        [Column("mrCarrer")]
        [StringLength(150)]
        public string MrCarrer { get; set; }
        [Key]
        [Column("mrLevel")]
        public byte MrLevel { get; set; }
        [Column("mrMarkRef")]
        public int? MrMarkRef { get; set; }
    }
}
