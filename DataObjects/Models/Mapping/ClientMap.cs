using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(1000);

            this.Property(t => t.CorporateAddress)
                .HasMaxLength(1000);

            this.Property(t => t.FactoryAddress)
                .HasMaxLength(1000);

            this.Property(t => t.AuthorizedCapital)
                .HasMaxLength(100);

            this.Property(t => t.PaidupCapital)
                .HasMaxLength(100);

            this.Property(t => t.Products)
                .HasMaxLength(1000);

            this.Property(t => t.BusinessNature)
                .HasMaxLength(1000);

            this.Property(t => t.ConstitutionNature)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Client");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.BranchId).HasColumnName("BranchId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.ActionTime).HasColumnName("ActionTime");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.CorporateAddress).HasColumnName("CorporateAddress");
            this.Property(t => t.FactoryAddress).HasColumnName("FactoryAddress");
            this.Property(t => t.AuthorizedCapital).HasColumnName("AuthorizedCapital");
            this.Property(t => t.PaidupCapital).HasColumnName("PaidupCapital");
            this.Property(t => t.Products).HasColumnName("Products");
            this.Property(t => t.IncorporationDate).HasColumnName("IncorporationDate");
            this.Property(t => t.BusinessNature).HasColumnName("BusinessNature");
            this.Property(t => t.ConstitutionNature).HasColumnName("ConstitutionNature");

            // Relationships
            this.HasRequired(t => t.Branch)
                .WithMany(t => t.Clients)
                .HasForeignKey(d => d.BranchId);

        }
    }
}
