using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease;
using System.Text;
using ServiceStack.Redis;
using web_home.Models;
using ServiceStack.Redis.Support;
 
namespace web_home.Unitl
{
    [Obsolete]
    public class RedisCacheManager
    {
        public void test(){
            try
            {
                //获取Redis操作接口
                IRedisClient Redis = RedisManager.GetClient();
                //Hash表操作
                HashOperator operators = new HashOperator();
 
                //移除某个缓存数据
                bool isTrue = Redis.Remove("additemtolist");
 
                //将字符串列表添加到redis
                List<string> storeMembers = new List<string>() { "韩梅梅", "李雷", "露西" };
                storeMembers.ForEach(x => Redis.AddItemToList("additemtolist", x));
                //得到指定的key所对应的value集合
                
                var members = Redis.GetAllItemsFromList("additemtolist");
                members.ForEach(s => Console.WriteLine("additemtolist :" + s));
             
 
                // 获取指定索引位置数据
              
                var item = Redis.GetItemFromList("additemtolist", 2);
           
                //将数据存入Hash表中
                classmate classmates = new classmate() {  cname = "李雷",  cnumber = 45 };
                var ser = new ObjectSerializer();    //位于namespace ServiceStack.Redis.Support;
                bool results = operators.Set<byte[]>("classmatesHash", "classmates", ser.Serialize(classmates));
                byte[] infos = operators.Get<byte[]>("classmatesHash", "classmates");
                classmates = ser.Deserialize(infos) as classmate;
 
 
                //object序列化方式存储
              
                classmate uInfo = new classmate() { cname = "张三", cnumber = 12 };
                bool result = Redis.Set<byte[]>("uInfo", ser.Serialize(uInfo));
                classmate classmate2 = ser.Deserialize(Redis.Get<byte[]>("uInfo")) as classmate;
               
                Redis.Set<int>("my_cnumber", 12);//或Redis.Set("my_cnumber", 12);
                int cnumber = Redis.Get<int>("my_cnumber");
               
 
                //序列化列表数据
                Console.WriteLine("列表数据:");
                List<classmate> classmateList = new List<classmate> {
                new classmate{cname="露西",cnumber=1, cid=1},
                new classmate{cname="玛丽",cnumber=3,cid=2},
            };
                Redis.Set<byte[]>("classmatelist_serialize", ser.Serialize(classmateList));
                List<classmate> userList = ser.Deserialize(Redis.Get<byte[]>("classmatelist_serialize")) as List<classmate>;
               
                //释放内存
                Redis.Dispose();
                operators.Dispose();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
               var result= ex.Message;
            }
        }
    }
}