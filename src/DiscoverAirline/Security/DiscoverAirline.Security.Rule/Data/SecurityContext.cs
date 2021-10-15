using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Rule.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Data
{
    public class SecurityContext : DbContext
    {
        protected IDbContextTransaction _contextoTransaction { get; set; }
        protected SecurityContext _securityContext { get; set; }

        public virtual DbSet<Domain.Entities.Action> Actions { get; set; }
        public virtual DbSet<Controller> Controllers { get; set; }
        public virtual DbSet<ControllerActions> ControllerActions { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileRoles> ProfileRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleServices> RoleServices { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceControllers> ServiceControllers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        public SecurityContext(DbContextOptions<SecurityContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        public async Task<IDbContextTransaction> StartTransactionAsync()
        {
            if (_contextoTransaction == null)
            {
                _contextoTransaction = await this.Database.BeginTransactionAsync();
            }
            return _contextoTransaction;
        }

        public async Task SaveChangesCommitAsync()
        {
            await SaveAsync();
            await CommitAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActionMap());
            modelBuilder.ApplyConfiguration(new ControllerActionsMap());
            modelBuilder.ApplyConfiguration(new ControllerMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new ProfileRolesMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new RoleServicesMap());
            modelBuilder.ApplyConfiguration(new ServiceControllersMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserRefreshTokenMap());

            base.OnModelCreating(modelBuilder);
        }

        private async Task RollBackAsync()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.RollbackAsync();
            }
        }

        private async Task SaveAsync()
        {
            try
            {
                ChangeTracker.DetectChanges();
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await RollBackAsync();
                throw new Exception(ex.Message);
            }
        }

        private async Task CommitAsync()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.CommitAsync();
                await _contextoTransaction.DisposeAsync();
                _contextoTransaction = null;
            }
        }

    }
}
