using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class RelationshipSummaryMap : EntityTypeConfiguration<RelationshipSummary>
    {
        public RelationshipSummaryMap()
        {
            // Primary Key
            this.HasKey(t => t.RelationshipId);

            // Properties
            this.Property(t => t.FacilityNature)
                .HasMaxLength(200);

            this.Property(t => t.FundedLimit)
                .HasMaxLength(50);

            this.Property(t => t.NonFundedLimit)
                .HasMaxLength(50);

            this.Property(t => t.RescheduleTime)
                .HasMaxLength(50);

            this.Property(t => t.RescheduleAmount)
                .HasMaxLength(50);

            this.Property(t => t.ApprovalAuthority)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("RelationshipSummary");
            this.Property(t => t.RelationshipId).HasColumnName("RelationshipId");
            this.Property(t => t.CreditInfoId).HasColumnName("CreditInfoId");
            this.Property(t => t.FacilityNature).HasColumnName("FacilityNature");
            this.Property(t => t.SanctionDate).HasColumnName("SanctionDate");
            this.Property(t => t.FundedLimit).HasColumnName("FundedLimit");
            this.Property(t => t.NonFundedLimit).HasColumnName("NonFundedLimit");
            this.Property(t => t.ExpiryDate).HasColumnName("ExpiryDate");
            this.Property(t => t.RescheduleTime).HasColumnName("RescheduleTime");
            this.Property(t => t.RescheduleAmount).HasColumnName("RescheduleAmount");
            this.Property(t => t.ApprovalAuthority).HasColumnName("ApprovalAuthority");

            // Relationships
            this.HasOptional(t => t.CreditInfo)
                .WithMany(t => t.RelationshipSummaries)
                .HasForeignKey(d => d.CreditInfoId);

        }
    }
}
