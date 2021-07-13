//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using web_home;
//using web_home.Models;
//using web_home.Unitl;

//namespace web_home.BLL
//{
//    public class StudyBLL
//    {
//        public static DContext context = new DContext();
  
//        public IList<Study> getList()
//        {
//            var studys = context.Study.Where(p => p.ID == 1).ToList();
//            return studys;
//        }
//        public void add()
//        {
//            context.classmate.Add(new classmate() {  cid = 6, cname = "王凯" , cteacher="但是大家发", cnumber=56});
//            //context.classmate.Add(new classmate() { cid = 6, cname = "class 3", cteacher = "Marryi", cnumber = 34 });
//            context.SaveChanges();
//        }

//        public PageTableResult getPageList(int pageSize,int pageNO)
//        {
//            var classmates = context.classmate.ToList();
            
//            //var result = new PageTableResult { PageNo = pageNO, PageSize = pageSize, Table = classmates, Total = classmates .Count()};
//            int total=0;
//            var classmates2=PageHelper.getPageDate<classmate, int>(c => new { c.cid, c.cname, c.cteacher,c.cnumber }, c => c.cid > 0, c => c.cid, pageNO, pageSize, out total);
//            var result2= new PageTableResult { PageNo = pageNO, PageSize = pageSize, Table = classmates2, Total =total};
//            return result2;
//        }
//    }
//}