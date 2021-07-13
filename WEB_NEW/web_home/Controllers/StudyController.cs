using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_home.BLL;

namespace web_home.Controllers
{
    public class StudyController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult add()
        {
            StudyBLL s = new StudyBLL();
             s.add();
             return JRestlt(null); 
        }
        public ActionResult getList()
        {
            StudyBLL s = new StudyBLL();
            var result=s.getList();
            return JRestlt(result); 
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult getPageList(int pageSize,int pageNO)
        {
            StudyBLL s = new StudyBLL();
             
            var result = s.getPageList(pageSize,pageNO);
            return JRestlt(result); 
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}