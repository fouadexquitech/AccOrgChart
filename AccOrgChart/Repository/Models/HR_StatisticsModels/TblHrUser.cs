using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    [Table("tblHrUsers")]
    public partial class TblHrUser
    {
        [Column("usrID")]
        [StringLength(10)]
        [Unicode(false)]
        public string UsrId { get; set; } = null!;
        [Column("usrDesc")]
        [StringLength(40)]
        [Unicode(false)]
        public string? UsrDesc { get; set; }
        [Column("usrPWD")]
        [StringLength(15)]
        [Unicode(false)]
        public string? UsrPwd { get; set; }
        [Column("usrAdmin")]
        public bool? UsrAdmin { get; set; }
        [Column("usrSTID")]
        public short? UsrStid { get; set; }
        public bool? AllowAccess { get; set; }
        public short? Export { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
    }
}
