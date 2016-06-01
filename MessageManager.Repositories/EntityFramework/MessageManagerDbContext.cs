using MessageManager.Domain.Entity;
using MessageManager.Repositories.EntityFramework.ModelConfigurations;
using System.Data.Entity;

namespace MessageManager.Repositories.EntityFramework
{
    /// <summary>
    /// 表示专用于MessageManager案例的数据访问上下文。
    /// </summary>
    public sealed class MessageManagerDbContext : DbContext
    {
        public MessageManagerDbContext()
            : base("name = MessageManagerDbContext")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            this.Configuration.LazyLoadingEnabled = true;
    }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MessageConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
