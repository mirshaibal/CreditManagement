using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class FacilityDetailMap : EntityTypeConfiguration<FacilityDetail>
    {
        public FacilityDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.FacilityDetailId);

            // Properties
            this.Property(t => t.LYTurnOver)
                .HasMaxLength(250);

            this.Property(t => t.OverdueInstNo)
                .HasMaxLength(250);

            this.Property(t => t.CLStatus)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FacilityDetail");
            this.Property(t => t.FacilityDetailId).HasColumnName("FacilityDetailId");
            this.Property(t => t.CreditInfoId).HasColumnName("CreditInfoId");
            this.Property(t => t.NatureOfFacility).HasColumnName("NatureOfFacility");
            this.Property(t => t.ELFunded).HasColumnName("ELFunded");
            this.Property(t => t.ELNonFunded).HasColumnName("ELNonFunded");
            this.Property(t => t.OSFunded).HasColumnName("OSFunded");
            this.Property(t => t.OSNonFunded).HasColumnName("OSNonFunded");
            this.Property(t => t.Validity).HasColumnName("Validity");
            this.Property(t => t.LYTurnOver).HasColumnName("LYTurnOver");
            this.Property(t => t.EOL).HasColumnName("EOL");
            this.Property(t => t.OverdueInstNo).HasColumnName("OverdueInstNo");
            this.Property(t => t.OverdueInstAmount).HasColumnName("OverdueInstAmount");
            this.Property(t => t.CLStatus).HasColumnName("CLStatus");
            this.Property(t => t.APFFunded).HasColumnName("APFFunded");
            this.Property(t => t.APFNonFunded).HasColumnName("APFNonFunded");
            this.Property(t => t.FaiclityFor).HasColumnName("FaiclityFor");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");

            // Relationships
            this.HasRequired(t => t.CreditInfo)
                .WithMany(t => t.FacilityDetails)
                .HasForeignKey(d => d.CreditInfoId);

        }
    }
}
