using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Repository.Models.HR_StatisticsModels;

#nullable disable

namespace WebApi.Repository
{
    public partial class HR_StatisticsDbContext : DbContext
    {
        public HR_StatisticsDbContext()
        {
        }

        public HR_StatisticsDbContext(DbContextOptions<HR_StatisticsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActivity> TblActivities { get; set; }
        public virtual DbSet<TblActivityGroup> TblActivityGroups { get; set; }
        public virtual DbSet<TblActivitySub> TblActivitySubs { get; set; }
        public virtual DbSet<TblActivityTask> TblActivityTasks { get; set; }
        public virtual DbSet<TblCode> TblCodes { get; set; }
        public virtual DbSet<TblCompetency> TblCompetencies { get; set; }
        public virtual DbSet<TblCompetencyGroup> TblCompetencyGroups { get; set; }
        public virtual DbSet<TblDatabase> TblDataBases { get; set; }
        public virtual DbSet<TblHrAppRank> TblHrAppRanks { get; set; }
        public virtual DbSet<TblHrAppRankGroup> TblHrAppRankGroups { get; set; }
        public virtual DbSet<TblHrMarketRef> TblHrMarketRefs { get; set; }
        public virtual DbSet<TblHrMasterDataBackup> TblHrMasterDataBackups { get; set; }
        public virtual DbSet<TblHrMasterDatum> TblHrMasterData { get; set; }
        public virtual DbSet<TblHrReport> TblHrReports { get; set; }
        public virtual DbSet<TblHrReportSortBy> TblHrReportSortBies { get; set; }
        public virtual DbSet<TblHrReportsBy> TblHrReportsBies { get; set; }
        public virtual DbSet<TblHrUser> TblHrUsers { get; set; }
        public virtual DbSet<TblHrcode> TblHrcodes { get; set; }
        public virtual DbSet<TblHrtopPerfPercent> TblHrtopPerfPercents { get; set; }
        public virtual DbSet<TblJobWorkFlow> TblJobWorkFlows { get; set; }
        public virtual DbSet<TblRndSel> TblRndSels { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblRoleCompetencyLevel> TblRoleCompetencyLevels { get; set; }
        public virtual DbSet<TblRolesFamily> TblRolesFamilies { get; set; }
        public virtual DbSet<TblSubVerb> TblSubVerbs { get; set; }
        public virtual DbSet<TblTempAppTopPercent> TblTempAppTopPercents { get; set; }
        public virtual DbSet<TblVerb> TblVerbs { get; set; }
        public virtual DbSet<Tmp> Tmps { get; set; }
        public virtual DbSet<TmpHrAppraisal> TmpHrAppraisals { get; set; }
        public virtual DbSet<VwActivity> VwActivities { get; set; }
        public virtual DbSet<VwActivityGroup> VwActivityGroups { get; set; }
        public virtual DbSet<VwActivitySub> VwActivitySubs { get; set; }
        public virtual DbSet<VwCompLevel> VwCompLevels { get; set; }
        public virtual DbSet<VwCompetency> VwCompetencies { get; set; }
        public virtual DbSet<VwCompetencyExpectedLevel> VwCompetencyExpectedLevels { get; set; }
        public virtual DbSet<VwCompetencyRef> VwCompetencyRefs { get; set; }
        public virtual DbSet<VwComplexityLevel> VwComplexityLevels { get; set; }
        public virtual DbSet<VwFrequencyAction> VwFrequencyActions { get; set; }
        public virtual DbSet<VwJob> VwJobs { get; set; }
        public virtual DbSet<VwJobWorkFlow> VwJobWorkFlows { get; set; }
        public virtual DbSet<VwRaci> VwRacis { get; set; }
        public virtual DbSet<VwVerb> VwVerbs { get; set; }
        public virtual DbSet<VwWayToDevelopCpt> VwWayToDevelopCpts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ABEDHIJAZI;Initial Catalog=HR_Statistics;Persist Security Info=True;User ID=accdb;Password=db@TSs15;Integrated Security=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1256_CI_AS");

            modelBuilder.Entity<TblActivity>(entity =>
            {
                entity.HasKey(e => new { e.ActSeq, e.ActGrpId })
                    .HasName("PK_tblActivites");

                entity.Property(e => e.ActSeq).ValueGeneratedOnAdd();

                entity.Property(e => e.ActCode).IsUnicode(false);

                entity.Property(e => e.ActDesc).IsUnicode(false);

                entity.Property(e => e.ActSort).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblActivityGroup>(entity =>
            {
                entity.Property(e => e.ActGrpCode).IsUnicode(false);

                entity.Property(e => e.ActGrpDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblActivitySub>(entity =>
            {
                entity.HasKey(e => new { e.SacSeq, e.ActId })
                    .HasName("PK_tblActivitiesSub");

                entity.Property(e => e.SacSeq).ValueGeneratedOnAdd();

                entity.Property(e => e.SacCode).IsUnicode(false);

                entity.Property(e => e.SacDesc).IsUnicode(false);

                entity.Property(e => e.SacSort).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblActivityTask>(entity =>
            {
                entity.HasKey(e => new { e.TskSeq, e.SubActId })
                    .HasName("PK_tblActivitiesTask");

                entity.Property(e => e.TskSeq).ValueGeneratedOnAdd();

                entity.Property(e => e.TskCode).IsUnicode(false);

                entity.Property(e => e.TskDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblCode>(entity =>
            {
                entity.HasKey(e => e.Seq)
                    .HasName("PK_TblCodes");

                entity.Property(e => e.CodAuxiliaryCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.CodSort).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblCompetency>(entity =>
            {
                entity.Property(e => e.CompCode).IsUnicode(false);

                entity.Property(e => e.CompDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblCompetencyGroup>(entity =>
            {
                entity.Property(e => e.ComgDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblDatabase>(entity =>
            {
                entity.Property(e => e.DbConnection).IsUnicode(false);

                entity.Property(e => e.DbDescription).IsUnicode(false);

                entity.Property(e => e.DbLocation).IsUnicode(false);

                entity.Property(e => e.DbName).IsUnicode(false);

                entity.Property(e => e.DbServer).IsUnicode(false);

                entity.Property(e => e.DbUserId).IsUnicode(false);

                entity.Property(e => e.SsrsDomain).IsUnicode(false);

                entity.Property(e => e.SsrsPass).IsUnicode(false);

                entity.Property(e => e.SsrsServer).IsUnicode(false);

                entity.Property(e => e.SsrsUser).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrAppRank>(entity =>
            {
                entity.HasKey(e => new { e.EmplNumber, e.AppRankYear });

                entity.Property(e => e.EmplNumber).IsUnicode(false);

                entity.Property(e => e.AppGroup).IsUnicode(false);

                entity.Property(e => e.AppValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.RankGroup).IsUnicode(false);

                entity.Property(e => e.RankValue).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblHrAppRankGroup>(entity =>
            {
                entity.HasKey(e => e.GrpDesc)
                    .HasName("PK_tblHrAppGroup");

                entity.Property(e => e.GrpDesc).IsUnicode(false);

                entity.Property(e => e.Seq).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblHrMarketRef>(entity =>
            {
                entity.HasKey(e => new { e.MrCarrer, e.MrLevel });

                entity.Property(e => e.MrCarrer).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrMasterDataBackup>(entity =>
            {
                entity.Property(e => e.EmplNumber).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrMasterDatum>(entity =>
            {
                entity.HasKey(e => e.EmplNumber)
                    .HasName("PK_tblHrMasterData_1");

                entity.Property(e => e.EmplNumber).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrReport>(entity =>
            {
                entity.Property(e => e.RptSeq).ValueGeneratedNever();

                entity.Property(e => e.RptDesc).IsUnicode(false);

                entity.Property(e => e.RptObject).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrReportSortBy>(entity =>
            {
                entity.HasKey(e => new { e.BySeq, e.SortSeq });

                entity.Property(e => e.SortSeq).ValueGeneratedOnAdd();

                entity.Property(e => e.SortDesc).IsUnicode(false);

                entity.Property(e => e.SortValue).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrReportsBy>(entity =>
            {
                entity.HasKey(e => new { e.ReportNo, e.BySeq });

                entity.Property(e => e.ByDesc).IsUnicode(false);

                entity.Property(e => e.ByDesignVisible).HasDefaultValueSql("((0))");

                entity.Property(e => e.ByField).IsUnicode(false);

                entity.Property(e => e.ByRptObject).IsUnicode(false);

                entity.Property(e => e.ByRptTittle).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrUser>(entity =>
            {
                entity.Property(e => e.UsrDesc).IsUnicode(false);

                entity.Property(e => e.UsrId).IsUnicode(false);

                entity.Property(e => e.UsrPwd).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrcode>(entity =>
            {
                entity.Property(e => e.CodGrp).IsUnicode(false);
            });

            modelBuilder.Entity<TblHrtopPerfPercent>(entity =>
            {
                entity.Property(e => e.PercentDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblJobWorkFlow>(entity =>
            {
                entity.HasKey(e => e.JwId)
                    .HasName("PK_tblJobTasks");

                entity.Property(e => e.InsertedBy).IsUnicode(false);

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JwParentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwRaci).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwSort).IsUnicode(false);

                entity.Property(e => e.JwSubWorkFlowCode).IsUnicode(false);

                entity.Property(e => e.JwVerb).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwWorkFlowCode).IsUnicode(false);

                entity.Property(e => e.JwWorkFlowRoleCode).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TblRndSel>(entity =>
            {
                entity.HasKey(e => new { e.RnsRnd, e.RnsWho, e.RnsUser });

                entity.Property(e => e.Seq).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.Property(e => e.RoleDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblRoleCompetencyLevel>(entity =>
            {
                entity.HasKey(e => new { e.RcRoleId, e.RcCompId });
            });

            modelBuilder.Entity<TblRolesFamily>(entity =>
            {
                entity.Property(e => e.RoleFamilyDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblSubVerb>(entity =>
            {
                entity.HasKey(e => e.SubVerbId)
                    .HasName("PK_tblSubVerb");

                entity.Property(e => e.SubVerbDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TblTempAppTopPercent>(entity =>
            {
                entity.HasKey(e => new { e.Seq, e.EmplNumber, e.UserName });

                entity.Property(e => e.EmplNumber).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.AppGroup).IsUnicode(false);

                entity.Property(e => e.CareerBand).IsUnicode(false);

                entity.Property(e => e.CurrentPosition).IsUnicode(false);

                entity.Property(e => e.Degree).IsUnicode(false);

                entity.Property(e => e.Dept).IsUnicode(false);

                entity.Property(e => e.Designation).IsUnicode(false);

                entity.Property(e => e.Educationlevel).IsUnicode(false);

                entity.Property(e => e.GrpBy).IsUnicode(false);

                entity.Property(e => e.JobFamily).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Nationality).IsUnicode(false);

                entity.Property(e => e.RankGroup).IsUnicode(false);
            });

            modelBuilder.Entity<TblVerb>(entity =>
            {
                entity.Property(e => e.VerbDesc).IsUnicode(false);
            });

            modelBuilder.Entity<Tmp>(entity =>
            {
                entity.Property(e => e.Act).IsUnicode(false);

                entity.Property(e => e.ActGrp).IsUnicode(false);

                entity.Property(e => e.ActGrpId).IsUnicode(false);

                entity.Property(e => e.ActId).IsUnicode(false);

                entity.Property(e => e.Job).IsUnicode(false);

                entity.Property(e => e.JobId).IsUnicode(false);

                entity.Property(e => e.SubAct).IsUnicode(false);

                entity.Property(e => e.T6).IsUnicode(false);

                entity.Property(e => e.T7).IsUnicode(false);

                entity.Property(e => e.Task).IsUnicode(false);

                entity.Property(e => e.TaskId).IsUnicode(false);
            });

            modelBuilder.Entity<TmpHrAppraisal>(entity =>
            {
                entity.HasKey(e => e.EmplNumber)
                    .HasName("PK_tblHrAppraisal");

                entity.Property(e => e.EmplNumber).IsUnicode(false);
            });

            modelBuilder.Entity<VwActivity>(entity =>
            {
                entity.ToView("vwActivities");

                entity.Property(e => e.ActDesc).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdDesc).IsUnicode(false);
            });

            modelBuilder.Entity<VwActivityGroup>(entity =>
            {
                entity.ToView("vwActivityGroup");

                entity.Property(e => e.ActGrpCode).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdDesc).IsUnicode(false);
            });

            modelBuilder.Entity<VwActivitySub>(entity =>
            {
                entity.ToView("vwActivitySub");

                entity.Property(e => e.IdDesc).IsUnicode(false);

                entity.Property(e => e.SacCode).IsUnicode(false);
            });

            modelBuilder.Entity<VwCompLevel>(entity =>
            {
                entity.ToView("vwCompLevel");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwCompetency>(entity =>
            {
                entity.ToView("vwCompetencies");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwCompetencyExpectedLevel>(entity =>
            {
                entity.ToView("vwCompetencyExpectedLevel");

                entity.Property(e => e.CodDesc).IsUnicode(false);
            });

            modelBuilder.Entity<VwCompetencyRef>(entity =>
            {
                entity.ToView("vwCompetencyRef");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.CompCode).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwComplexityLevel>(entity =>
            {
                entity.ToView("vwComplexityLevel");

                entity.Property(e => e.CodDesc).IsUnicode(false);
            });

            modelBuilder.Entity<VwFrequencyAction>(entity =>
            {
                entity.ToView("vwFrequencyAction");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwJob>(entity =>
            {
                entity.ToView("vwJobs");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwJobWorkFlow>(entity =>
            {
                entity.ToView("vwJobWorkFlow");

                entity.Property(e => e.Activity).IsUnicode(false);

                entity.Property(e => e.ActivityGroup).IsUnicode(false);

                entity.Property(e => e.InsertedBy).IsUnicode(false);

                entity.Property(e => e.JwSort).IsUnicode(false);

                entity.Property(e => e.JwSubWorkFlowCode).IsUnicode(false);

                entity.Property(e => e.JwWorkFlowCode).IsUnicode(false);

                entity.Property(e => e.JwWorkFlowRoleCode).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.SubActivity).IsUnicode(false);

                entity.Property(e => e.Task).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<VwRaci>(entity =>
            {
                entity.ToView("vwRACI");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwVerb>(entity =>
            {
                entity.ToView("vwVerbs");

                entity.Property(e => e.CodDesc).IsUnicode(false);
            });

            modelBuilder.Entity<VwWayToDevelopCpt>(entity =>
            {
                entity.ToView("vwWayToDevelopCpt");

                entity.Property(e => e.CodDesc).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
