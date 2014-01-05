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

            // Table & Column Mappings
            this.ToTable("Client");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.BranchId).HasColumnName("BranchId");
            this.Property(t => t.Name).HasColumnName("Name");            
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
