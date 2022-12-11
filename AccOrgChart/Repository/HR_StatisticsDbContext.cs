using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AccOrgChart.Repository.Models.HR_StatisticsModels;

namespace AccOrgChart.Repository
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

        public virtual DbSet<TblActivity> TblActivities { get; set; } = null!;
        public virtual DbSet<TblActivityGroup> TblActivityGroups { get; set; } = null!;
        public virtual DbSet<TblActivitySub> TblActivitySubs { get; set; } = null!;
        public virtual DbSet<TblActivityTask> TblActivityTasks { get; set; } = null!;
        public virtual DbSet<TblCode> TblCodes { get; set; } = null!;
        public virtual DbSet<TblCompetency> TblCompetencies { get; set; } = null!;
        public virtual DbSet<TblCompetencyGroup> TblCompetencyGroups { get; set; } = null!;
        public virtual DbSet<TblDatabase> TblDataBases { get; set; } = null!;
        public virtual DbSet<TblHrAppRank> TblHrAppRanks { get; set; } = null!;
        public virtual DbSet<TblHrAppRankGroup> TblHrAppRankGroups { get; set; } = null!;
        public virtual DbSet<TblHrMarketRef> TblHrMarketRefs { get; set; } = null!;
        public virtual DbSet<TblHrMasterDataBackup> TblHrMasterDataBackups { get; set; } = null!;
        public virtual DbSet<TblHrMasterDatum> TblHrMasterData { get; set; } = null!;
        public virtual DbSet<TblHrReport> TblHrReports { get; set; } = null!;
        public virtual DbSet<TblHrReportSortBy> TblHrReportSortBies { get; set; } = null!;
        public virtual DbSet<TblHrReportsBy> TblHrReportsBies { get; set; } = null!;
        public virtual DbSet<TblHrUser> TblHrUsers { get; set; } = null!;
        public virtual DbSet<TblHrcode> TblHrcodes { get; set; } = null!;
        public virtual DbSet<TblHrtopPerfPercent> TblHrtopPerfPercents { get; set; } = null!;
        public virtual DbSet<TblJobWorkFlow> TblJobWorkFlows { get; set; } = null!;
        public virtual DbSet<TblPermGrpUsr> TblPermGrpUsrs { get; set; } = null!;
        public virtual DbSet<TblRndSel> TblRndSels { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblRoleCompetencyLevel> TblRoleCompetencyLevels { get; set; } = null!;
        public virtual DbSet<TblRolesFamily> TblRolesFamilies { get; set; } = null!;
        public virtual DbSet<TblSubVerb> TblSubVerbs { get; set; } = null!;
        public virtual DbSet<TblTempAppTopPercent> TblTempAppTopPercents { get; set; } = null!;
        public virtual DbSet<TblVerb> TblVerbs { get; set; } = null!;
        public virtual DbSet<TblWorkFlowCompetency> TblWorkFlowCompetencies { get; set; } = null!;
        public virtual DbSet<Tmp> Tmps { get; set; } = null!;
        public virtual DbSet<TmpHrAppraisal> TmpHrAppraisals { get; set; } = null!;
        public virtual DbSet<VwActivity> VwActivities { get; set; } = null!;
        public virtual DbSet<VwActivityGroup> VwActivityGroups { get; set; } = null!;
        public virtual DbSet<VwActivitySub> VwActivitySubs { get; set; } = null!;
        public virtual DbSet<VwCompLevel> VwCompLevels { get; set; } = null!;
        public virtual DbSet<VwCompetency> VwCompetencies { get; set; } = null!;
        public virtual DbSet<VwCompetencyExpectedLevel> VwCompetencyExpectedLevels { get; set; } = null!;
        public virtual DbSet<VwComplexityLevel> VwComplexityLevels { get; set; } = null!;
        public virtual DbSet<VwFrequencyAction> VwFrequencyActions { get; set; } = null!;
        public virtual DbSet<VwJob> VwJobs { get; set; } = null!;
        public virtual DbSet<VwJobWorkFlow> VwJobWorkFlows { get; set; } = null!;
        public virtual DbSet<VwRaci> VwRacis { get; set; } = null!;
        public virtual DbSet<VwVerb> VwVerbs { get; set; } = null!;
        public virtual DbSet<VwWayToDevelopCpt> VwWayToDevelopCpts { get; set; } = null!;

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
            modelBuilder.Entity<TblActivity>(entity =>
            {
                entity.HasKey(e => new { e.ActSeq, e.ActGrpId })
                    .HasName("PK_tblActivites");

                entity.Property(e => e.ActSeq).ValueGeneratedOnAdd();

                entity.Property(e => e.ActSort).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblActivitySub>(entity =>
            {
                entity.HasKey(e => new { e.SacSeq, e.ActId })
                    .HasName("PK_tblActivitiesSub");

                entity.Property(e => e.SacSeq).ValueGeneratedOnAdd();

                entity.Property(e => e.Insertdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsProposed).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProposedApproved).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProposedNew).HasDefaultValueSql("((0))");

                entity.Property(e => e.SacSort).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblActivityTask>(entity =>
            {
                entity.Property(e => e.Insertdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsProposed).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkFlowId).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblCode>(entity =>
            {
                entity.HasKey(e => e.Seq)
                    .HasName("PK_TblCodes");

                entity.Property(e => e.CodAuxiliaryCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.CodSort).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblHrAppRank>(entity =>
            {
                entity.HasKey(e => new { e.EmplNumber, e.AppRankYear });

                entity.Property(e => e.AppValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.RankValue).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblHrAppRankGroup>(entity =>
            {
                entity.HasKey(e => e.GrpDesc)
                    .HasName("PK_tblHrAppGroup");

                entity.Property(e => e.Seq).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblHrMarketRef>(entity =>
            {
                entity.HasKey(e => new { e.MrCarrer, e.MrLevel });
            });

            modelBuilder.Entity<TblHrMasterDatum>(entity =>
            {
                entity.HasKey(e => e.EmplNumber)
                    .HasName("PK_tblHrMasterData_1");
            });

            modelBuilder.Entity<TblHrReport>(entity =>
            {
                entity.Property(e => e.RptSeq).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblHrReportSortBy>(entity =>
            {
                entity.HasKey(e => new { e.BySeq, e.SortSeq });

                entity.Property(e => e.SortSeq).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblHrReportsBy>(entity =>
            {
                entity.HasKey(e => new { e.ReportNo, e.BySeq });

                entity.Property(e => e.ByDesignVisible).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblJobWorkFlow>(entity =>
            {
                entity.HasKey(e => e.JwId)
                    .HasName("PK_tblJobTasks");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JwParentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwParentSubActivity).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwProposedAction).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwProposedApproved).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwProposedJobId).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwProposedNew).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwProposedTaskId).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwRaci).HasDefaultValueSql("((0))");

                entity.Property(e => e.JwVerb).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblPermGrpUsr>(entity =>
            {
                entity.Property(e => e.MinOfprmDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOfprmRead).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOfprmUpdPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOfprmUpdate).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOfprmWrite).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblRndSel>(entity =>
            {
                entity.HasKey(e => new { e.RnsRnd, e.RnsWho, e.RnsUser });

                entity.Property(e => e.Seq).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblRoleCompetencyLevel>(entity =>
            {
                entity.HasKey(e => new { e.RcRoleId, e.RcCompId });
            });

            modelBuilder.Entity<TblSubVerb>(entity =>
            {
                entity.HasKey(e => e.SubVerbId)
                    .HasName("PK_tblSubVerb");
            });

            modelBuilder.Entity<TblTempAppTopPercent>(entity =>
            {
                entity.HasKey(e => new { e.Seq, e.EmplNumber, e.UserName });
            });

            modelBuilder.Entity<TblWorkFlowCompetency>(entity =>
            {
                entity.HasKey(e => new { e.WorkFlowId, e.CompetencyId });
            });

            modelBuilder.Entity<TmpHrAppraisal>(entity =>
            {
                entity.HasKey(e => e.EmplNumber)
                    .HasName("PK_tblHrAppraisal");
            });

            modelBuilder.Entity<VwActivity>(entity =>
            {
                entity.ToView("vwActivities");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwActivityGroup>(entity =>
            {
                entity.ToView("vwActivityGroup");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwActivitySub>(entity =>
            {
                entity.ToView("vwActivitySub");
            });

            modelBuilder.Entity<VwCompLevel>(entity =>
            {
                entity.ToView("vwCompLevel");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwCompetency>(entity =>
            {
                entity.ToView("vwCompetency");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwCompetencyExpectedLevel>(entity =>
            {
                entity.ToView("vwCompetencyExpectedLevel");
            });

            modelBuilder.Entity<VwComplexityLevel>(entity =>
            {
                entity.ToView("vwComplexityLevel");
            });

            modelBuilder.Entity<VwFrequencyAction>(entity =>
            {
                entity.ToView("vwFrequencyAction");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwJob>(entity =>
            {
                entity.ToView("vwJobs");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwJobWorkFlow>(entity =>
            {
                entity.ToView("vwJobWorkFlow");
            });

            modelBuilder.Entity<VwRaci>(entity =>
            {
                entity.ToView("vwRACI");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwVerb>(entity =>
            {
                entity.ToView("vwVerbs");
            });

            modelBuilder.Entity<VwWayToDevelopCpt>(entity =>
            {
                entity.ToView("vwWayToDevelopCpt");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
