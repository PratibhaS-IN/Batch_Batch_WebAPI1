using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Batch_WebAPI1.Models
{
    public partial class BatchContext : DbContext
    {
        public BatchContext()
        {
        }

        public BatchContext(DbContextOptions<BatchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcitivityLog> AcitivityLogs { get; set; }
        public virtual DbSet<Acl> Acls { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<BatchDetail> BatchDetails { get; set; }
        public virtual DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QIS920J; Database=Batch; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AcitivityLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("AcitivityLog");

                entity.Property(e => e.LogId).HasColumnName("Log_ID");

                entity.Property(e => e.ActiityDateTime).HasColumnType("datetime");

                entity.Property(e => e.Activity).HasMaxLength(50);

                entity.Property(e => e.BatchId)
                    .HasMaxLength(50)
                    .HasColumnName("batchId");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Acl>(entity =>
            {
                entity.ToTable("ACL");

                entity.Property(e => e.AclId).HasColumnName("Acl_ID");

                entity.Property(e => e.BatchId)
                    .HasMaxLength(50)
                    .HasColumnName("batchId");

                entity.Property(e => e.ReadGroups)
                    .HasMaxLength(50)
                    .HasColumnName("readGroups");

                entity.Property(e => e.ReadUsers)
                    .HasMaxLength(50)
                    .HasColumnName("readUsers");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.HasKey(e => e.AttrId);

                entity.Property(e => e.AttrId).HasColumnName("Attr_Id");

                entity.Property(e => e.BatchId)
                    .HasMaxLength(50)
                    .HasColumnName("batchId");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<BatchDetail>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .HasName("PK_BatchDetails_1");

                entity.Property(e => e.BatchId).HasColumnName("batchId");

                entity.Property(e => e.BatchId1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("batch_Id");

                entity.Property(e => e.BatchPublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("batchPublishDate");

                entity.Property(e => e.BusinessUnit)
                    .HasMaxLength(50)
                    .HasColumnName("businessUnit");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("File");

                entity.Property(e => e.FId).HasColumnName("F_Id");

                entity.Property(e => e.BatchId)
                    .HasMaxLength(50)
                    .HasColumnName("batchId");

                entity.Property(e => e.FileSize)
                    .HasMaxLength(50)
                    .HasColumnName("fileSize");

                entity.Property(e => e.FileType).HasMaxLength(50);

                entity.Property(e => e.Filename)
                    .HasMaxLength(50)
                    .HasColumnName("filename");

                entity.Property(e => e.Hash)
                    .HasMaxLength(50)
                    .HasColumnName("hash");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
