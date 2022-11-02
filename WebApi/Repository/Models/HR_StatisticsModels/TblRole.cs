using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tblRoles")]
    [Index(nameof(RoleDesc), Name = "IX_tblRoles", IsUnique = true)]
    public partial class TblRole
    {
        [Key]
        [Column("roleId")]
        public int RoleId { get; set; }
        [Column("familyId")]
        public int? FamilyId { get; set; }
        [Column("roleDesc")]
        [StringLength(150)]
        public string RoleDesc { get; set; }
    }
}
