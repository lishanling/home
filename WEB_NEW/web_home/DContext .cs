using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using web_home.Models;

namespace web_home
{
    public class DContext : DbContext
    {
        /// <summary>
        /// 添加构造函数,name为config文件中数据库连接字符串的name
        /// </summary>
        public DContext() : base("name=MyContext")
        {
           // Database.SetInitializer<DContext>(null);
            Database.CreateIfNotExists();
        }

        #region 数据集
        public DbSet<Study> Study { get; set; }
        public DbSet<classmate> classmate { get; set; }

        public DbSet<t_user> t_user { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new ProviceConfiguration());
        //    modelBuilder.Configurations.Add(new CityConfiguration());
        //}
        #endregion  
    }
}