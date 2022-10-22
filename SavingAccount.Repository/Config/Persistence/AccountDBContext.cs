using Microsoft.EntityFrameworkCore;
using SavingAccount.Entity.Model;
using System.Reflection;

namespace SavingAccount.Repository.Config.Persistence
{
    public class AccountDBContext : DbContext
    {

        //private readonly string stringConnection;

        public AccountDBContext(DbContextOptions<AccountDBContext> options) : base(options)
        {
            

        }

        public virtual DbSet<ClientModel> Client { get; set; }
        public virtual DbSet<BalanceModel> Balance { get; set; }
        public virtual DbSet<AccountModel> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().Property(a => a.ID_ACCOUNT)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<ClientModel>()
                .HasMany(a => a.ACCOUNT_LIST)
                .WithOne(a => a.CLIENT)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AccountModel>()
                .HasOne(a => a.CLIENT)
                .WithMany(a => a.ACCOUNT_LIST)
                .HasForeignKey(a => a.ID_CLIENT);
            
            modelBuilder.Entity<AccountModel>()
                .HasMany(a => a.BALANCE_LIST)
                .WithOne(a => a.ACCOUNT)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BalanceModel>()
                .HasOne(a => a.ACCOUNT)
                .WithMany(a => a.BALANCE_LIST)
                .HasForeignKey(a => a.ACCOUNT_NUMBER);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
