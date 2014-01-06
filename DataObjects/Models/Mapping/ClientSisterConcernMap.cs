using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class ClientSisterConcernMap : EntityTypeConfiguration<ClientSisterConcern>
    {
        public ClientSisterConcernMap()
        {
            // Primary Key
            this.HasKey(t => t.SisterConcernId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ClientSisterConcern");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ActionTime).HasColumnName("ActionTime");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.NationalId).HasColumnName("NationalId");
            this.Property(t => t.HoldingShares).HasColumnName("HoldingShares");
            this.Property(t => t.Percentage).HasColumnName("Percentage");
            this.Property(t => t.PNW).HasColumnName("PNW");            

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientSisterConcerns)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
