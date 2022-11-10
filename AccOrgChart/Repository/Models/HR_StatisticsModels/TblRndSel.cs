using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblRndSel")]
    [Index("RnsSel", Name = "IX_tblRndSel")]
    public partial class TblRndSel
    {
        public int Seq { get; set; }
        [Key]
        [Column("rnsRnd")]
        [StringLength(200)]
        public string RnsRnd { get; set; } = null!;
        [Key]
        [Column("rnsWho")]
        public short RnsWho { get; set; }
        [Key]
        [Column("rnsUser")]
        [StringLength(10)]
        public string RnsUser { get; set; } = null!;
        [Column("rnsCod")]
        [StringLength(200)]
        public string? RnsCod { get; set; }
        [Column("rnsDsc")]
        [StringLength(200)]
        public string? RnsDsc { get; set; }
        [Column("rnsSel")]
        public bool? RnsSel { get; set; }
        [Column("rnsDiv")]
        [StringLength(30)]
        public string? RnsDiv { get; set; }
        [Column("rnsSubDiv")]
        [StringLength(30)]
        public string? RnsSubDiv { get; set; }
        [Column("rnsTrade")]
        [StringLength(50)]
        public string? RnsTrade { get; set; }
        [Column("rnsSubTrade")]
        [StringLength(30)]
        public string? RnsSubTrade { get; set; }
    }
}
