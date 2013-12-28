using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class CreditFileMap : EntityTypeConfiguration<CreditFile>
    {
        public CreditFileMap()
        {
            // Primary Key
            this.HasKey(t => t.CreditFileId);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(200);

            this.Property(t => t.FilePath)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("CreditFile");
            this.Property(t => t.CreditFileId).HasColumnName("CreditFileId");
            this.Property(t => t.CreditInfoId).HasColumnName("CreditInfoId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
            this.Property(t => t.ActionTime).HasColumnName("ActionTime");

            // Relationships
            this.HasOptional(t => t.CreditInfo)
                .WithMany(t => t.CreditFiles)
                .HasForeignKey(d => d.CreditInfoId);

        }
    }
}
