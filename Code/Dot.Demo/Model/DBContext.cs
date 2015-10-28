/******
         ��vs2013IDE�У�����-->������������-->���������������̨
		 Enable-Migrations -Force -ContextTypeName ������
         Enable-Migrations -Force -ContextTypeName PMSContext
         add-migration Initial 
         update-database -Verbose
         Update-Database �CTargetMigration: Initial6
 
 * **************/

namespace Dot.Demo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Definition;

    public partial class DBContext : DbContext
    {
        static DbContext context = new DBContext();
        public DBContext()
            : base("name=" + Constant.ConnectionName.EntityString)
        {
            Context = context;
        }

        public DbContext Context { get; set; }

        public virtual DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectConfig());

        }
    }

}
