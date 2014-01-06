using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataObjects.Models.Mapping;

namespace DataObjects.Models
{
    public partial class CreditManagementDBContext : DbContext
    {
        static CreditManagementDBContext()
        {
            Database.SetInitializer<CreditManagementDBContext>(null);
        }

        public CreditManagementDBContext()
            : base("Name=CreditManagementDBContext")
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CreditFile> CreditFiles { get; set; }
        public DbSet<CreditFlow> CreditFlows { get; set; }
        public DbSet<CreditInfo> CreditInfoes { get; set; }
        public DbSet<RelationshipSummary> RelationshipSummaries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClientAdministration> ClientAdministrations { get; set; }
        public DbSet<ClientSisterConcern > ClientSisterConcerns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new CreditFileMap());
            modelBuilder.Configurations.Add(new CreditFlowMap());
            modelBuilder.Configurations.Add(new CreditInfoMap());
            modelBuilder.Configurations.Add(new RelationshipSummaryMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ClientAdministrationMap());
            modelBuilder.Configurations.Add(new ClientSisterConcernMap());
        }
    }
}
