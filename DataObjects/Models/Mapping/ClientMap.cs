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

            // Table & Column Mappings
            this.ToTable("Client");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.BranchId).HasColumnName("BranchId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.ActionTime).HasColumnName("ActionTime");

            // Relationships
            this.HasRequired(t => t.Branch)
                .WithMany(t => t.Clients)
                .HasForeignKey(d => d.BranchId);

        }
    }
}
