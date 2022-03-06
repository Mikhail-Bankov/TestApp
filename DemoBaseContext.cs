using Microsoft.EntityFrameworkCore;

namespace TestApp
{
    public partial class DemoBaseContext : DbContext
    {
        public DemoBaseContext()
        {
        }

        public DemoBaseContext(DbContextOptions<DemoBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DsAttribute> DsAttributes { get; set; }
        public virtual DbSet<DsLinkType> DsLinkTypes { get; set; }
        public virtual DbSet<DsState> DsStates { get; set; }
        public virtual DbSet<DsType> DsTypes { get; set; }
        public virtual DbSet<StAttribute> StAttributes { get; set; }
        public virtual DbSet<StLink> StLinks { get; set; }
        public virtual DbSet<StMain> StMains { get; set; }
        public virtual DbSet<StVersion> StVersions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIN-6GBMQCM2I2A\\SQLEXPRESS;Database=DemoBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<DsAttribute>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("dsAttributes");

                entity.HasComment("Атриубты");

                entity.HasIndex(e => e.StName, "UQ_dsAttributes")
                    .IsUnique();

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.StName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stName")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<DsLinkType>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("dsLinkTypes");

                entity.HasComment("Типы связей");

                entity.HasIndex(e => e.StName, "UQ_dsLinkTypes")
                    .IsUnique();

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.StName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stName")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<DsState>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("dsStates");

                entity.HasComment("Состояния");

                entity.HasIndex(e => e.StName, "UQ_dsStates")
                    .IsUnique();

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.StName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stName")
                    .HasDefaultValueSql("('Наименование')");
            });

            modelBuilder.Entity<DsType>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("dsTypes");

                entity.HasComment("Типы");

                entity.HasIndex(e => e.StName, "UQ_dsTypes")
                    .IsUnique();

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.BiDocument)
                    .HasColumnName("biDocument")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Является документом");

                entity.Property(e => e.StName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stName")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<StAttribute>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("stAttributes");

                entity.HasComment("Значения атрибутов");

                entity.HasIndex(e => new { e.InIdVersion, e.InIdAttr }, "UQ_stAttributes")
                    .IsUnique();

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.InIdAttr)
                    .HasColumnName("inIdAttr")
                    .HasComment("Идентификатор атрибута");

                entity.Property(e => e.InIdVersion)
                    .HasColumnName("inIdVersion")
                    .HasComment("Идентификатор версии объекта");

                entity.Property(e => e.StValue)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stValue")
                    .HasDefaultValueSql("('')")
                    .HasComment("Знчаение атрибута");

                entity.HasOne(d => d.InIdAttrNavigation)
                    .WithMany(p => p.StAttributes)
                    .HasForeignKey(d => d.InIdAttr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stAttributes_inIdAttr_dsAttributes");

                entity.HasOne(d => d.InIdVersionNavigation)
                    .WithMany(p => p.StAttributes)
                    .HasForeignKey(d => d.InIdVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stAttributes_inIdVersion_stVersions");
            });

            modelBuilder.Entity<StLink>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("stLinks");

                entity.HasComment("Таблица связей между объектами");

                entity.HasIndex(e => e.InIdChild, "IDX_stLinks_inIdChild");

                entity.HasIndex(e => e.InIdLinkType, "IDX_stLinks_inIdLinkType");

                entity.HasIndex(e => e.InIdParent, "IDX_stLinks_inIdParent");

                entity.HasIndex(e => new { e.InIdParent, e.InIdLinkType, e.InIdChild }, "IDX_stLinks_inIdParent_inIdTypeRel_inIdChild");

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.InIdChild)
                    .HasColumnName("inIdChild")
                    .HasComment("Идентфиикатор потомка");

                entity.Property(e => e.InIdLinkType)
                    .HasColumnName("inIdLinkType")
                    .HasComment("Идентификатор типа связи");

                entity.Property(e => e.InIdParent)
                    .HasColumnName("inIdParent")
                    .HasComment("Идентификатор родителя");

                entity.Property(e => e.InQuantity)
                    .HasColumnName("inQuantity")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Количество");

                entity.HasOne(d => d.InIdChildNavigation)
                    .WithMany(p => p.StLinkInIdChildNavigations)
                    .HasForeignKey(d => d.InIdChild)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stLinks_inIdChild_stVersions");

                entity.HasOne(d => d.InIdLinkTypeNavigation)
                    .WithMany(p => p.StLinks)
                    .HasForeignKey(d => d.InIdLinkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stLinks_inIdLinkType_dsLinkTypes");

                entity.HasOne(d => d.InIdParentNavigation)
                    .WithMany(p => p.StLinkInIdParentNavigations)
                    .HasForeignKey(d => d.InIdParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stLinks_inIdParent_stVersions");
            });

            modelBuilder.Entity<StMain>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("stMain");

                entity.HasComment("Объекты");

                entity.HasIndex(e => e.InIdType, "IDX_stMain_inIdType");

                entity.HasIndex(e => new { e.StName, e.InIdType }, "UQ_stMain")
                    .IsUnique();

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.InIdType)
                    .HasColumnName("inIdType")
                    .HasComment("Идентификатор типа");

                entity.Property(e => e.StName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stName")
                    .HasComment("Обозначение");

                entity.HasOne(d => d.InIdTypeNavigation)
                    .WithMany(p => p.StMains)
                    .HasForeignKey(d => d.InIdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stMain_inIdType_dsTypes");
            });

            modelBuilder.Entity<StVersion>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("stVersions");

                entity.HasComment("Версии объектов");

                entity.HasIndex(e => new { e.InIdMain, e.StNumber }, "UQ_stVersions")
                    .IsUnique();

                entity.Property(e => e.InId).HasColumnName("inId");

                entity.Property(e => e.InIdMain)
                    .HasColumnName("inIdMain")
                    .HasComment("Идентификатор объекта");

                entity.Property(e => e.InIdState)
                    .HasColumnName("inIdState")
                    .HasComment("Идентификатор состояния");

                entity.Property(e => e.StNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stNumber")
                    .HasComment("Версия");

                entity.HasOne(d => d.InIdMainNavigation)
                    .WithMany(p => p.StVersions)
                    .HasForeignKey(d => d.InIdMain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stVersions_inIdMain_stMain");

                entity.HasOne(d => d.InIdStateNavigation)
                    .WithMany(p => p.StVersions)
                    .HasForeignKey(d => d.InIdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stVersions_inIdState_dsStates");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
