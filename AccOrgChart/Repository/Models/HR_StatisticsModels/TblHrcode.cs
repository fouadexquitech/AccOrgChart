using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    [Table("tblHRCodes")]
    public partial class TblHrcode
    {
        public int Seq { get; set; }
        [Column("codType")]
        public int? CodType { get; set; }
        [Column("codGrp")]
        [StringLength(50)]
        [Unicode(false)]
        public string? CodGrp { get; set; }
        [Column("codDescE")]
        [StringLength(100)]
        public string? CodDescE { get; set; }
    }
}
