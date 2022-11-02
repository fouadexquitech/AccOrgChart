using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tblRolesFamily")]
    [Index(nameof(RoleFamilyDesc), Name = "IX_tblRolesFamily", IsUnique = true)]
    public partial class TblRolesFamily
    {
        [Key]
        public int RoleFamilyId { get; set; }
        [StringLength(250)]
        public string RoleFamilyDesc { get; set; }
    }
}
