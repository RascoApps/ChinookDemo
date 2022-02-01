using System;
using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;

namespace Chinook.Xaf.Module.BusinessObjects {
    // This code allows our Model Editor to get relevant EF Core metadata at design time.
    // For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
	public class XafContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			var optionsBuilder = new DbContextOptionsBuilder<XafEFCoreDbContext>()
                .UseSqlServer(@";");
            return new XafEFCoreDbContext(optionsBuilder.Options);
		}
	}
	//This factory creates DbContext for design-time services. For example, it is required for database migration.
	public class XafDesignTimeDbContextFactory : IDesignTimeDbContextFactory<XafEFCoreDbContext> {
		public XafEFCoreDbContext CreateDbContext(string[] args) {
			throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
			//var optionsBuilder = new DbContextOptionsBuilder<XafEFCoreDbContext>();
			//optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Chinook.Xaf");
			//return new XafEFCoreDbContext(optionsBuilder.Options);
		}
	}
	[TypesInfoInitializer(typeof(XafContextInitializer))]
	public class XafEFCoreDbContext : DbContext {
		public XafEFCoreDbContext(DbContextOptions<XafEFCoreDbContext> options) : base(options) {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
		public DbSet<ReportDataV2> ReportDataV2 { get; set; }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }
	}

    public class XafAuditingDbContext : DbContext {
        public XafAuditingDbContext(DbContextOptions<XafAuditingDbContext> options) : base(options) {
        }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }
    }
}
