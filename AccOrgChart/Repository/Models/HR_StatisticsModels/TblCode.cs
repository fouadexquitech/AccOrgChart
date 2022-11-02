using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("TblCode")]
    public partial class TblCode
    {
        [Key]
        public int Seq { get; set; }
        [Column("codType")]
        public int? CodType { get; set; }
        [Column("codGroup")]
        public int? CodGroup { get; set; }
        [Column("codNum")]
        public int? CodNum { get; set; }
        [Column("codDesc")]
        public string CodDesc { get; set; }
        [Column("codAbv")]
        [StringLength(100)]
        public string CodAbv { get; set; }
        [Column("LUser")]
        [StringLength(10)]
        public string Luser { get; set; }
        [Column("LDate", TypeName = "datetime")]
        public DateTime? Ldate { get; set; }
        [Column("codColNo")]
        public byte? CodColNo { get; set; }
        public byte? Export { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [Column("codSpecialFilter")]
        [StringLength(50)]
        public string CodSpecialFilter { get; set; }
        [Column("codAuxiliaryCost")]
        public byte? CodAuxiliaryCost { get; set; }
        [Column("codCategory")]
        public int? CodCategory { get; set; }
        [Column("codCategoryType")]
        public int? CodCategoryType { get; set; }
        [Column("codSort")]
        public int? CodSort { get; set; }
    }
}
