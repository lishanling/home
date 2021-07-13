using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using web_home.Models;

namespace web_home.Unitl
{
    public class PageHelper
    {
        public static IQueryable<T> SqlQueryAndParameter<T>(IQueryable<T> linqsql,PageIm pages)
        {
            pages.count = linqsql.Count();
            return linqsql.Skip((pages.pageNo - 1) * pages.pageSize).Take(pages.pageSize);
        }
        /// <summary>  
        /// 分页查询 + 条件查询 + 排序  
        /// </summary>  
        /// <typeparam name="Tkey">泛型</typeparam>  
        /// <param name="pageSize">每页大小</param>  
        /// <param name="pageIndex">当前页码</param>  
        /// <param name="total">总数量</param>  
        /// <param name="whereLambda">查询条件</param>  
        /// <param name="orderbyLambda">排序条件</param>  
        /// <param name="isAsc">是否升序</param>  
        /// <returns>IQueryable 泛型集合</returns>  
        public static IQueryable<T> LoadPageItems<T, TKey>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderbyLambda, bool isAsc) where T : class
        {
            //自己的EF数据上下文
            DContext mkxx = new DContext();
            total = mkxx.Set<T>().Where(whereLambda).Count();
            //倒序或升序
            if (isAsc)
            {
                var temp = mkxx.Set<T>().Where(whereLambda)
                             .OrderBy<T, TKey>(orderbyLambda)
                             .Skip(pageSize * (pageIndex - 1))
                             .Take(pageSize);
                return temp.AsQueryable();
            }
            else
            {
                var temp = mkxx.Set<T>().Where(whereLambda)
                           .OrderByDescending<T, TKey>(orderbyLambda)
                           .Skip(pageSize * (pageIndex - 1))
                           .Take(pageSize);
                return temp.AsQueryable();
            }
        }
        public static List<dynamic> getPageDate<T, TKey>(Expression<Func<T, dynamic>> select, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, int pageIndex, int pageSize, out int Total)
            where T : class
        {
            DContext db = new DContext();
            Total = db.Set<T>().Where(where).Count();
            var list = db.Set<T>().Where(where).OrderByDescending(order).Select(select).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return list.ToList();
        }
    }
}