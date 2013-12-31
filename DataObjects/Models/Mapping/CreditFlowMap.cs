using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class CreditFlowMap : EntityTypeConfiguration<CreditFlow>
    {
        public CreditFlowMap()
        {
            // Primary Key
            this.HasKey(t => t.CreditFlowId);

            // Properties
            // Table & Column Mappings
            this.ToTable("CreditFlow");
            this.Property(t => t.CreditFlowId).HasColumnName("CreditFlowId");
            this.Property(t => t.AssignFromUserId).HasColumnName("AssignFromUserId");
            this.Property(t => t.AssignToUserId).HasColumnName("AssignToUserId");
            this.Property(t => t.CreditInfoId).HasColumnName("CreditInfoId");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.IsLatestComment).HasColumnName("IsLatestComment");
            this.Property(t => t.ActionTime).HasColumnName("ActionTime");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.CreditFlows)
                .HasForeignKey(d => d.AssignFromUserId);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.CreditFlows1)
                .HasForeignKey(d => d.AssignToUserId);
            this.HasOptional(t => t.CreditInfo)
                .WithMany(t => t.CreditFlows)
                .HasForeignKey(d => d.CreditInfoId);

        }
    }
}
