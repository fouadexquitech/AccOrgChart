using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    [Table("tblDataBases")]
    public partial class TblDatabase
    {
        [Column("dbName")]
        [StringLength(50)]
        [Unicode(false)]
        public string DbName { get; set; } = null!;
        [Column("dbDescription")]
        [StringLength(50)]
        [Unicode(false)]
        public string DbDescription { get; set; } = null!;
        [Column("dbConnection")]
        [StringLength(150)]
        [Unicode(false)]
        public string? DbConnection { get; set; }
        [Column("dbServer")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DbServer { get; set; }
        [Column("dbActive")]
        public byte? DbActive { get; set; }
        [Column("dbUserID")]
        [StringLength(20)]
        [Unicode(false)]
        public string? DbUserId { get; set; }
        [Column("dbPass")]
        [StringLength(20)]
        public string? DbPass { get; set; }
        [Column("SSRS_Server")]
        [StringLength(100)]
        [Unicode(false)]
        public string? SsrsServer { get; set; }
        [Column("SSRS_User")]
        [StringLength(20)]
        [Unicode(false)]
        public string? SsrsUser { get; set; }
        [Column("SSRS_Pass")]
        [StringLength(20)]
        [Unicode(false)]
        public string? SsrsPass { get; set; }
        [Column("SSRS_Domain")]
        [StringLength(20)]
        [Unicode(false)]
        public string? SsrsDomain { get; set; }
        [Column("dbLocation")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DbLocation { get; set; }
    }
}
