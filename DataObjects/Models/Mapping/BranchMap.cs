using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class BranchMap : EntityTypeConfiguration<Branch>
    {
        public BranchMap()
        {
            // Primary Key
            this.HasKey(t => t.BranchId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Branch");
            this.Property(t => t.BranchId).HasColumnName("BranchId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.ActionTime).HasColumnName("ActionTime");
            this.Property(t => t.Deposit).HasColumnName("Deposit");
            this.Property(t => t.NLCostDeposit).HasColumnName("NLCostDeposit");
            this.Property(t => t.Advance).HasColumnName("Advance");
            this.Property(t => t.ClassifiedAmount).HasColumnName("ClassifiedAmount");
            this.Property(t => t.WOL).HasColumnName("WOL");
            this.Property(t => t.Profit).HasColumnName("Profit");
            this.Property(t => t.Manpower).HasColumnName("Manpower");
        }
    }
}
