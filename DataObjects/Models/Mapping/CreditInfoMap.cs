using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class CreditInfoMap : EntityTypeConfiguration<CreditInfo>
    {
        public CreditInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.CreditInfoId);

            // Properties
            this.Property(t => t.Info)
                .HasMaxLength(200);

            this.Property(t => t.Subject)
                .HasMaxLength(200);

            this.Property(t => t.BorrowerName)
                .HasMaxLength(200);

            this.Property(t => t.ProposedFacility)
                .HasMaxLength(200);

            this.Property(t => t.BranchProposalRef)
                .HasMaxLength(200);

            this.Property(t => t.BranchProposalDate)
                .HasMaxLength(200);

            this.Property(t => t.HOReceivedDate)
                .HasMaxLength(200);

            this.Property(t => t.DateOfAccountOpening)
                .HasMaxLength(200);

            this.Property(t => t.ClientName)
                .HasMaxLength(50);

            this.Property(t => t.RegisterAddress)
                .HasMaxLength(200);

            this.Property(t => t.CorporateAddress)
                .HasMaxLength(200);

            this.Property(t => t.FactoryAddress)
                .HasMaxLength(200);

            this.Property(t => t.NatureOfBusiness)
                .HasMaxLength(200);

            this.Property(t => t.Products)
                .HasMaxLength(200);

            this.Property(t => t.CapitalStructure)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CreditInfo");
            this.Property(t => t.CreditInfoId).HasColumnName("CreditInfoId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.BranchId).HasColumnName("BranchId");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.AssignUserId).HasColumnName("AssignUserId");
            this.Property(t => t.Info).HasColumnName("Info");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.BorrowerName).HasColumnName("BorrowerName");
            this.Property(t => t.ApplicationDate).HasColumnName("ApplicationDate");
            this.Property(t => t.ProposedFacility).HasColumnName("ProposedFacility");
            this.Property(t => t.BranchProposalRef).HasColumnName("BranchProposalRef");
            this.Property(t => t.BranchProposalDate).HasColumnName("BranchProposalDate");
            this.Property(t => t.HOReceivedDate).HasColumnName("HOReceivedDate");
            this.Property(t => t.DateOfAccountOpening).HasColumnName("DateOfAccountOpening");
            this.Property(t => t.ClientName).HasColumnName("ClientName");
            this.Property(t => t.RegisterAddress).HasColumnName("RegisterAddress");
            this.Property(t => t.CorporateAddress).HasColumnName("CorporateAddress");
            this.Property(t => t.FactoryAddress).HasColumnName("FactoryAddress");
            this.Property(t => t.NatureOfBusiness).HasColumnName("NatureOfBusiness");
            this.Property(t => t.Products).HasColumnName("Products");
            this.Property(t => t.CapitalStructure).HasColumnName("CapitalStructure");

            // Relationships
            this.HasOptional(t => t.Branch)
                .WithMany(t => t.CreditInfoes)
                .HasForeignKey(d => d.BranchId);
            this.HasOptional(t => t.Client)
                .WithMany(t => t.CreditInfoes)
                .HasForeignKey(d => d.ClientId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.CreditInfoes)
                .HasForeignKey(d => d.AssignUserId);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.CreditInfoes1)
                .HasForeignKey(d => d.CreatedUserId);

        }
    }
}
