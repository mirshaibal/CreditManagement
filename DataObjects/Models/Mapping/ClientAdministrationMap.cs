using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataObjects.Models.Mapping
{
    public class ClientAdministrationMap : EntityTypeConfiguration<ClientAdministration>
    {
        public ClientAdministrationMap()
        {
            // Primary Key
            this.HasKey(t => t.AdminId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);           

            // Table & Column Mappings
            this.ToTable("ClientAdministration");
            this.Property(t => t.ClientId).HasColumnName("ClientId");            
            this.Property(t => t.Name).HasColumnName("Name");            
            this.Property(t => t.ActionTime).HasColumnName("ActionTime");           
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.FatherName).HasColumnName("FatherName");
            this.Property(t => t.MotherName).HasColumnName("MotherName");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.Education).HasColumnName("Education");
            this.Property(t => t.BackgroundDetails).HasColumnName("BackgroundDetails");
            this.Property(t => t.BusinessExperience).HasColumnName("BusinessExperience");
            this.Property(t => t.Position).HasColumnName("Position");                    

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientAdministrations)
                .HasForeignKey(d => d.ClientId);

        }
    }
}

