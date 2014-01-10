using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class CIBStatuMap : EntityTypeConfiguration<CIBStatu>
    {
        public CIBStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.CIBStatusId);

            // Properties
            // Table & Column Mappings
            this.ToTable("CIBStatus");
            this.Property(t => t.CIBStatusId).HasColumnName("CIBStatusId");
            this.Property(t => t.CustLimit).HasColumnName("CustLimit");
            this.Property(t => t.CustOS).HasColumnName("CustOS");
            this.Property(t => t.AlliedLimit).HasColumnName("AlliedLimit");
            this.Property(t => t.AlliedOS).HasColumnName("AlliedOS");
            this.Property(t => t.NOF).HasColumnName("NOF");
            this.Property(t => t.ReportDate).HasColumnName("ReportDate");
            this.Property(t => t.CreditInfoId).HasColumnName("CreditInfoId");

            // Relationships
            this.HasRequired(t => t.CIBStatu1)
                .WithOptional(t => t.CIBStatus1);

        }
    }
}
